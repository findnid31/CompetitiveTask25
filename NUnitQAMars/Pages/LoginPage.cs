using NUnitQAMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NUnitQAMars.Pages
{
    /*public class LoginPage 
    {
        private IWebDriver driver;

        private static IWebElement signIn => driver.FindElement(By.XPath("//a[@class='item']"));
        private static IWebElement emailAddress => driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
        private static IWebElement passwordTextbox => driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        private static IWebElement loginButton => driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));



        //Functions that allow users to Login to QA  mars
        public void LoginActions()
        {
            //Launch QA mars Portal
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            //Identify Sign in and Click on Sign In
            signIn.Click();
            Thread.Sleep(2000);

            //Identify Email address textbox and enter valid email 
            emailAddress.SendKeys("t9nidhi@gmail.com");

            //Identify password textbox and enter valid password 
            passwordTextbox.SendKeys("Pass@2020");

            //Identify Login Button and Click on it
            loginButton.Click();
            Thread.Sleep(2000);

        }
    }*/

    public class LoginPage
    {
        private IWebDriver driver;

        private IWebElement signIn => driver.FindElement(By.XPath("//a[@class='item']"));
        private IWebElement emailAddress => driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
        private IWebElement passwordTextbox => driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver; // Inject the shared WebDriver instance
        }

        public void LoginActions()
        {
            // Launch QA mars Portal
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            // Identify Sign in and click on Sign In
            signIn.Click();
            Thread.Sleep(2000);

            // Identify Email address textbox and enter valid email 
            emailAddress.SendKeys("t9nidhi@gmail.com");

            // Identify password textbox and enter valid password 
            passwordTextbox.SendKeys("Pass@2020");

            // Identify Login Button and click on it
            loginButton.Click();
            Thread.Sleep(2000);
        }
    }

}


