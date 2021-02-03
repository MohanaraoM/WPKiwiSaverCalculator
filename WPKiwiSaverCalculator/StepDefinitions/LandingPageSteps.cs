using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
    public class LandingPageSteps : BaseSteps
    {
  

        private static readonly By linkToCalculator = By.LinkText("KiwiSaver calculators");
  
        LandingPage landing;
        CalculatorPage calculator;
        CalculatorFormPage forms;
        IWebDriver driver;
        private LandingPageSteps _landingPage;
        private readonly ContextObject _contextLocal;

        public LandingPageSteps(ContextObject context, ScenarioContext scenarioContext) : base(context, scenarioContext)
        {

            _contextLocal = context;
        }

        

        [Given(@"I want to navigate to KiwiSavercalculcvxcvators page")]
        public void GivenIWantToNavigateToKiwiSavercalculatorsPage()
        {
            //landing = new LandingPage(ContextObj.Driver);
           // calculator = new CalculatorPage(ContextObj.Driver);

           // clickKiwiSaverCalculator();
            calculator.clickGetStartedCalculator();
            //clickKiwiSaverCalculators();
        }

       

    }
}
