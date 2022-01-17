using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SpecflowNunit.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNunit.Utilitites
{
    public class FirefoxDriverFactory : IWebDriverFactory
    {

       public IWebDriver Create()
        {
            return new FirefoxDriver();
        }
    }

    public class ChromeDriverFactory : IWebDriverFactory
    {

        public IWebDriver Create()
        {
            return new ChromeDriver();
        }
    }
}
