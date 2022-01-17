using OpenQA.Selenium;
using SpecflowNunit.Utilitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNunit.Interfaces
{
    public interface IUITestContext
    {
        IWebDriver Driver { get; }
        UrlHelper UrlHelper { get; }

        void Start();
        void Quit();
    }
}
