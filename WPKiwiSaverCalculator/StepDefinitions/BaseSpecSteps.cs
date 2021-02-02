using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WPKiwiSaverCalculator.DataModel;

namespace WPKiwiSaverCalculator.StepDefinitions
{
    public class BaseSpecSteps
    {
        protected ContextObject ContextObj;
        protected ScenarioContext ScenarioContext;



        public BaseSpecSteps(ContextObject context, ScenarioContext scenarioContext)
        {

            ContextObj = context;
            ScenarioContext = scenarioContext;
        }
}

}
