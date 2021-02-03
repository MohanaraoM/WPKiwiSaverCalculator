using OpenQA.Selenium;
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
        private IWebDriver driver;

        public GenericPage(ContextObject _contextobj) : base(_contextobj.Driver)
        {
            contextObj = _contextobj;
        }

        //    public GenericPage(IWebDriver driver)
        //    {
        //        this.driver = driver;
        //    }
        //}
    }
}
