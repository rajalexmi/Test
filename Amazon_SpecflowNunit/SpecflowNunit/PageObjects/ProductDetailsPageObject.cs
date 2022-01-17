using OpenQA.Selenium;
using SpecflowNunit.Base;
using SpecflowNunit.Context;
using SpecflowNunit.Interfaces;
using TechTalk.SpecFlow;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;
using System;
using SpecflowNunit.Extensions;

namespace SpecflowNunit.PageObjects
{
    public class ProductDetailsPageObject : BasePage
    {
        public ProductDetailsPageObject(IUITestContext iUITestContext)
            : base(iUITestContext)
        {

        }

        [FindsBy(How = How.Id, Using = "productTitle")]
        public IWebElement BookTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='badge-link']/i")]
        public IWebElement BookBadge { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@id='tmmSwatches']//li)[3]//*[@class='a-button-text']")]
        public IWebElement BookType { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@id='tmmSwatches']//li)[3]//*[@class='a-size-base a-color-price a-color-price']")]
        public IWebElement BookPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='add-to-cart-button']")]
        public IWebElement AddToBasketButton { get; set; }

        [FindsBy(How = How.Id, Using = "sw-atc-details-single-container")]
        public IWebElement ProductAddedNotification { get; set; }

        [FindsBy(How = How.Id, Using = "huc-v2-order-row-item-0751565369")]
        public IWebElement ProductAdded { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='huc-v2-order-row-confirm-text']/h1")]
        public IWebElement BasketTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='hlb-subcart']//*[@class='a-size-medium a-align-center huc-subtotal']")]
        public IWebElement BasketSubTotal { get; set; }

        [FindsBy(How = How.Id, Using = "hlb-view-cart-announce")]
        public IWebElement EditBasket { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@data-name='Active Items']")]
        public IWebElement BasketList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@data-name='Active Items']//*/li//*[@class='a-truncate-cut']")]
        public IWebElement BookTitleInBasket { get; set; }
        
        [FindsBy(How = How.XPath, Using = "(//*[@data-name='Active Items']//*/li)[3]//*/i")]
        public IWebElement BookBadgeInBasket { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@data-name='Active Items']//*/li)[4]//*/span")]
        public IWebElement BookTypeInBasket { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@data-name='Active Items']//*/p")]
        public IWebElement BookPriceInBasket { get; set; }
        

        public void AssertBookDetailsInProductDetailsPage(Table table)
        {
            var bookDetails = table.CreateInstance<AmazonShoppingContext>();
            BookTitle.Text.Should().Contain(bookDetails.Title);
            BookBadge.Text.Should().Be(bookDetails.BadgeName);
            BookType.Text.Should().Contain(bookDetails.SelectedType);
            var price = (BookPrice.Text.Replace(" ", string.Empty));
            price.Should().Be(bookDetails.Price);
        }

        public void ClickAddToBasketButton()
        {
            AddToBasketButton.Click();
        }

        public void AssertProductAddedNotification()
        {
            ProductAddedNotification.IsDisplayed().Should().BeTrue();
        }

        public void AssertProductAddedIsCorrect(string productId)
        {
            ProductAdded.GetAttribute("data-asin").Should().Be(productId);
        }

        public void AssertBasketTitle(string basketTitle)
        {
            BasketTitle.Text.Should().Be(basketTitle);
        }

        public void AssertOneItemAddedInBasket(string noOfItems)
        {
            BasketSubTotal.Text.Should().Contain(noOfItems);
        }

        public void ClickEditBasket()
        {
            EditBasket.Click();
        }

        public void AssertProductDetailsinBasketList(Table table)
        {
            var bookDetails = table.CreateInstance<AmazonShoppingContext>();


            BookTitleInBasket.Text.Should().Contain(bookDetails.Title);
            BookBadgeInBasket.Text.Should().Be(bookDetails.BadgeName);
            BookTypeInBasket.Text.Should().Contain(bookDetails.SelectedType);
            BookPriceInBasket.Text.Should().Be(bookDetails.Price);
            //BookType.Text.Should().Contain(bookDetails.SelectedType);
            //var price = (BookPrice.Text.Replace(" ", string.Empty));
            //price.Should().Be(bookDetails.Price);
        }


    }
}
