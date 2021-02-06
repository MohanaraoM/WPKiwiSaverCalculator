using BoDi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WPKiwiSaverCalculator.DataModel;
using WPKiwiSaverCalculator.Pages;

namespace WPKiwiSaverCalculator.StepDefinitions
{
    [Binding]
    public class KsCalculatorFormSteps : BaseSteps
    {
        private KsCalculatorFormPage _kscalcformPage;
        private readonly ContextObject _contextLocal;

        public KsCalculatorFormSteps(ContextObject context, IObjectContainer container) : base(context, container.Resolve<ScenarioContext>())
        {
            ContextObj = context;
            _kscalcformPage = new KsCalculatorFormPage(ContextObj);
        }

        [When(@"I click on the help icon next to Current age textbox")]
        public void WhenIClickOnTheHelpIconNextToCurrentAgeTextbox()
        {
            _kscalcformPage = new KsCalculatorFormPage(ContextObj);
            _kscalcformPage.clickHereToGetStarted();
            _kscalcformPage.ValidateCurrentAgeIconHelpText();

        }

        [Then(@"Help Messgae is shown on page")]
        public void ThenHelpMessageIsShownOnPage()
        {
             _kscalcformPage.ValidateCurrentAgeIconHelpText();

        }

        [When(@"I fill in '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenIFillInHigh(string currentAge, string employmentStatus, string salary, string contribution,
           string balance, string voluntaryContribution, string frequency, string riskProfile,string savingGoal)
        {
            _kscalcformPage.calculateRetirementBalance(currentAge, employmentStatus, salary, contribution, balance,
                voluntaryContribution, frequency, riskProfile, savingGoal);
        }

       
        [Then(@"I should get calculated projected balances '(.*)'")]
        public void ThenIShouldGetCalculatedProjectedBalances(string expectedBalance)
        {
            var ActualBalance = _kscalcformPage.GetCalculatedBalance();

            Assert.AreEqual(expectedBalance, ActualBalance.Replace("\r\n", ""));
        }



    }

}
