
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnitQAMars.Pages;
using OpenQA.Selenium.Edge;
using System.Drawing.Imaging;
using AventStack.ExtentReports.Model;
using NUnit.Framework.Internal;



namespace NUnitQAMars.Utilities
{

    public class CommonDriver
    {
        public static IWebDriver driver;
        private LoginPage loginPageObj;
        private ProfileHomePage profileHomePageObj;
        private EducationPage educationPageObj;
        private CertificatePage certificatePageObj;
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        //public static ExtentSparkReporter htmlReporter;

        // private static string reportPath = "C:\\Users\\nir025\\Desktop\\ni\\IC\\ExtentReporter\\report.html"; //Report file path
        private static string reportPath = "extentReports.html";
        public static ExtentTest test;

        [OneTimeSetUp]
        public static void ExtentReportsSetup()
        {
                 
                if (extent == null)
                {
                    //var htmlReporter = new ExtentHtmlReporter("C:\\Users\\nir025\\Desktop\\ni\\IC\\ExtentReporter\\report.html");
                    htmlReporter = new ExtentHtmlReporter(reportPath);
                    //htmlReporter = new ExtentSparkReporter(reportPath);    
                    extent = new ExtentReports();
                    extent.AttachReporter(htmlReporter);
                    Console.WriteLine("ExtentReport initialized successfully.");
                }
                   
        }


        [SetUp]
        public void SetUpSteps()
        {
            try
            {
                //driver = new ChromeDriver();
                driver = new EdgeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

                // Initialize the page objects with the shared WebDriver instance
                loginPageObj = new LoginPage(driver);
                profileHomePageObj = new ProfileHomePage();
                educationPageObj = new EducationPage();
                certificatePageObj = new CertificatePage();

                // Perform the login action 
                loginPageObj.LoginActions();

                // Navigate to other pages as needed
                profileHomePageObj.NavigatetoEducationTab();
                educationPageObj.ClearData();
                profileHomePageObj.NavigatetoCertificationsTab();
                certificatePageObj.ClearCert();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Exception during WebDriver setup: {ex.Message}");
            }
        }
        public static ExtentReports GetExtent()
        {
            return extent;
        }
        public void CaptureScreenshot(string name)
        {
            try
            {
                // Take screenshot
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotPath = Path.Combine("C:\\Users\\nir025\\Desktop\\ni\\IC\\Screenshots", $"{Guid.NewGuid()}.png");
                test.AddScreenCaptureFromPath(screenshotPath);
                screenshot.SaveAsFile(screenshotPath);
                test.AddScreenCaptureFromPath(screenshotPath);  // Add screenshot to the report
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
        }


        //Start a test and log details

        public static void StartTest(string testName)
        {
           // if (extent == null)
           // {
                //throw new InvalidOperationException("ExtentReports is not initialized. Please ensure ExtentReportsSetup() is called before starting any tests.");
           // }
             test = extent.CreateTest(testName); // Start a new test in the report
        }
        

       // Log test success 
          public static void LogTestSuccess(string message)
         {
            if (test != null) test.Pass(message); //Log test pass message 

         }
        // log test failure 
        public static void LogTestFailure(string message)
        {
            if (test != null) 
                //test.Fail(message);//Log test info message
            test.Fail("details",
            MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
                    
        }
        public static void LogTestInfo(string message)
        {
            if (test != null)
                test.Info(message);//Log test info message
        }
        [OneTimeTearDown]
        public void ExentReportsTearDown()
        {
            try
            {
                // Ensure the report is written to the file
                extent.Flush();
                Console.WriteLine("Extent report flushed to disk.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during Extent Report Flush: " + ex.Message);
            }
        }

        
    }

}





