using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumVacanciesCounter.pages
{
    internal class VacanciesPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly string _url = "https://cz.careers.veeam.com/vacancies";
        private readonly By _departmentsDropdownBy = By.XPath("//*[@class='dropdown']//*[text()='All departments']");
        private readonly By _languageDropdownBy = By.XPath("//*[@class='dropdown']//*[text()='All languages']");
        private readonly By _jobSummaryBy = By.ClassName("card-sm");

        public VacanciesPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        internal void GoTo()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        internal void SelectDepartment(string department)
        {
            if (_driver.Url != _url)
                GoTo();

            _wait.Until(driver => driver.FindElement(_departmentsDropdownBy));

            IWebElement departmentDropdown = _driver.FindElement(_departmentsDropdownBy);
            departmentDropdown.Click();
            departmentDropdown.FindElement(By.XPath($"//*[text()='{department}']")).Click();
        }

        internal void SelectLanguage(string language)
        {
            if (_driver.Url != _url)
                GoTo();

            _wait.Until(driver => driver.FindElement(_languageDropdownBy));

            IWebElement languagesDropdown = _driver.FindElement(_languageDropdownBy);
            languagesDropdown.Click();
            languagesDropdown.FindElement(By.XPath($"//*[text()='{language}']")).Click();
            languagesDropdown.Click();
        }

        internal int GetAvailableVacanciesCount()
        {
            return _driver.FindElements(_jobSummaryBy).Count;
        }
    }
}
