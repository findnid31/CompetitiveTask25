using NUnitQAMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitQAMars.Pages
{
    public class CertificatePage :CommonDriver
    {
        private static IWebElement addCertificateButton => driver.FindElement(By.XPath("//div[@data-tab='fourth']//div[text()='Add New']"));
        private static IWebElement certificateTextbox => driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
        private static IWebElement certificateFrom => driver.FindElement(By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']"));
        private static IWebElement yearDropdown => driver.FindElement(By.XPath("//select[@name='certificationYear']"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement editCertificateButton => driver.FindElement(By.XPath("//div[@data-tab='fourth']//i[@class='outline write icon']"));
        private static IWebElement updateCertificateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement deleteCertificateButton => driver.FindElement(By.XPath("//div[@data-tab='fourth']//i[@class='remove icon']"));
        private string newCertificateFile;

        public class CertificateRecord
        { 
            public string Certificate { get; set; }
            public string From { get; set; }
            public string Year { get; set; }
        }

        public void AddCertificate(CertificateRecord data) 
        { 
         Wait.WaitToBeVisible(driver, "XPath", "//div[@data-tab='fourth']//div[text()='Add New']", 5);

            //click on add certificate button
            addCertificateButton.Click();
            Thread.Sleep(1000);

            //Add certificate details
            certificateTextbox.SendKeys(data.Certificate);
            certificateFrom.SendKeys(data.From);
            yearDropdown.SendKeys(data.Year);

            addButton.Click();
            Thread.Sleep(1000);

            newCertificateFile = data.Certificate;

        }

        public string getnewCertificatefile()
        {
            return newCertificateFile;  
        }

        public void ClearCert()
          {
                try
                {
                    var deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='fourth']//i[@class='remove icon']"));
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

        public void EditCertificate(CertificateRecord edata) 
        { 
        Wait.WaitToBeVisible(driver, "XPath", "//div[@data-tab='fourth']//i[@class='outline write icon']", 5);
            //Click on Edit certificate button
            editCertificateButton.Click();
            Thread.Sleep(1000);

            //Update year
            yearDropdown.SendKeys(edata.Year);

            //Click on update button
            updateCertificateButton.Click();
            Thread.Sleep(1000);

            newCertificateFile = edata.Certificate;

        }

        public void DeleteCertificate()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@data-tab='fourth']//i[@class='remove icon']", 5);
            deleteCertificateButton.Click();
            Thread.Sleep(1000);
        }

        
    }
}
