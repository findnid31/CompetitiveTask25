using NUnitQAMars.Tests;
using NUnitQAMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NUnitQAMars.Pages
{
    public class EducationPage:CommonDriver
    {
        private static IWebElement addEducationButton => driver.FindElement(By.XPath("//div[@data-tab='third']//div[text()='Add New']"));
        private static IWebElement addCountryOfCollegeDropdown => driver.FindElement(By.XPath("//select[@name='country']"));
        private static IWebElement universityTextbox => driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));
        private static IWebElement titleDropdown => driver.FindElement(By.XPath("//select[@name='title']"));
        private static IWebElement degreeTextbox => driver.FindElement(By.XPath("//input[@placeholder='Degree']"));
        private static IWebElement yearOfGraduationDropdown => driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement editEducationButton => driver.FindElement(By.XPath("//div[@data-tab='third']//i[@class='outline write icon']"));
        private static IWebElement universityToBeEdited => driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));
        private static IWebElement degreeToBeEdited => driver.FindElement(By.XPath("//input[@placeholder='Degree']"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement deleteButton => driver.FindElement(By.XPath("//div[@data-tab='third']//i[@class='remove icon']"));

        private string newEducation;
        

        public class EducationRecord
        {
            public string Country { get; set; }
            public string University { get; set; }
            public string Title { get; set; }
            public string Degree { get; set; }
            public string Year { get; set; }
        }

        public void AddEducation(EducationRecord data)
        {
            
            Wait.WaitToBeVisible(driver, "XPath", "//div[@data-tab='third']//div[text()='Add New']", 8);

            //Click on Add Education button
            addEducationButton.Click();
            Thread.Sleep(3000);

            // Choose the Country of college/University dropdown
            addCountryOfCollegeDropdown.SendKeys(data.Country);
            addCountryOfCollegeDropdown.Click();

            // Add University textbox 
            universityTextbox.SendKeys(data.University);

            // Choose the Title dropdown
            titleDropdown.SendKeys(data.Title);

            // Add Degree textbox 
            degreeTextbox.SendKeys(data.Degree);

            // Choose the Year of graduation dropdown 
            yearOfGraduationDropdown.SendKeys(data.Year);

            //Click on Add button
            addButton.Click();
            Thread.Sleep(3000);

            newEducation = data.Degree;

        }
        public string getnewEducationfile()
        {
            return newEducation;
        }


        public void ClearData()
        {
            try
            {
                var deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='third']//i[@class='remove icon']"));
                foreach (var button in deleteButtons)
                {
                    button.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }

        }
        public void EditEducation(EducationRecord edata)
        {
            
            Wait.WaitToBeVisible(driver, "XPath", "//div[@data-tab='third']//i[@class='outline write icon']", 5);

            //Click on Edit Education button
            editEducationButton.Click();

            //Update University
            universityToBeEdited.Clear();
            universityToBeEdited.SendKeys(edata.University);

            //Update degree
            degreeToBeEdited.Clear();
            degreeToBeEdited.SendKeys(edata.Degree);


            //Click on Update button
            updateButton.Click();
            Thread.Sleep(2000);

            newEducation = edata.Degree;
        }

        public void DeleteEducation ()
        {
            
            Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='third']//i[@class='remove icon']", 7);

            //Click Delete button
            deleteButton.Click();
            Thread.Sleep(5000);

        }
    }
}
