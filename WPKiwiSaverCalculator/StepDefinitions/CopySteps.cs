using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WPKiwiSaverCalculator.DataModel;

namespace WPKiwiSaverCalculator.StepDefinitions
{
    [Binding]
    public class CopySteps :BaseSteps
    {
       // private CopyPage _copyPage;
        private readonly ContextObject _contextLocal;

        public CopySteps(ContextObject context, ScenarioContext scenarioContext) : base(context, scenarioContext)
        {

            _contextLocal = context;
        }

        [Given(@"I want to navigate to Westpac NZ")]
        public void GivenIWantToNavigateToWestpacNZ()
        {
            Console.WriteLine("test");
        }


       


        [Given(@"Navigate to Calculator form page")]
        public void GivenNavigateToCalculatorFormPage()
        {
            Console.WriteLine("test");
        }


        [When(@"I click on the help icon next to Current age textbox")]
        public void WhenIClickOnTheHelpIconNextToCurrentAgeTextbox()
        {
            Console.WriteLine("test");
        }

        [Then(@"Help Messgae is shown on page")]
        public void ThenHelpMessgaeIsShownOnPage()
        {
            Console.WriteLine("test");
        }
    }
}
