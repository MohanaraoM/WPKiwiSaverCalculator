using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPKiwiSaverCalculator.DataModel;

namespace WPKiwiSaverCalculator.Pages
{
    public class KsCalculatorPage : GenericPage
    {
        private static readonly By _linkTogetStarted = By.LinkText("Click here to get started.");

        public KsCalculatorPage(ContextObject contextobj) : base(contextobj)
        {

        }

        public void clickHereToGetStarted()
        {
            waitForElement(_linkTogetStarted, 60);
            contextObj.Driver.FindElement(_linkTogetStarted).Click();
        }
    }
}
