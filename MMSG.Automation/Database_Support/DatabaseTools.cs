using MMSG.Automation.Database_Support.DBDataTransferObjects;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MMSG.Automation.Database_Support
{
    public class DatabaseTools
    {
        // Purpose: Fetch Connection String
        private static SqlConnection conn = new SqlConnection();

        private static string DBConnString = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.DBServerName_Key].ToLower();
        public static readonly string strConnection = string.Format(AutomationConfigurationManagerResource.DBConnectionString, DBConnString);

        //COMETUATDBConnStr

        //Purpose: Method To Get Last Single Column Data
        public static string GetdataDb(string connString,
            string selecTionQuery, string columnName)
        {
            SqlConnection myConnection = null;
            SqlCommand myCommand = null;
            string returnValue = null;
            try
            {
                // Purpose: Creating SQL Connection
                myConnection = new SqlConnection(connString);
                myConnection.Open();
                SqlDataReader myReader = null;
                myCommand = new SqlCommand(selecTionQuery, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    returnValue = myReader[columnName].ToString();
                }
                return returnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // Close Db connection based on conectivity status 
                if (myConnection!= null && myCommand!= null)
                {
                    myCommand.Connection.Close();
                    myConnection.Close();
                }
            }
        }

        //Purpose: Method To Execute query To Connecting DB
        public static void ExecuteQueryDb(string connString, string insertQuery)
        {
            SqlConnection myConnection = null;
            SqlCommand myCommand = null;
            try
            {
                // Purpose: Creating SQL Connection
                myConnection = new SqlConnection(connString);
                myConnection.Open();
                myCommand = new SqlCommand(insertQuery, myConnection);
                myCommand.ExecuteNonQuery();               
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // Close Db connection based on conectivity status 
                if (myConnection != null && myCommand != null)
                {
                    myCommand.Connection.Close();
                    myConnection.Close();
                }
            }
        }

        /// <summary>
        /// Method to Fetch SQLConnection DB
        /// </summary>
        /// <returns>SQL connection</returns>
        public static SqlConnection GetSqlConnection()
        {
            try
            {
                // Purpose: Creating SQL Connection
                string connectionString = DatabaseTools.strConnection;
                var sqlConnection = new SqlConnection(connectionString);
                return sqlConnection;
            }
            catch (SqlException e)
            {
                throw new Exception(e.ToString());
            }
        }

        /// <summary>
        /// Run The store Proc to insert the data to the table
        /// </summary>
        /// <param name="selecTionQuery">Connetion String</param>
        public static void RunStoreProc(
            string selecTionQuery)
        {
            SqlConnection myConnection = null;
            SqlCommand myCommand = null;
            try
            {
                // Purpose: Creating SQL Connection
                myConnection = new SqlConnection(selecTionQuery + "Database=MSAonline4;");
                myConnection.Open();
                myCommand = new SqlCommand(DBUserQueriesResource.
                    DBUserQueries_PopulateEmpProfile_StoreProcedure_Name, myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandTimeout = 0;
                myCommand.ExecuteNonQuery();               
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // Close Db connection based on conectivity status 
                if (myConnection != null && myCommand != null)
                {
                    myCommand.Connection.Close();
                    myConnection.Close();
                }
            }
        }
    }
}