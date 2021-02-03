using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WPKiwiSaverCalculator.DataModel;

namespace WPKiwiSaverCalculator.StepDefinitions
{
    [Binding]
    public class CommonSteps : BaseSteps
    {
        private IObjectContainer _container;
        private int _timeout = 30;
        public CommonSteps(ContextObject context, IObjectContainer container) : base(context, container.Resolve<ScenarioContext>())
        {
            _container = container;

    }

        [BeforeScenario]
        public void SetUp()
        {
            CopyAppSettingsToContext();
            SetupEnvironments();
            InitDriver();
          
        }

        private void CopyAppSettingsToContext()
        {

            ContextObj.browser = ConfigurationManager.AppSettings["Browser"];
            ContextObj.runOnGrid = Convert.ToBoolean(ConfigurationManager.AppSettings["RunOnGrid"]);
            ContextObj.URL = ConfigurationManager.AppSettings["URL"];
            ContextObj.testEnvironment = ConfigurationManager.AppSettings["testEnvironment"];
        }

        private void SetupEnvironments()
        {

            var scenarioContext = _container.Resolve<ScenarioContext>();
            var tags = scenarioContext.ScenarioInfo.Tags;
            ContextObj.environmentPath = @"Environment\environments.json";

            switch(ContextObj.testEnvironment.ToLower())
            {

                case "dev":
                        if (!tags.Contains("dev"))
                        Assert.Ignore("Ignoring test due to data unavailability");
                    break;
                case "qa":
                    if (!tags.Contains("qa"))
                        Assert.Ignore("Ignoring test due to data unavailability");
                    break;
                case "prod":
                    if (!tags.Contains("prod"))
                        Assert.Ignore("Ignoring test due to data unavailability");
                    break;
                default: throw new Exception($"no valid test environment {ContextObj.testEnvironment}");
            }

            //load test data

            switch (ContextObj.testEnvironment.ToLower())
            {
                case "dev":
                    ContextObj.testDataPath = @"TestData\DevData.Json";
                    break;
                case "qa":
                    ContextObj.testDataPath = @"TestData\QaData.Json";
                    break;
                case "prod":
                    ContextObj.testDataPath = @"TestData\ProdData.Json";
                    break;
                  default:throw new Exception($"no valid test environment {ContextObj.testEnvironment}");
            }
        }

        private void InitDriver()
        {
         
            ContextObj.Driver=ContextObj.runOnGrid?InitGrid():InitLocal();
            ContextObj.Driver.Manage().Window.Maximize();
            ContextObj.Driver.Navigate().GoToUrl(ContextObj.URL);
        }

        private IWebDriver InitLocal()
        {
           // var chromeOptions = new ChromeOptions();
            //var path= Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
           // chromeOptions.AddArgument(path);
            return new ChromeDriver();
      
        }

        private IWebDriver InitGrid()
        {
            //var chromeOptions = new ChromeOptions();
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //chromeOptions.AddArgument(path);
            return new ChromeDriver(path);

        }

        [AfterScenario]
        public void Cleanup()
        {

            ContextObj.Driver.Quit();
        }

        [BeforeStep]
        public void BeforeStepSaveStartTime()
        {

            ContextObj.lastStepStart = DateTime.Now;
        }

        //[AfterStep]
        //public void AfterStepOut()
        //{
        //    var scenarioContext = _container.Resolve<ScenarioContext>();
        //    var stepContext = scenarioContext.StepContext;
        //    var currentStepFullText = $"{stepContext.StepInfo.StepDefinitionType} {stepContext.StepInfo.Text}";
        //    var stepTable = stepContext.StepInfo.Table;
        //    if(stepTable!=null && !string.IsNullOrEmpty(stepTable.ToString()))
        //    {
        //        Console.WriteLine(stepTable);
        //    }
        //    var error = scenarioContext.TestError;
        //    var stepTimeInSec

        //}


    }
}
