using SpecflowNunit.Hooks;
using SpecflowNunit.Interfaces;
using SpecflowNunit.Utilitites;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowNunit.Steps
{
    [Binding]
    public class NavigationSteps
    {
        private readonly UrlHelper _urlHelper;

        public NavigationSteps(IUITestContext uiTestContext)
        {
            _urlHelper = new UrlHelper(uiTestContext.Driver);
        }

        [When(@"I navigate to ""(.*)""")]
        public void WhenINavigateTo(string relativeUrl)
        {
            _urlHelper.NavigateTo(relativeUrl);
        }

    }
}
