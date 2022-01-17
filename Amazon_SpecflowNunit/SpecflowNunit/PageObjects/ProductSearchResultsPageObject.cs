using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using FluentAssertions;
using SpecflowNunit.Base;
using SpecflowNunit.Extensions;
using System;
using SpecflowNunit.Interfaces;
using System.Threading;
using TechTalk.SpecFlow;
using SpecflowNunit.Context;
using TechTalk.SpecFlow.Assist;

namespace SpecflowNunit.PageObjects
{
    public class ProductSearchResultsPageObject : BasePage
    {

        public ProductSearchResultsPageObject(IUITestContext iUITestContext)
            : base(iUITestContext)
        {

        }

        [FindsBy(How = How.Id, Using = "nav-logo-sprites")]
        public IWebElement Logo { get; set; }

        [FindsBy(How = How.Id, Using = "sp-cc-accept")]
        public IWebElement AcceptAllCookiesButton { get; set; }


        [FindsBy(How = How.Id, Using = "searchDropdownBox")]
        public IWebElement Sections { get; set; }


        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        public IWebElement SearchBar { get; set; }

        [FindsBy(How = How.Id, Using = "nav-search-submit-button")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='a-section a-spacing-small a-spacing-top-small']//*[@class='a-color-state a-text-bold']")]
        public IWebElement ResultsList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@data-cel-widget='search_result_1']//h2/a")]
        public IWebElement FirstItemTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@data-cel-widget='search_result_1']//*[@class='a-badge-text']")]
        public IWebElement FirstItemBadgeText { get; set; }


        [FindsBy(How = How.XPath, Using = "(//*[@data-cel-widget='search_result_1']//*[@class='a-row a-size-base a-color-base'])[1]")]
        public IWebElement FirstItemSelectedType { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@data-cel-widget='search_result_1']//*[@class='a-offscreen'])[1]")]
        public IWebElement FirstItemBookPrice { get; set; }

        [FindsBy(How = How.Id, Using = "productTitle")]
        public IWebElement TitleInBookDetailsPage { get; set; }

        [FindsBy(How = How.Id, Using = "breadcrumb-back-link")]
        public IWebElement BackToSearchButton { get; set; }
        


        public void NavigateUrl(string site)
        {
            var currentUrl = Driver.Url;
            currentUrl.Should().Be(site);
        }

        public void AcceptCookie()
        {
            AcceptAllCookiesButton.Click();
        }

        public void AssertLogoDisplayed(bool value)
        {

            Logo.IsDisplayed().Should().Be(value);
        }

        public void SelectBooksSection(string section)
        {
            Sections.SendKeys("Books");
        }

        internal void EnterSearchItem(string bookName)
        {
            SearchBar.SendKeys("Harry Potter and the Cursed Child");
        }

        internal void CheckWait()
        {
            Thread.Sleep(1000);
        }

        internal void ClickSearchButton()
        {
            SearchButton.Click();
        }

        public void AssertSearchResult(string bookName)
        {
            ResultsList.Text.Should().Contain(bookName);
        }

        public void AssertFirstItemTitle(string bookName)
        {
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            FirstItemTitle.Text.Should().Contain(bookName);
        }

        public void AssertFirstItemProperties(Table table)
        {
            var firstItem = table.CreateInstance<AmazonShoppingContext>();
            FirstItemBadgeText.Text.Should().Be(firstItem.BadgeName);
            FirstItemTitle.Text.Should().Contain(firstItem.Title);
            FirstItemSelectedType.Text.Should().Be(firstItem.SelectedType);
            FirstItemBookPrice.GetAttribute("innerHTML").Should().Be(firstItem.Price);
        }

        public void ClickBookDetails()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            FirstItemTitle.Click();
        }

        public void AssertBookDetailsPageDisplayed()
        {
            BackToSearchButton.IsDisplayed().Should().BeTrue();
        }
    }
}
