using OpenQA.Selenium;
using SpecflowNunit.Utilitites;
using SpecflowNunit.Interfaces;

namespace SpecflowNunit.Hooks
{
    public class UITestContext : IUITestContext
    {
        public IWebDriver Driver
        {
            get; private set;
        }

        public UrlHelper UrlHelper
        {
            get; private set;
        }

        public UITestContext(IWebDriverFactory driverFactory)
        {
            Driver = driverFactory.Create();
            UrlHelper = new UrlHelper(Driver);
        }

        public void Start()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.co.uk/");
        }

        public void Quit()
        {
            Driver.Quit();
        }
    }
}
