using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPKiwiSaverCalculator.DataModel
{
   public class ContextObject
    {
        public string testResultPath { get; set; }
        public string testDataPath { get; set; }
        public string URL { get; set; }
        public bool runOnGrid { get; set; }
        public string gridMachine { get; set; }
        public string gridBrowserVersion { get; set; }
        public string environmentFile;
        public string testEnviornment { get; set; }
        public string enviornmentPath { get; set; }
        public string browser { get; set; }
        public IWebDriver Driver { get; set; }
        public Verify verify { get; set; }
        public DateTime lastStepStart { get; set; }
    }
}
