using OpenQA.Selenium;
using SwagLabs.Pages;
using SwagLabs.Tests;
using System;
using TechTalk.SpecFlow;

namespace SwagLabs.StepDefinitions
{
    [Binding]
    public class AddToCartFunctionalityStepDefinitions
    {
        public IWebDriver driver;
        LoginTest loginTest;
        AddToCart add;
        AddToCartTest addProductTest;
        AboutPage about;
        LoginPage loginPage;

        public AddToCartFunctionalityStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User count the products")]
        public void GivenUserCountTheProducts()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            add = new AddToCart(driver);
            addProductTest = new AddToCartTest(driver);
            add.ProductCount();
        }

        [When(@"User added highest price product into cart")]
        public void WhenUserAddedHighestPriceProductIntoCart()
        {
            add.HighestPrice();
            add.addedProduct();
        }

        [When(@"User click on Checkout button")]
        public void WhenUserClickOnCheckoutButton()
        {
            addProductTest.verifyAddedProduct();
            add.checkout();
        }

        [When(@"User enter firstname, lastname and zipcode")]
        public void WhenUserEnterFirstnameLastnameAndZipcode()
        {
            add.enterDetails();
        }

        [When(@"User click on Continue and Finish button")]
        public void WhenUserClickOnContinueAndFinishButton()
        {
            addProductTest.verifyAddedProduct();
            add.finish();
        }

        [Then(@"Successful message should be dislayed to the user")]
        public void ThenSuccessfulMessageShouldBeDislayedToTheUser()
        {
            addProductTest.placedOrder();
        }

        [When(@"User logout from the application")]
        public void WhenUserLogoutFromTheApplication()
        {
            loginPage = new LoginPage(driver);
            about = new AboutPage(driver);
            about.gotoMenu();
            loginPage.logout();
        }

        [Then(@"User should redireced to the login page")]
        public void ThenUserShouldRedirecedToTheLoginPage()
        {
            loginTest = new LoginTest(driver);
            loginTest.VerifyTitle();
        }

    }
}
