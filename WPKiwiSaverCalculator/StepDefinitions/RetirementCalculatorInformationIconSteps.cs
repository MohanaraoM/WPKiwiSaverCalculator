using BoDi;
using System;
using TechTalk.SpecFlow;
using WPKiwiSaverCalculator.DataModel;
using WPKiwiSaverCalculator.Pages;

namespace WPKiwiSaverCalculator.StepDefinitions
{
    [Binding]
    public class RetirementCalculatorInformationIconSteps : BaseSteps
    {
        private LandingPage _landingPage;
        private readonly ContextObject _contextLocal;

        public RetirementCalculatorInformationIconSteps(ContextObject context, IObjectContainer container) : base(context, container.Resolve<ScenarioContext>())
        {
            ContextObj = context;
        }

        [Given(@"I want to navigate to KiwiSavercalculators page")]
        public void GivenIWantToNavigateToKiwiSavercalculatorsPage()
        {
            _landingPage = new LandingPage(ContextObj);
            _landingPage.clickKiwiSaverCalculators();

        }
    }
}
