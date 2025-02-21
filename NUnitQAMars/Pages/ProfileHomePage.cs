using NUnit.Framework;
using NUnitQAMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitQAMars.Pages
{
    public class ProfileHomePage : CommonDriver
    {

        public void NavigatetoEducationTab()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//a[text()='Education']", 5);
            try
            {
                IWebElement EducationTab = driver.FindElement(By.XPath("//a[text()='Education']"));
                EducationTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to access Education");
            }
        }
        public void NavigatetoCertificationsTab()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//a[text()='Certifications']", 5);
            try
            {
                IWebElement CertificationsTab = driver.FindElement(By.XPath("//a[text()='Certifications']"));
                CertificationsTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to access Certifications");
            }
        }
    }
}
