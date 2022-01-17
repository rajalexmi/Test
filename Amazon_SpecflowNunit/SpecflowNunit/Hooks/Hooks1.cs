using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecflowNunit.Utilitites;
using SpecflowNunit.Interfaces;
using OpenQA.Selenium;

namespace SpecflowNunit.Hooks
{

    [Binding]
    public class Hooks1
    {
        private readonly IObjectContainer _objectContainer;

        private readonly IUITestContext _uITestContext;

        public Hooks1(IObjectContainer objectContainer)
        {
            var webDriverFactory = new ChromeDriverFactory();
            _uITestContext = new UITestContext(webDriverFactory);
            _objectContainer = objectContainer;
            _objectContainer.RegisterInstanceAs<IUITestContext>(_uITestContext);
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            _uITestContext.Start();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _uITestContext.Quit();
        }
    }
}
