using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecflowNunit.Interfaces;
using SpecflowNunit.Utilitites;

namespace SpecflowNunit.Base
{
    public abstract class BasePage
    {
        private IUITestContext iUITestContext;

        protected BasePage(IUITestContext iUITestContext)
        {
            this.iUITestContext = iUITestContext;
            this.Driver = iUITestContext.Driver;
            PageFactory.InitElements(Driver, this);
        }

        protected IWebDriver Driver { get; set; }
    }
}
