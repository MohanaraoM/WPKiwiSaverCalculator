using BoDi;
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
    public class KsCalculatorSteps : BaseSteps
    {
        private KsCalculatorPage _kscalcPage;
  
        public KsCalculatorSteps(ContextObject context, IObjectContainer container) : base(context, container.Resolve<ScenarioContext>())
        {
            ContextObj = context;
        }

        [Given(@"I Navigate to Calculator form page")]
        public void GivenIWantToNavigateToKiwiSavercalculatorsFormPage()
        {
            _kscalcPage = new KsCalculatorPage(ContextObj);
            _kscalcPage.clickHereToGetStarted();

        }
    }

}
