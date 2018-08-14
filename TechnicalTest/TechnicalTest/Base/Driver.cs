using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace TechnicalTest.Base
{
    public static class Driver
    {
        public static string Browser = FrameworkSettings.BrowserName;
        public static IWebDriver webdriver;

        static Driver()
        {
            switch (Browser)
            {
                case ("Chrome"):
                    webdriver = new ChromeDriver();
                    break;
                case ("IE"):
                    webdriver = new InternetExplorerDriver();
                    break;

            }
        }

        public static IWebDriver getDriver()
        {
            return webdriver;
        }
    }
}
