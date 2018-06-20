﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MMSG.Acceptance.MOL.Tests.CommonAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CommonAcceptanceTestFeaturesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CommonAcceptanceTestFeatures.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CommonAcceptanceTestFeatures", "As a User\r\nI want to manage all the MOL User related usecases \r\nso that I would v" +
                    "alidate all the MOL scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CommonAcceptanceTestFeatures")))
            {
                MMSG.Acceptance.MOL.Tests.CommonAcceptanceTestFeatures.CommonAcceptanceTestFeaturesFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as MOL user with valid user name and valid password")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLUserWithValidUserNameAndValidPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as MOL user with valid user name and valid password", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.Given("I access application URL as \"MOLUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
testRunner.When("I login as \"MOLUser\" with \"Valid username\" and \"Valid password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as MOL user with valid user name and invalid password")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLUserWithValidUserNameAndInvalidPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as MOL user with valid user name and invalid password", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
testRunner.Given("I access application URL as \"MOLUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
testRunner.When("I login as \"MOLUser\" with \"Valid username\" and \"Invalid password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.And("I should be displayed with \"InvalidPasswordError\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as MOL user with Invalid username and valid password")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLUserWithInvalidUsernameAndValidPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as MOL user with Invalid username and valid password", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
testRunner.Given("I access application URL as \"MOLUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
testRunner.When("I login as \"MOLUser\" with \"Invalid username\" and \"Valid password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.And("I should be displayed with \"InvalidUserNameError\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as MOL user with Invalid username and Invalid password")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLUserWithInvalidUsernameAndInvalidPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as MOL user with Invalid username and Invalid password", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
testRunner.Given("I access application URL as \"MOLUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
testRunner.When("I login as \"MOLUser\" with \"Invalid username\" and \"Invalid password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.And("I should be displayed with \"InvalidUserNameandPasswordError\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as MOL Wallet Transaction User")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLWalletTransactionUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as MOL Wallet Transaction User", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
testRunner.Given("I access application URL as \"MOLWalletTransactionUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
testRunner.When("I login as \"MOLWalletTransactionUser\" with \"Valid username\" and \"Valid password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as  MOL No Reimbursement")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLNoReimbursement()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as  MOL No Reimbursement", ((string[])(null)));
#line 51
this.ScenarioSetup(scenarioInfo);
#line 52
testRunner.Given("I access application URL as \"MOLNoReimbursement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
testRunner.When("I login as \"MOLNoReimbursement\" with \"Valid username\" and \"Valid password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Logout as MOL User")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LogoutAsMOLUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Logout as MOL User", ((string[])(null)));
#line 58
this.ScenarioSetup(scenarioInfo);
#line 59
testRunner.When("I click on Logout link as \"MOLUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Access activation site URL and activate Comet user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void AccessActivationSiteURLAndActivateCometUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access activation site URL and activate Comet user", ((string[])(null)));
#line 64
this.ScenarioSetup(scenarioInfo);
#line 65
testRunner.Given("I access application URL as \"MOLActivation\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
testRunner.When("I run the \"Disable\" Store proc to handel SMS validation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
testRunner.When("I enter \'Date of Birth\' and \'Card Activation Code\' of \"NewCOMETUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
testRunner.And("I click on Continue button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as Only VMS user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsOnlyVMSUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as Only VMS user", ((string[])(null)));
#line 73
this.ScenarioSetup(scenarioInfo);
#line 74
testRunner.Given("I access application URL as \"OnlyVMSUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
testRunner.When("I login as \"OnlyVMSUser\" with \"Valid username\" and \"Valid password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login As MOL Multiple Employeer Employee")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLMultipleEmployeerEmployee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login As MOL Multiple Employeer Employee", ((string[])(null)));
#line 80
this.ScenarioSetup(scenarioInfo);
#line 81
testRunner.Given("I access application URL as \"MOLMultipleEmployeerEmployee\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 82
testRunner.When("I login as \"MOLMultipleEmployeerEmployee\" with \"Valid username\" and \"Valid passwo" +
                    "rd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as MOL Active and Terminated Employeer Employee")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLActiveAndTerminatedEmployeerEmployee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as MOL Active and Terminated Employeer Employee", ((string[])(null)));
#line 87
this.ScenarioSetup(scenarioInfo);
#line 88
testRunner.Given("I access application URL as \"MOLActiveTerminatedEmployeerEmployee\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
testRunner.When("I login as \"MOLActiveTerminatedEmployeerEmployee\" with \"Valid username\" and \"Vali" +
                    "d password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as MOL Benefit merge with Employeer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLBenefitMergeWithEmployeer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as MOL Benefit merge with Employeer", ((string[])(null)));
#line 94
this.ScenarioSetup(scenarioInfo);
#line 95
testRunner.Given("I access application URL as \" MOLBenefitMergeWithEmployeer\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 96
testRunner.When("I login as \"MOLBenefitMergeWithEmployeer\" with \"Valid username\" and \"Valid passwo" +
                    "rd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as MOL Noveted Lease Benefit Single Title")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLNovetedLeaseBenefitSingleTitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as MOL Noveted Lease Benefit Single Title", ((string[])(null)));
#line 101
this.ScenarioSetup(scenarioInfo);
#line 102
testRunner.Given("I access application URL as \"MOLNovetedLeaseBenefitSingleTitle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 103
testRunner.When("I login as \"MOLNovetedLeaseBenefitSingleTitle\" with \"Valid username\" and \"Valid p" +
                    "assword\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as MOl Random Employee")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOlRandomEmployee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as MOl Random Employee", ((string[])(null)));
#line 108
this.ScenarioSetup(scenarioInfo);
#line 109
testRunner.Given("I access application URL as \"MOLRandomUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 110
testRunner.When("I login as \"MOLRandomUser\" with \"Valid username\" and \"Valid password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login as MOL Multiple Lease Packaing With TELSRA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonAcceptanceTestFeatures")]
        public virtual void LoginAsMOLMultipleLeasePackaingWithTELSRA()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login as MOL Multiple Lease Packaing With TELSRA", ((string[])(null)));
#line 115
this.ScenarioSetup(scenarioInfo);
#line 116
testRunner.Given("I access application URL as \"MOLMultipleLeasePackaingWithTELSRA\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 117
testRunner.When("I login as \"MOLMultipleLeasePackaingWithTELSRA\" with \"Valid username\" and \"Valid " +
                    "password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion