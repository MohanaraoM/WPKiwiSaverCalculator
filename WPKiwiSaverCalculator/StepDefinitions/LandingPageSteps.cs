using BoDi;
using System;
using TechTalk.SpecFlow;
using WPKiwiSaverCalculator.DataModel;
using WPKiwiSaverCalculator.Pages;

namespace WPKiwiSaverCalculator.StepDefinitions
{
    [Binding]
    public class LandingPageSteps : BaseSteps
    {
        private LandingPage _landingPage;

        public LandingPageSteps(ContextObject context, IObjectContainer container) : base(context, container.Resolve<ScenarioContext>())
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
