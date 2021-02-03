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
    [Binding]
    public class RetirementCalculatorInformationIconSteps : BaseSteps
    {
        IWebDriver driver;
        private readonly ContextObject _contextLocal;
        [Given(@"I want to navigate to KiwiSavercalculators page")]
        public void GivenIWantToNavigateToKiwiSavercalculatorsPage()
        {
            clickKiwiSaverCalculator();
            //calculator.clickGetStartedCalculator();
        }

        public RetirementCalculatorInformationIconSteps(ContextObject context, ScenarioContext scenarioContext) : base(context, scenarioContext)
        {

            _contextLocal = context;
        }

        public void clickKiwiSaverCalculator()
        {
            Actions action = new Actions(driver);
            IWebElement linkToKiwiSaver = driver.FindElement(By.LinkText("KiwiSaver"));
            IWebElement linkToCalculator = driver.FindElement(By.LinkText("KiwiSaver calculators"));
            action.MoveToElement(linkToKiwiSaver);
            action.Perform();

            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));

            //Click on the KiwiSaver Link in the home page
            try
            {

                driver.FindElement(By.LinkText("KiwiSaver calculators")).Click();

            }
            catch (TimeoutException toe)
            {

                WaitForElement(By.LinkText("KiwiSaver calculators"), 10);

                driver.FindElement(By.LinkText("KiwiSaver calculators")).Click();

            }
            catch (Exception e)
            {

                throw (e);

            }
        }

        public IWebElement WaitForElement(By locator, double timeout)
        {
            IWebElement elm;

            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            elm = wait.Until(element => element.FindElement(locator));
            wait.Until(d =>
            {

                if (elm != null)
                {
                    return elm.Displayed;
                }
                else return false;
            });

            return elm;
        }

    }
}
