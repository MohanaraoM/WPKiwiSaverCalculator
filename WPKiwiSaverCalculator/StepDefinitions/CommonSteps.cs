using BoDi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WPKiwiSaverCalculator.DataModel;

namespace WPKiwiSaverCalculator.StepDefinitions
{
    [Binding]
    public class CommonSteps : BaseSpecSteps
    {
        private IObjectContainer _container;
        private ScenarioContext _scenarioContext;
        private ContextObject ContextLocal;
        public CommonSteps(ContextObject context, IObjectContainer container,ScenarioContext scenarioContext) : base(context, container.Resolve<ScenarioContext>())
        {
            ContextLocal = context;
            _container = container;
            _scenarioContext = scenarioContext;

    }

        [BeforeScenario]
        public void SetUp()
        {
            CopyAppSettingsToContext();
          
        }

        private void CopyAppSettingsToContext()
        {

            ContextObj.browser = ConfigurationManager.AppSettings["Browser"];
            ContextObj.runOnGrid = Convert.ToBoolean(ConfigurationManager.AppSettings["RunOnGrid"]);
            ContextObj.URL = ConfigurationManager.AppSettings["URL"];
        }



}
}
