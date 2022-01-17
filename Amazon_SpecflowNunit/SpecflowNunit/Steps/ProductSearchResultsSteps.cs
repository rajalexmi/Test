using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowNunit.Hooks;
using SpecflowNunit.Interfaces;
using SpecflowNunit.PageObjects;

using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowNunit.Steps
{
    [Binding]
    public class ProductSearchResultsSteps
    {
        private ProductSearchResultsPageObject _search;

        public ProductSearchResultsSteps(UITestContext uITestContext)
        {
            _search = new ProductSearchResultsPageObject(uITestContext);
        }


        [Given(@"I have opened the amazon shopping site")]
        public void GivenIHaveOpenedTheShoppingSite()
        {
            Thread.Sleep(1000);
            _search.NavigateUrl("https://www.amazon.co.uk/");
        }

        [Given(@"I accept the cookie button")]
        public void GivenIAcceptTheCookieButton()
        {
            _search.AcceptCookie();
        }

        [Then(@"I expect the amazon logo is displayed")]
        public void ThenIExpectTheAmazonLogoIsDisplayed()
        {
            _search.AssertLogoDisplayed(true);
        }


        [When(@"I select ""(.*)"" section in the department section")]
        public void WhenISelectSectionInTheDepartmentSection(string section )
        {
            _search.SelectBooksSection(section);
        }

        [When(@"I enter ""(.*)"" in the search bar")]
        public void WhenIEnterInTheSearchBar(string bookName)
        {
            _search.EnterSearchItem(bookName);
        }

        [When(@"I ask you to wait to see the page")]
        public void WhenIAskYouToWaitToSeeThePage()
        {
            _search.CheckWait();
        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            _search.ClickSearchButton();
        }


        [When(@"I expect to see the results displayed are for the books ""(.*)""")]
        public void WhenIExpectToSeeTheResultsDisplayedAreForTheBooks(string bookName)
        {
            _search.AssertSearchResult(bookName);
                
                }
        [Then(@"I expect the first item returned have the title of ""(.*)""")]
        [When(@"I expect the first item returned have the title of ""(.*)""")]
        public void WhenIExpectTheFirstItemReturnedHaveTheTitleOf(string bookName)
        {
            _search.AssertFirstItemTitle(bookName);
        }

        [When(@"I expect the first item returned to have the following properties")]
        public void WhenIExpectTheFirstItemReturnedToHaveTheFollowingProperties(Table table)
        {
            _search.AssertFirstItemProperties(table);
        }

        [When(@"I click the first product in the result")]
        public void WhenIClickTheFirstBookInTheResult()
        {
            _search.ClickBookDetails();
        }

        [Then(@"I expect to see the back to results button to confirm the book details page is displayed")]
        public void ThenIExpectToSeeTheBackToSearchButtonToConfirmTheBookDetailsPageIsDisplayed()
        {
            _search.AssertBookDetailsPageDisplayed();
        }


    }
}
