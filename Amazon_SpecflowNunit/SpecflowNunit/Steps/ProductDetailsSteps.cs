using SpecflowNunit.Hooks;
using SpecflowNunit.Interfaces;
using SpecflowNunit.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowNunit.Steps
{
    [Binding]
    public class ProductDetailsSteps
    {
        private readonly ProductDetailsPageObject _details;

        public ProductDetailsSteps(UITestContext uITestContext)
        {
            _details = new ProductDetailsPageObject(uITestContext);
        }

        [Then(@"I expect the book details are displayed in the product details page as follows")]
        public void ThenIExpectTheBookDetailsAreDisplayedAsFollows(Table table)
        {
            _details.AssertBookDetailsInProductDetailsPage(table);
        }

        [When(@"I click the add to basket button")]
        public void WhenIClickTheAddToBasketButton()
        {
            _details.ClickAddToBasketButton();
        }

        [Then(@"I expect to see the notification of product added to basket is displayed")]
        public void ThenIExpectToSeeTheNotificationOfProductAddedToBasket()
        {
            _details.AssertProductAddedNotification();
        }

        [Then(@"I confirm that the product added is having the correct productid as ""(.*)""")]
        public void ThenIConfirmThatTheProductAddedIsHavingTheCorrectBookidAs(string productId)
        {
            _details.AssertProductAddedIsCorrect(productId);
        }

        [Then(@"I expect to see the title ""(.*)""")]
        public void ThenIExpectToSeeTheTitle(string basketTitle)
        {
            _details.AssertBasketTitle(basketTitle);
        }

        [Then(@"I expect to see ""(.*)"" is added in the basket")]
        public void ThenIExpectToSeeIsAddedInTheBasket(string noOfItems)
        {
            _details.AssertOneItemAddedInBasket(noOfItems);
        }

        [When(@"I click on edit the basket")]
        public void WhenIClickOnEditTheBasket()
        {
            _details.ClickEditBasket();
        }

      
        [Then(@"I expect to see the book is displayed with the correct book information as below")]
        public void ThenIExpectToSeeTheBookIsDisplayedWithTheCorrectBookInformationAsBelow(Table table)
        {
            _details.AssertProductDetailsinBasketList(table);
        }
    }
}
