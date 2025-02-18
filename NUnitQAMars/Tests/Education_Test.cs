using Newtonsoft.Json;
using NUnit.Framework;
using NUnitQAMars.Pages;
using NUnitQAMars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.BiDi.Modules.Log;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace NUnitQAMars.Tests
{
    [TestFixture]
    public class EducationTest : CommonDriver
    {
        LoginPage loginPageObj;
        ProfileHomePage profileHomePageObj;
        EducationPage educationPageObj;

        public EducationTest()
        {
            profileHomePageObj = new ProfileHomePage();
            educationPageObj = new EducationPage();
        }

        [Test]

        
        public void CreateEducationTest()
        {
            profileHomePageObj.NavigatetoEducationTab();
            CommonDriver.StartTest("CreateEducationTest");
         //   CommonDriver.LogTestInfo("CreateEducationTest started");
            TestContext.WriteLine("Running CreateEducationTest");
            var educationRecords = LoadEducationData("C:\\Users\\nir025\\Desktop\\ni\\IC\\Test cases\\CreateEdu.json");

            foreach (var data in educationRecords)
            {
                educationPageObj.AddEducation(data);

                // Verify the newly added education record
                string newEducationFile = educationPageObj.getnewEducationfile();
                string expectedEducation = data.Degree;

                // Check if the expected education matches the new education added
                Assert.That(newEducationFile.Trim().ToLower(), Is.EqualTo(expectedEducation.Trim().ToLower()));
            }
        //    CommonDriver.LogTestSuccess("CreateEducationTest passed");

            // Delete the education record
            educationPageObj.ClearData();
        }

        private static List<EducationPage.EducationRecord> LoadEducationData(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<EducationPage.EducationRecord>>(jsonData);
        }



        [Test]
        public void EditEducationTest()
        {
            profileHomePageObj.NavigatetoEducationTab();
            {
                CommonDriver.StartTest("EditEducationTest");
           //     CommonDriver.LogTestInfo("EditEducationTest started");
                TestContext.WriteLine("Running EditEducationTest");
                //Add education record
                var educationRecords = LoadNewEducationData("C:\\Users\\nir025\\Desktop\\ni\\IC\\Test cases\\EditEdu.json");

                foreach (var data in educationRecords)
                {
                    // educationPageObj.ClearData();
                    educationPageObj.AddEducation(data);

                }
                //Edit education record
                var editRecords = LoadNewEducationData("C:\\Users\\nir025\\Desktop\\ni\\IC\\Test cases\\EditEducationData.json");
                foreach (var edata in editRecords)
                {
                    educationPageObj.EditEducation(edata);

                    //Verify education record update

                    string editEducationFile = educationPageObj.getnewEducationfile();
                    string expectedEducation = edata.Degree;
                    
                    // Check if the expected education matches the edited education 
                    Assert.That(editEducationFile.Trim().ToLower(), Is.EqualTo(expectedEducation.Trim().ToLower()));
                }

                //Delete education record

                {
                   educationPageObj.ClearData();
                }

            }
        }
        private static List<EducationPage.EducationRecord> LoadNewEducationData(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<EducationPage.EducationRecord>>(jsonData);
        }

    
        [Test]
        public void DeleteEducationTest()
        {
            profileHomePageObj.NavigatetoEducationTab();
            {
                //Add education record
                var educationRecords = LoadEducationData("C:\\Users\\nir025\\Desktop\\ni\\IC\\Test cases\\DeleteEdu.json");

                foreach (var data in educationRecords)
                {
                    educationPageObj.AddEducation(data);
                }
                //Delete education record

                foreach (var data in educationRecords)
                {
                    educationPageObj.DeleteEducation();
                }
            }
            {
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 7);

                //Verify if confirmation pop up is seen for delete

                IWebElement delPopupMsg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                string popupMsgBox = delPopupMsg.Text;
                Console.Write(delPopupMsg);
                string popupMsgDel = " successfully removed";
                Assert.That(popupMsgBox, Does.Contain(popupMsgDel), "Actual value and expected value donot match");

            }
        }

        [TearDown]
        public void CloseTestRun()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}


