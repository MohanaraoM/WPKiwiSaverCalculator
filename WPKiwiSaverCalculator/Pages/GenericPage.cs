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
    public class GenericPage : BasePage
    {
        protected ContextObject contextObj;
     

        public GenericPage(ContextObject _contextobj) : base(_contextobj.Driver)
        {
            contextObj = _contextobj;
            contextObj.Driver.SwitchTo().DefaultContent();
        }

        public IWebElement waitForElement(By locator,double timeout)
        {
            IWebElement elm;
            WebDriverWait wait = new WebDriverWait(contextObj.Driver, TimeSpan.FromSeconds(timeout));
            elm=wait.Until(x => contextObj.Driver.FindElement(locator));
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

        public void clickElement(By locator)
        {
            IWebElement elm;
            WebDriverWait wait = new WebDriverWait(contextObj.Driver, TimeSpan.FromSeconds(60));
            elm = wait.Until(x => contextObj.Driver.FindElement(locator));
            elm.Click();
   
        }

        public IWebElement GetElement(By elem)
        {
    
                return contextObj.Driver.FindElement(elem);
        }

  




    }
}
