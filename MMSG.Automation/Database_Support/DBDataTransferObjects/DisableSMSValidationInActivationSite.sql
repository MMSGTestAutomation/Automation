USE [MMSGCommon]
GO
/****** Object:  StoredProcedure [dbo].[OS_2fAuthorisation_UpdValidateAuthCode]    Script Date: 18/07/2017 5:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[OS_2fAuthorisation_UpdValidateAuthCode]
/*************************************************************************
MODIFICATION HISTORY
DATE          PERSON               REASON
----          ------               -----------------------------------------
dd/mm/yyyy    Who                        what, why
07/08/2014    AbhishekV            This stored proc validates the provided values against the records in OT_2fAuthorisationCodes, 
                                                voids all the existing non void record based on mobile number, calling context, systemid
                                                and returns [1- For Valid Auth code], [2- For Invalid Auth code] and[3- For expired Auth code].
24/05/2017    Saugat               Optimised to minimise deadlocks
*************************************************************************/
       @iSystemID INT
       ,@iCallingContext INT
       ,@sAccountID VARCHAR(255)
       ,@sMobileNo VARCHAR(20)
       ,@sAuthorisationCode VARCHAR(128)

AS

       BEGIN

              DECLARE @tmpAuthoraisationCodes AS TABLE (
                                                                                         [iAuthorisationCodeID] [int] NOT NULL
                                                                                         ,[dAddedDateTime] [datetime] NOT NULL
                                                                                         ,[iSystemID] [int] NOT NULL
                                                                                         ,[iCallingContextID] [int] NOT NULL
                                                                                         ,[sUserID] [varchar](255) NOT NULL
                                                                                         ,[sMobileNo] [varchar](20) NOT NULL
                                                                                         ,[sAuthorisationCode] [varchar](128) NOT NULL
                                                                                         ,[dExpiryDateTime] [datetime] NOT NULL
                                                                                         ,[bVoid] [bit] NOT NULL
                                                                                         ,[dValidatedDateTime] [datetime] NULL
                                                                                  )

              /*
                     Insert the matching record into a temp table so that its not required to query the table for every check
              */
              INSERT INTO @tmpAuthoraisationCodes
              SELECT [iAuthorisationCodeID],[dAddedDateTime],[iSystemID],[iCallingContextID],[sAccountID],[sMobileNo],[sAuthorisationCode],[dExpiryDateTime],[bVoid],[dValidatedDateTime]
              FROM OT_2fAuthorisationCodes 
              WHERE  sAccountID = @sAccountID
                     AND sMobileNo = @sMobileNo 
                     AND iSystemID = @iSystemID 
                     AND iCallingContextID = @iCallingContext 
                     AND bVoid = 0
                     AND sAuthorisationCode = @sAuthorisationCode
              
              /*
                     Make all the previous records void which match with either the sAccountID and iSystemID combined or sMobile number and are not void.
              */            
              UPDATE OT_2fAuthorisationCodes WITH (ROWLOCK, UPDLOCK)
              SET           bVoid = 1
                           ,dValidatedDateTime = GETDATE()
              --WHERE       [iAuthorisationCodeID] IN (SELECT [iAuthorisationCodeID] FROM @tmpAuthoraisationCodes) 
              

              SELECT 1

       --     IF EXISTS(SELECT TOP 1 1 FROM @tmpAuthoraisationCodes)
       --            BEGIN
       --                   IF EXISTS(SELECT TOP 1 1 FROM @tmpAuthoraisationCodes WHERE dExpiryDateTime < GETDATE())
       --                         BEGIN
       --                                SELECT 3      -- Select 3 for Expired Auth Code
       --                         END
       --                   ELSE
       --                          BEGIN
       --                                SELECT 1      -- Select 1 for Valid Authorisation Code
       --                         END
       --            END
       --     ELSE
       --            BEGIN
       --                   SELECT 2      -- Select 2 for Invalid Authorisation Code
       --            END
       END

