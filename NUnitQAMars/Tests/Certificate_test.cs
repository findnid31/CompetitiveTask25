using Newtonsoft.Json;
using NUnit.Framework;
using NUnitQAMars.Pages;
using NUnitQAMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace NUnitQAMars.Tests
{
    [TestFixture]
    public class Certificatetest : CommonDriver
    {
        //LoginPage loginPageObj;
        ProfileHomePage profileHomePageObj;
        CertificatePage certificatePageObj;
        private static ExtentReports extent;
        public ExtentTest test;

        public Certificatetest()
        {
            //loginPageObj = new LoginPage();
            profileHomePageObj = new ProfileHomePage();
            certificatePageObj = new CertificatePage();
        }


        [Test, Order(1)]

        public void CreateCertificateTest()
        {
            CommonDriver.ExtentReportsSetup();
            extent = CommonDriver.GetExtent();
            //  CommonDriver.StartTest("CreateCertificateTest");
            //  CommonDriver.LogTestInfo("CreateCertificateTest started");
            //  TestContext.WriteLine("Running CreateCertificateTest");
            var certificateRecords = LoadCertificateData("C:\\Users\\nir025\\Desktop\\ni\\IC\\Test cases\\CreateCertificate.json");
            try
            {
                foreach (var data in certificateRecords)
                {
                    certificatePageObj.AddCertificate(data);

                    //Verify certificate record creation
                    string newCertificateFile = certificatePageObj.getnewCertificatefile();
                    string expectedCertificate = data.Certificate;

                    Assert.That(newCertificateFile.Trim().ToLower(), Is.EqualTo(expectedCertificate.Trim().ToLower()));
//                    test.Pass("Test passed successfully.");

                }
               // CommonDriver.LogTestSuccess("CreateCertificateTest passed");

                //Delete certificate record
                for (int i = 0; i < 1; i++)
                {
                    certificatePageObj.DeleteCertificate();
                }

            }
            catch (Exception ex)
            {
              //  test.Fail("Test failed with exception: ");
               // string screenshotPath = CaptureScreenshot(TestContext.CurrentContext.Test.Name);
                //test.AddScreenCaptureFromPath(screenshotPath); // Attach screenshot on failure
                throw;
            }
            }
       private static List<CertificatePage.CertificateRecord> LoadCertificateData(string filePath)
        {
          var jsonData = File.ReadAllText(filePath);
          return JsonConvert.DeserializeObject<List<CertificatePage.CertificateRecord>>(jsonData);
        }

        [Test, Order(2)]
        public void EditCertificateTest()
        {
            CommonDriver.StartTest("EditCertificateTest");
          //  CommonDriver.LogTestInfo("EditCertificateTest started");
            TestContext.WriteLine("Running EditCertificateTest");

            //Add certificate record
            var certificateNewRecords = LoadNewCertificateData("C:\\Users\\nir025\\Desktop\\ni\\IC\\Test cases\\EditCert.json");

            foreach (var data in certificateNewRecords)
            {
                certificatePageObj.AddCertificate(data);

            }
            //Edit certificate record
            var editRecords = LoadNewCertificateData("C:\\Users\\nir025\\Desktop\\ni\\IC\\Test cases\\EditCertificate.json");
            foreach (var edata in editRecords)
            {
                certificatePageObj.EditCertificate(edata);

                //Verify certificate record update

                string newCertificateFile = certificatePageObj.getnewCertificatefile();
                string expectedCertificate = edata.Certificate;
            
            Assert.That(newCertificateFile.Trim().ToLower(), Is.EqualTo(expectedCertificate.Trim().ToLower()));
            }
                //Delete certificate record
                for (int i = 0; i < 1; i++)
                {
                    certificatePageObj.DeleteCertificate();
                }
            
            }
            private static List<CertificatePage.CertificateRecord> LoadNewCertificateData(string filePath)
            {
                var jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<CertificatePage.CertificateRecord>>(jsonData);
            }
            [Test, Order(3)]
            public void DeleteCertificateTest()
            {
                {
                    //Add certificate record
                    var certificateRecords = LoadNewCertificateData("C:\\Users\\nir025\\Desktop\\ni\\IC\\Test cases\\DeleteCertificate.json");

                    foreach (var data in certificateRecords)
                    {
                        certificatePageObj.AddCertificate(data);

                    }
                    //Delete certificate record

                    foreach (var data in certificateRecords)
                    {
                        certificatePageObj.DeleteCertificate();

                    }
                }
                {
                    Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 7);

                    //Verify if confirmation pop up is seen for delete

                    IWebElement delPopupMsg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                    string popupMsgBox = delPopupMsg.Text;
                    Console.Write(delPopupMsg);
                    string popupMsgDel = " has been deleted from your certification";
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




