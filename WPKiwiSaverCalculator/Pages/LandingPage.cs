using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPKiwiSaverCalculator.DataModel;

namespace WPKiwiSaverCalculator.Pages
{
    public class LandingPage : GenericPage
    {
        private static readonly By _linkToKiwiSaver = By.LinkText("KiwiSaver");
        private static readonly By _linkToCalculator = By.LinkText("KiwiSaver calculators");
        public LandingPage(ContextObject contextobj) : base(contextobj)
        {
            
        }

        public void clickKiwiSaverCalculators()
        {
            contextObj.Driver.SwitchTo().DefaultContent();
            waitForElement(_linkToKiwiSaver,60);
            Actions action = new Actions(contextObj.Driver);
             action.MoveToElement(contextObj.Driver.FindElement(_linkToKiwiSaver));
            action.Perform();

            waitForElement(_linkToCalculator,60);

            try
            {
                contextObj.Driver.FindElement(_linkToCalculator).Click();

            }
                       catch (TimeoutException toe)
                        {

                contextObj.Driver.FindElement(_linkToCalculator).Click();
                      }
                       catch (Exception e)
                       {
                           throw (e);

                     }
                   }

            }


    }

