using MMSG.Automation.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MMSG.Automation.Database_Support.DBDataTransferObjects
{
    public class DBUserQueries : DatabaseTools
    {
        /// <summary>
        /// Get employer number based on the surname
        /// </summary>
        /// <param name="role">This is usertype enum.</param>
        /// <returns>Return employee number.</returns>
        public string GetEmployeeNumberBySurName(User.UserTypeEnum role)
        {
            string employeeNumber = string.Empty;

            try
            {
                User user = User.Get(role);
                string surName = user.Surname.ToString();
                switch (role)
                {
                    // Purpose: Query To Retrieve Username for Ws Admin
                    case User.UserTypeEnum.COMETUser:
                    case User.UserTypeEnum.NewCOMETUser:
                    case User.UserTypeEnum.TELCEmployee:
                        employeeNumber = GetdataDb(strConnection,
                                             "SELECT Top 1 CONCAT(iEmployeeExtIDBase , iEmployeeExtIDCheckDigit) as iEmployeeID FROM tbl_Employee WHERE sSurname ='" + surName + "'",
                                             "iEmployeeID");
                        break;
                }
                return employeeNumber;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Running the store proc and disabling the sms validation
        /// </summary>
        public void SMSDisableValidationInActivationSite()
        {
            try
            {
                // Purpose: Creating SQL Connection
                SqlConnection myConnection = new SqlConnection(strConnection);
                myConnection.Open();
                SqlCommand command = new SqlCommand("[dbo].[OS_2fAuthorisation_UpdValidateAuthCode]", myConnection);

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[OS_2fAuthorisation_UpdValidateAuthCode]";
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Getting the EAID using the SQL query
        /// </summary>
        /// <param name="userType"> User role</param>
        /// <returns>Return</returns>
        public string GetCardActivationCode(User.UserTypeEnum userType, string productName)
        {
            string cardActivationCode = string.Empty;
            try
            {
                // Get employee number
                User user = User.Get(userType);
                string employeeNo = user.EmployeeNumber.ToString();
                switch (userType)
                {
                    // Purpose: Query To Retrieve Username for Ws Admin
                    case User.UserTypeEnum.COMETUser:
                    case User.UserTypeEnum.NewCOMETUser:
                    case User.UserTypeEnum.TELCEmployee:
                        cardActivationCode = GetdataDb(strConnection,
                                            "Use Comet select sExternalAccountID from OT_CardAccount where iCardAccountId in (select iCardAccountID from OT_CardAccountCustomer where iEmployeeID in (select iEmployeeID from tbl_Package where sPackageNumber like '" + employeeNo + "%'))", "sExternalAccountID");
                        break;
                }
                return cardActivationCode;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Running the SMS validation Store poc
        /// </summary>
        public void SMSValidationStorePoc(string SMSStorePoc)
        {
            String sqlFilePath = "";
            // selelcting the SQL path which need to be execute
            switch (SMSStorePoc)
            {
                case "Disable":
                    sqlFilePath = GetDisableSMSFFilePath();
                    break;

                case "Enable":
                    sqlFilePath = GetEnableSMSFFilePath();
                    break;
            }
            string script = File.ReadAllText(sqlFilePath);
            // split script on GO command
            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                     RegexOptions.Multiline | RegexOptions.IgnoreCase);

            SqlConnection myConnection = new SqlConnection(strConnection);
            myConnection.Open();
            foreach (string commandString in commandStrings)
            {
                if (commandString.Trim() != "")
                {
                    using (var command = new SqlCommand(commandString, myConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Get disable SMS file path
        /// </summary>
        /// <returns>File path</returns>
        private static String GetDisableSMSFFilePath()
        {
            // get xml file path
            return Path.Combine(
                new string[] {
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    DBUserQueriesResource.DatabaseSupport_FolderName,
                    DBUserQueriesResource.DBDataTransferObjects_FolderName,
                    DBUserQueriesResource.DisableSMSValidationInActivationSite_FileName + ".sql" });
        }

        /// <summary>
        /// Get disable SMS file path
        /// </summary>
        /// <returns>File path</returns>
        private static String GetEnableSMSFFilePath()
        {
            // get xml file path
            return Path.Combine(
                new string[] {
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    DBUserQueriesResource.DatabaseSupport_FolderName,
                    DBUserQueriesResource.DBDataTransferObjects_FolderName,
                    DBUserQueriesResource.EnableTheSMSValidatio_FileName + ".sql" });
        }
       
        /// <summary>
        /// Returns the random Employe from Employer
        /// </summary>
        public string GetTheRandomEmployee(string employeerCode)
        {
            string packageNumber = string.Empty;

            try
            {
                packageNumber = GetdataDb(strConnection,
                                     "USE [Comet] select  top 1 p.sPackageNumber from tbl_Package P join tbl_PackageStatus ps on p.iPackageID = ps.iPackageID join tbl_EmployerOffering eo on eo.iEmployerOfferingID = p.iEmployerOfferingID join tbl_Offering o on o.iOfferingID = eo.iOfferingID join tbl_OfferingAdminFee oA on OA.iOfferingID = o.iOfferingID join tbl_Employer ER on eo.iEmployerID = er.iEmployerID  "
                                     + "where ps.iPackageCurrentStatusID not in (4, 5)  and er.sCode = '" + employeerCode + "' and p.sPackageNumber like '%01' order by NEWID()",
                                     "sPackageNumber");
            }
            catch (Exception e)
            {
                throw e;
            }
            return packageNumber;
        }

        /// <summary>
        /// Get the VMS balances
        /// </summary>
        /// <param name="packageID">Package ID of the Employee</param>
        /// <param name="EmployeID">Employee ID of the Employee</param>
        /// <returns></returns>
        public string GetTheVMSBalances(string packageID, string EmployeID)
        {
            string VMSBalances = string.Empty;
            try
            {
                //Getr the VMS data from DB
                VMSBalances = GetdataDb(strConnection,
                                    " use Comet EXEC dbo.usp_SelVMSCOMETBalances " + packageID + "," + EmployeID + ", null",
                                     "curVMSBalance");
            }
            catch (Exception e)
            {
                throw e;
            }
            return VMSBalances;
        }

        /// <summary>
        /// This query is used to retrieve EamsID by providing employee ID
        /// </summary>
        /// <param name="employeeID">This is employee ID</param>
        /// <returns>eamsID</returns>
        public string GetEamsID(int employeeID)
        {
            string dbEamsID = string.Empty;
            try
            {
                dbEamsID = GetdataDb(strConnection,
                                            "select sUserName from MSAOnline4..tbl_Account where iMasterID in(select iMasterEmployeeID from Accounts..tbl_MasterEmployeeAccount where sAccountID = '" + employeeID + "' and sSystem = 'COMET') ", "sUserName");
            }
            catch (Exception e)
            {
                throw e;
            }
            return dbEamsID;
        }

        /// <summary>
        /// Running the Store Poc to insert Data in to respective table
        /// </summary>
        /// <param name="storeProcName">Name of the store proc</param>
        public void RunStoreProcToPopulateProfile(string storeProcName)
        {
            try
            {
                //Store Poc which need to be run
                RunStoreProc(strConnection);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        ///  Get the Rol EAID and DOB from Gateway
        /// </summary>
        /// <param name="Value"></param>
        public string GetEAIDAndDOBforROL(string Value)
        {
            string valueToBereturned = string.Empty;

            try
            {
                valueToBereturned = GetdataDb(strConnection, "(select  top 1 ex.sExternalAccountIdentifier, ED.dDateOfBirth from FT_EmployeeDetails ED"
                                        + "join FT_CardAccount CA on CA.iEmployeeID = ED.iEmployeeID"
                                        + "join FT_External EX on EX.iAccountID = CA.iAccountID"
                                        + "join FT_CardState CS on CS.iAccountID = EX.iAccountID"
                                        + "where ED.LobBrandID = 1 and cs.sDescription like '%iNACTIVE%' and  sCardOrderDetials is  null)order by NEWID()",
                                     Value);
            }
            catch (Exception e)
            {
                throw e;
            }
            return valueToBereturned;
        }

        /// <summary>
        /// Get the only VMS user MOL Username
        /// </summary>
        /// <returns>MOL UserName</returns>
        public string GetOnlyVMSEmloyeeWithPasswordChange()
        {
            string valueToBereturned = string.Empty;

            try
            {
                valueToBereturned = GetdataDb(strConnection, "use MSAOnline4"
                + @" SELECT top 1a.sUserName"
                + @" FROM dbo.tbl_Account a"
                + @" JOIN dbo.tbl_EEProfile e ON a.iAccountID = e.iAccountID"
                + @" JOIN dbo.tbl_EEERLink erl ON erl.iEEProfileID = e.iEEProfileID"
                + @" JOIN dbo.tbl_ERProfile erp ON erp.iERProfileID = erl.iERProfileID"
                + @" JOIN Accounts.dbo.tbl_MasterEmployeeAccount mea ON mea.iMasterEmployeeID = a.iMasterID"
                + @" WHERE erp.sEmployerCode = 'REMQH'AND A.bActive = 1 AND A.bSuspended = 0 AND A.bTemporaryPassword = 0 AND A.sPassword <> ''AND A.iAccountTypeID = 3"
                + @" AND dtLastLogin BETWEEN GETDATE() - 90 AND GETDATE()"
                + @" order by newid()", "sUserName");
                GetdataDb(strConnection, " UPDATE [MSAOnline4].[dbo].[tbl_Account] set snetpassword = '68iIrRQ7dqY2fM2cCHJI9tS7HY4XDl/n8enFNJMXYif069ifpRPwqeRxxOe28/kJ', bTemporaryPassword = 0, bVPTemporaryPassword = 0 where sUserName = '" + valueToBereturned + "'",
                    "sUserName");
            }
            catch (Exception e)
            {
                throw e;
            }
            return valueToBereturned;
        }

        /// <summary>
        /// Random employee username of the Employeer
        /// </summary>
        /// <param name="employeerCode">Employeer Code to get the Employee</param>
        /// <returns>Username</returns>
        public string RandomEmployeeUsernameWithChagedPassword(string employeerCode)
        {
            string valueToBereturned = string.Empty;

            try
            {
                valueToBereturned = GetdataDb(strConnection, " use Comet"
            + @" Select sUserName  from MSAOnline4..tbl_Account where iMasterID in("
            + @" select iMasterEmployeeID from Accounts..tbl_MasterEmployeeAccount where sSystem = 'Comet' and sAccountID in("
            + @" select  iEmployeeID from Comet..tbl_Package where sPackageNumber in ("
            + @" select  top 1 p.sPackageNumber from tbl_Package P join tbl_PackageStatus ps on p.iPackageID = ps.iPackageID"
            + @" join tbl_EmployerOffering eo on eo.iEmployerOfferingID = p.iEmployerOfferingID"
            + @" join tbl_Offering o on o.iOfferingID = eo.iOfferingID"
            + @" join tbl_OfferingAdminFee oA on OA.iOfferingID = o.iOfferingID"
            + @" join tbl_Employer ER on eo.iEmployerID = er.iEmployerID"
            + @" where ps.iPackageCurrentStatusID not in (4, 5)  and er.sCode = '" + employeerCode + "' and p.sPackageNumber like '%01' order by NEWID())))", "sUserName");
                GetdataDb(strConnection, " UPDATE [MSAOnline4].[dbo].[tbl_Account] set snetpassword = '68iIrRQ7dqY2fM2cCHJI9tS7HY4XDl/n8enFNJMXYif069ifpRPwqeRxxOe28/kJ', bTemporaryPassword = 0, bVPTemporaryPassword = 0 where sUserName = '" + valueToBereturned + "'",
                    "sUserName");
            }
            catch (Exception e)
            {
                throw e;
            }
            return valueToBereturned;
        }

        /// <summary>
        /// Getting the Iqueue from DB
        /// </summary>
        /// <param name="userName">Username for which Iqeue need to be counted</param>
        /// <returns>Count of Iqueue with Awaiting status</returns>
        public string CountOfIqueueWithAwaitingForEmployeeUserName(string userName)
        {
            string valueToBereturned = string.Empty;
            try
            {
                valueToBereturned = GetdataDb(strConnection, "use Comet"
                + @" select COUNT(*) as AwaitingIqueue from iqueue..OT_Request  where iCurrentRequestStatusID = 2 and  sAssetReference in (select sPackageNumber from Comet..tbl_Package where iEmployeeID in ("
                + @" select sAccountID from Accounts..tbl_MasterEmployeeAccount where iMasterEmployeeID in ("
                + @" select iMasterID from MSAOnline4..tbl_Account where sUserName = '" + userName + "')))", "AwaitingIqueue");
            }
            catch (Exception e)
            {
                throw e;
            }
            return valueToBereturned;
        }

        /// <summary>
        /// Change the password of the user
        /// </summary>
        /// <param name="usertype">Usertype to which the password need to changed</param>
        public string ChangePasswordOfUserName(string Username)
        {
            try
            {
                GetdataDb(strConnection, " UPDATE [MSAOnline4].[dbo].[tbl_Account] set snetpassword = '68iIrRQ7dqY2fM2cCHJI9tS7HY4XDl/n8enFNJMXYif069ifpRPwqeRxxOe28/kJ', bTemporaryPassword = 0, bVPTemporaryPassword = 0 where sUserName = '" + Username + "'",
                    "sUserName");
                return "Password123";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Unlock the Suspened account 
        /// </summary>
        public void UnLockSuspenedAccount(string userName)
        {
            try
            {
                GetdataDb(strConnection, "Use MSAOnline4 update  tbl_account set ifailedLoginAttempts = 0 where  sUserName = '"+ userName + "'",
                    "sUserName");               
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}