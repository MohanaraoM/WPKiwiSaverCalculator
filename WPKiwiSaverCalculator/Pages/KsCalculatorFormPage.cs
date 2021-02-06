using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPKiwiSaverCalculator.DataModel;

namespace WPKiwiSaverCalculator.Pages
{
    public class KsCalculatorFormPage : GenericPage
    {

        private static readonly By _iframe = By.XPath("//iframe[contains(@src,'kiwisaver-calculator')]");
        private static readonly By _currentAgeIcon = By.XPath("//div[@help-id='CurrentAge']/button");
        private static readonly By _currentAgeHelptext = By.XPath(" //div[@help-id='CurrentAge']/button/preceding::p");
        private static readonly By _currentAgeTextBox = By.XPath("//div[@help-id='CurrentAge']//input");
        private static readonly By _employementStatusText = By.XPath("//div[@id='widget']/div/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div/div[1]");
        private static readonly By _employementStatusEmployedOption = By.XPath("//div[@id='widget']/descendant::span[text()='Employed']");
        private static readonly By _employementStatusSelfEmployedOption = By.XPath("//div[@id='widget']/descendant::span[text()='Self-employed']");
        private static readonly By _employementStatusNotEmployedOption = By.XPath("//div[@id='widget']/descendant::span[text()='Not employed']");
        private static readonly By _salaryPerYearText = By.XPath("//div[contains(@model,'AnnualIncome')]//input");
        private static readonly By _contribution3PercentageOption = By.XPath("//input[@type='radio' and @value='3']");
        private static readonly By _contribution4PercentageOption = By.XPath("//input[@type='radio' and @value='4']");
        private static readonly By _contribution8PercentageOption = By.XPath("//input[@type='radio' and @value='8']");
        private static readonly By _saverBalanceText = By.XPath("//div[contains(@model,'KiwiSaverBalance')]//input");
        private static readonly By _contributionsText = By.XPath("//div[contains(@model,'VoluntaryContributions')]//input");
        private static readonly By _riskProfileDefensiveOption = By.XPath("//div[@id='widget']/descendant::span[text()='Defensive']");
        private static readonly By _riskProfileConservativeOption = By.XPath("//div[@id='widget']/descendant::span[text()='Conservative']");
        private static readonly By _riskProfileBalancedOption = By.XPath("//div[@id='widget']/descendant::span[text()='Balanced']");
        private static readonly By _riskProfileGrowthOption = By.XPath("//div[@id='widget']/descendant::span[text()='Growth']");
        private static readonly By _savingGoalText = By.XPath("//div[contains(@model,'SavingsGoal')]//input");
        private static readonly By _submitButton = By.XPath("//button[contains(@class,'btn-results')]");
        private static readonly By _frequencySelectBox = By.XPath("//*[@id='widget']/div/div[1]/div/div[1]/div/div[4]/div/div/div/div[2]/div[1]/div[1]/div/div/div[1]/div[2]/div/div[1]/div");
        private static readonly By _frequencyFortnightlyOption = By.XPath("//div[@id='widget']/descendant::span[text()='Fortnightly']");
        private static readonly By _frequencyWeeklyOption = By.XPath("//div[@id='widget']/descendant::span[text()='Weekly']");
        private static readonly By _frequencyAnnuallyOption = By.XPath("//div[@id='widget']/descendant::span[text()='Annually']");
        private static readonly By _frequencyMonthlyOption = By.XPath("//div[@id='widget']/descendant::span[text()='Monthly']");
        private static readonly By _frequencyOneoffOption = By.XPath("//div[@id='widget']/descendant::span[text()='One-off']");
        private static readonly By _calculatedBalanceLabel = By.XPath("//span[contains(@class,'result-currency')]");

        private int _timeout = 60;


        public KsCalculatorFormPage(ContextObject contextobj) : base(contextobj)
        {

        }

        public void clickHereToGetStarted()
        {
            contextObj.Driver.SwitchTo().DefaultContent();
            waitForElement(_iframe, 60);
            var iframe = contextObj.Driver.FindElement(_iframe);
            contextObj.Driver.SwitchTo().Frame(iframe);
            contextObj.Driver.FindElement(_currentAgeIcon).Click();
        }

