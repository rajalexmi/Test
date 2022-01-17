using OpenQA.Selenium;
using System;
using SpecflowNunit.Base;
using SpecflowNunit.Extensions;

namespace SpecflowNunit.Utilitites
{
    public class UrlHelper 
    {
        public UrlHelper(IWebDriver driver) 
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        //public void NavigateSite(string siteName)
        //{
        //    Driver.Navigate().GoToUrl(siteName);
        //}

        public void NavigateTo(string path)
        {
            var baseUrl = Driver.Url;
            Driver.Navigate().GoToUrl(baseUrl + path);
        }
        
    }
}
