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
namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class EmployeePersonalDetailsManagementFeatureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EmployeePersonalDetailsManagementFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EmployeePersonalDetailsManagementFeature", "This feature file contains all the scenarios related to employee personal details" +
                    "", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "EmployeePersonalDetailsManagementFeature")))
            {
                MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestFeatures.EmployeePersonalDetailsManagementFeatureFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User Reset the password")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EmployeePersonalDetailsManagementFeature")]
        public virtual void UserResetThePassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User Reset the password", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.Given("I access application URL as \"MOLWalletTransactionUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
testRunner.When("I run the \"Disable\" Store proc to handel SMS validation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.When("I click on Button \"Forgot your password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.Then("I should be on \"ForgotPassword\" url of \"Maxxia Online.\"Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
testRunner.When("I enter the \"UserId\" of \"MOLWalletTransactionUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
testRunner.And("I click on \"Submit UserID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
testRunner.Then("I should view New password and Reenter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
testRunner.When("I enter New Password and Confirm password in text box as \"MOLWalletTransactionUse" +
                    "r\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.And("I click on \"getCode\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.When("I enter the \"SMSCode\" of \"MOLWalletTransactionUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
testRunner.And("I click on \"Submit\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.And("I should be displayed with \"Your password has been successfully changed\" message " +
                    "for \"MOLWalletTransactionUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.When("I run the \"Enable\" Store proc to handel SMS validation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Employee Personal details validation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EmployeePersonalDetailsManagementFeature")]
        public virtual void EmployeePersonalDetailsValidation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Employee Personal details validation", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
testRunner.When("I click on \"Setting\" option in \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
testRunner.When("I enter \"Empty\" in \"Personal Email address\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
testRunner.Then("I should be displayed with \"Empty\" message in \"Personal Email address\" textbox of" +
                    " \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
testRunner.When("I enter \"Invalid\" in \"Personal Email address\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.Then("I should be displayed with \"Invalid\" message in \"Personal Email address\" textbox " +
                    "of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.When("I enter \"Valid\" in \"Personal Email address\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.When("I enter \"Empty\" in \"Home phone\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I should be displayed with \"Empty\" message in \"Home phone\" textbox of \"Maxxia Onl" +
                    "ine\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.When("I enter \"Invalid\" in \"Home phone\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("I should be displayed with \"Invalid\" message in \"Home phone\" textbox of \"Maxxia O" +
                    "nline\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
testRunner.When("I enter \"Valid\" in \"Home phone\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
testRunner.When("I enter \"Empty\" in \"Mobile\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.Then("I should be displayed with \"Empty\" message in \"Mobile\" textbox of \"Maxxia Online\"" +
                    " page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
testRunner.When("I enter \"Invalid\" in \"Mobile\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
testRunner.Then("I should be displayed with \"Invalid\" message in \"Mobile\" textbox of \"Maxxia Onlin" +
                    "e\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
testRunner.When("I enter \"Valid\" in \"Mobile\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
testRunner.When("I enter \"Empty\" in \"Suburb\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
testRunner.Then("I should be displayed with \"Empty\" message in \"Suburb\" textbox of \"Maxxia Online\"" +
                    " page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
testRunner.When("I enter \"Invalid\" in \"Suburb\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
testRunner.Then("I should be displayed with \"Invalid\" message in \"Suburb\" textbox of \"Maxxia Onlin" +
                    "e\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
testRunner.When("I enter \"Valid\" in \"Suburb\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
testRunner.When("I enter \"Empty\" in \"Post Code\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
testRunner.Then("I should be displayed with \"Empty\" message in \"Post Code\" textbox of \"Maxxia Onli" +
                    "ne\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
testRunner.When("I enter \"Invalid\" in \"Post Code\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
testRunner.Then("I should be displayed with \"Invalid\" message in \"Post Code\" textbox of \"Maxxia On" +
                    "line\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
testRunner.When("I enter \"Valid\" in \"Post Code\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
testRunner.When("I enter \"Empty\" in \"Peninsula Health\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
testRunner.Then("I should be displayed with \"Empty\" message in \"Peninsula Health\" textbox of \"Maxx" +
                    "ia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
testRunner.When("I enter \"Invalid\" in \"Peninsula Health\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
testRunner.Then("I should be displayed with \"Invalid\" message in \"Peninsula Health\" textbox of \"Ma" +
                    "xxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
testRunner.When("I enter \"Valid\" in \"Peninsula Health\" textbox of \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify  Communication preferences conatins all the check box are been checked")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EmployeePersonalDetailsManagementFeature")]
        public virtual void VerifyCommunicationPreferencesConatinsAllTheCheckBoxAreBeenChecked()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify  Communication preferences conatins all the check box are been checked", ((string[])(null)));
#line 71
this.ScenarioSetup(scenarioInfo);
#line 72
testRunner.When("I click on \"Setting\" option in \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
testRunner.Then("I should be on \"Maxxia Online\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
testRunner.When("I click on the link \"Communication preferences\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
testRunner.Then("I should be on \"communicationpreferences\" url of \"Maxxia Online\"Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
testRunner.Then("I should view the \"Please send me a reminder when I need to provide a receipt/doc" +
                    "umentation for a claim\" check box checked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
testRunner.Then("I should view the \"Please send me an email confirmation when payments are made fr" +
                    "om my salary packaging account. \" check box checked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 78
testRunner.Then("I should view the \"Please do not send me any marketing materials.\" check box chec" +
                    "ked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
