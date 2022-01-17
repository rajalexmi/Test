using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using FluentAssertions;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace SpecflowNunit.Extensions
{
    public static class WebElementExtensions
    {
       
        public static bool IsDisplayed(this IWebElement element)
        {
            try
            {
                return element?.Displayed ?? false;
            }
            catch (Exception)
            {
                return false;
            }
        }

           }
}
