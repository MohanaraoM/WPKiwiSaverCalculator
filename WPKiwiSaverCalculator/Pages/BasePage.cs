using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPKiwiSaverCalculator.Pages
{
    public class BasePage
    {
        //public BasePage(IWebDriver driver) : base(driver)
        //{

        //}

        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
