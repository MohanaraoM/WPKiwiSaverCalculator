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
     

        public GenericPage(ContextObject _contextobj) : base(_contextobj.Driver)
        {
            contextObj = _contextobj;
            contextObj.Driver.SwitchTo().DefaultContent();
        }

       
    }
}
