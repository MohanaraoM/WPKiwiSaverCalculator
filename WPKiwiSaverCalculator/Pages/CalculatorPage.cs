﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPKiwiSaverCalculator.Pages
{
    class CalculatorPage
    {
        private IWebDriver driver;

        public CalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void clickGetStartedCalculator()
        {
            throw new NotImplementedException();
        }
    }
}
