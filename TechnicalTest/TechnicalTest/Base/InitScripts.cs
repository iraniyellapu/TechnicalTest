using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


namespace TechnicalTest.Base
{
    [TestFixture]
    public class InitScripts
    {
        IWebDriver driver;
        IWebElement element;
        public string strURL = FrameworkSettings.URL;
     


        [SetUp]
        public void OpenBrowser()
        {
            driver = Driver.getDriver();

            driver.Navigate().GoToUrl(strURL);

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }



        [Test]
        
        public void NavigateToAbout()
        {
          
            //Click on burger menu on home page.
            element = driver.FindElement(By.CssSelector(".icon-menu"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);

            //Click on the About Menu Item
            element =  driver.FindElement(By.XPath("//button[contains(.,'About')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Build().Perform();
            element.SendKeys(Keys.Enter);
                        
            string MenuItemXpath = "//div[@class= 'site-nav__main__items active']//h3";
            IWebElement h3Element = driver.FindElement(By.XPath(MenuItemXpath));
            string strTitle =  h3Element.Text;

            Assert.AreEqual("About", strTitle, "Navigated To AboutPage");
        }

        [Test]
        
        public void NavigateToWork()
        {

            //Click on burger menu on home page.
            element = driver.FindElement(By.CssSelector(".icon-menu"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);

            //Click on the Work Menu Item
            element = driver.FindElement(By.XPath("//button[contains(.,'Work')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Build().Perform();
            element.SendKeys(Keys.Enter);

            string MenuItemXpath = "//div[@class= 'site-nav__main__items active']//h3";
            IWebElement h3Element = driver.FindElement(By.XPath(MenuItemXpath));
            string strTitle = h3Element.Text;

            Assert.AreEqual("Work", strTitle, "Navigated To WorkPage");
        }

        [Test]
        public void NavigateToServices()
        {

            //Click on burger menu on home page.
            element = driver.FindElement(By.CssSelector(".icon-menu"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);

            //Click on the Services Menu Item
            element = driver.FindElement(By.XPath("//button[contains(.,'Services')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Build().Perform();
            element.SendKeys(Keys.Enter);

            string MenuItemXpath = "//div[@class= 'site-nav__main__items active']//h3";
            IWebElement h3Element = driver.FindElement(By.XPath(MenuItemXpath));
            string strTitle = h3Element.Text;

            Assert.AreEqual("Services", strTitle, "Navigated To ServicesPage");
        }



        [Test]
        
        public void CountValtechOffices()
        {

            //Click on burger menu on home page.
            element = driver.FindElement(By.CssSelector(".icon-menu"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);

            //Click on the About Menu Item
            element = driver.FindElement(By.XPath("//a[contains(.,'Contact Us')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Build().Perform();
            element.SendKeys(Keys.Enter);


            string CountriesXpath = "//li[@class= 'list-item']";

            ICollection<IWebElement> countriesElements = driver.FindElements(By.XPath(CountriesXpath));
            int OfficesCount = 0;
            foreach(IWebElement countryElement in countriesElements)
            {
                                
                js.ExecuteScript("arguments[0].click()", countryElement);

                string OfficesXpath = "//div[@class= 'contact-item__office grid__column fr-col u-relative']";
                ICollection<IWebElement> OfficesElement = driver.FindElements(By.XPath(OfficesXpath));

                OfficesCount += OfficesElement.Count;

                Console.WriteLine(OfficesCount);


            }


        }

        
        [TearDown]
        public void CloseBrowser()
        {
           driver.Quit();
        }


    }
}