        public void ValidateCurrentAgeIconHelpText()
        {
            waitForElement(_currentAgeHelptext, 60);
            var currentAgehelptext = contextObj.Driver.FindElement(_currentAgeHelptext).Text;
            Assert.AreEqual("This calculator has an age limit of 18 to 64 years old.", currentAgehelptext);
        }
        public void calculateRetirementBalance(String currentAge, String employmentStatus, String salary,
            String contribution, String balance, String voluntaryContribution, String frequency,
            String riskProfile, String savingGoal)

        {
            SwitchToFrame();

            // Type the Current age
            GetElement(_currentAgeTextBox).SendKeys(currentAge);

            // section to select the Employment status.
            GetEmployeeStatus(employmentStatus);
            SelectContribution(employmentStatus, salary, contribution);

            // populate the Kiwisaver Balance
            if (!balance.Equals(""))
                GetElement(_saverBalanceText).SendKeys(balance);

            // populate the contributions Textbox
            if (!voluntaryContribution.Equals(""))
                GetElement(_contributionsText).SendKeys(voluntaryContribution);

            // populate the contribution frequency
            SelectFrequency(frequency);

            // Populate the risk Profile
            SelectRiskProfile(contribution, riskProfile);

            // Click on the Savings goal at retirement
            if (!savingGoal.Equals(null))
                GetElement(_savingGoalText).SendKeys(savingGoal);

            // click on the retirement projections button
            clickElement(_submitButton);

        }

        private void SwitchToFrame()
        {
            contextObj.Driver.SwitchTo().DefaultContent();
            waitForElement(_iframe, 60);
            var iframe = contextObj.Driver.FindElement(_iframe);
            contextObj.Driver.SwitchTo().Frame(iframe);
        }

        private void SelectRiskProfile(string contribution, string riskProfile)
        {
            if (riskProfile.Equals("Defensive"))
                clickElement(_riskProfileDefensiveOption);
            else if (riskProfile.Equals("Conservative"))
                clickElement(_riskProfileConservativeOption);
            else if (riskProfile.Equals("Balanced"))
                clickElement(_riskProfileBalancedOption);
            else if (riskProfile.Equals("Growth"))
                clickElement(_riskProfileGrowthOption);
            else
                Console.WriteLine("Invalid Risk Profile value" + contribution);
        }

        private void SelectFrequency(string frequency)
        {
            if (!frequency.Equals(""))
            {
                clickElement(_frequencySelectBox);

                // For Employed populate member contribution
                if (frequency.Equals("One-off"))
                    clickElement(_frequencyOneoffOption);
                else if (frequency.Equals("Weekly"))
                    clickElement(_frequencyWeeklyOption);
                else if (frequency.Equals("Fortnightly"))
                    clickElement(_frequencyFortnightlyOption);
                else if (frequency.Equals("Monthly"))
                    clickElement(_frequencyMonthlyOption);
                else if (frequency.Equals("Annually"))
                    clickElement(_frequencyAnnuallyOption);
            }
        }

        private void SelectContribution(string employmentStatus, string salary, string contribution)
        {
            if (employmentStatus.Equals("Employed"))
            {
                // For employed populate the salary per year
                EnterSalary(salary);
                // For Employed populate member contribution
                if (contribution.Equals("3%"))
                    clickElement(_contribution3PercentageOption);
                else if (contribution.Equals("4%"))
                    clickElement(_contribution4PercentageOption);
                else if (contribution.Equals("8%"))
                    clickElement(_contribution8PercentageOption);
                else
                    Console.WriteLine("Invalid contribution value" + contribution);

            }
        }

        private void EnterSalary(string salary)
        {
            waitForElement(_salaryPerYearText, _timeout);
            GetElement(_salaryPerYearText).SendKeys(salary);
        }

        private void GetEmployeeStatus(string employmentStatus)
        {
            if (!employmentStatus.Equals(null))
            {

                // the sleep is required as the dropdown is inactive but clickable
                Thread.Sleep(1000);
                clickElement(_employementStatusText);

                if (employmentStatus.Equals("Self-employed"))
                    clickElement(_employementStatusSelfEmployedOption);

                else if (employmentStatus.Equals("Not employed"))
                    clickElement(_employementStatusNotEmployedOption);

                else if (employmentStatus.Equals("Employed"))
                    clickElement(_employementStatusEmployedOption);
            }
        }

        public string GetCalculatedBalance()
        {
            waitForElement(_calculatedBalanceLabel, 60);
            return contextObj.Driver.FindElement(_calculatedBalanceLabel).Text;
        }

    }

}

