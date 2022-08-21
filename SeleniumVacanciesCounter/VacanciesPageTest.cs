using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumVacanciesCounter.pages;
using System;

namespace SeleniumVacanciesCounter
{
    public class VacanciesPageTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("C:\\Programs");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestCase("Research & Development", "English", ExpectedResult = 13)]
        [TestCase("IT", "English", ExpectedResult = 3)]
        [TestCase("HR", "Russian", ExpectedResult = 1)]
        [TestCase("Corporate Information Systems", "French", ExpectedResult = 0)]
        public int VacanciesAvailabaleCountTest(string department, string language)
        {
            var vacanciesPage = new VacanciesPage(driver);

            vacanciesPage.SelectDepartment(department);
            vacanciesPage.SelectLanguage(language);

            return vacanciesPage.GetAvailableVacanciesCount();      
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Dispose();
        }
    }
}