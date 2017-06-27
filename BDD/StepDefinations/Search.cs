using BDD.PageObject;
using BDD.Setting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BDD.StepDefinations
{
    [Binding]
    public sealed class Search
    {
        HomePage homePage = new HomePage(ObjectRepo.Driver);
        SearchRefinePage searchR = new SearchRefinePage(ObjectRepo.Driver);


        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            INavigation page = ObjectRepo.Driver.Navigate();
            page.GoToUrl(ObjectRepo.Config.GetHomePage());
            homePage.ClearAdIfExist();
        }

        [When(@"I search for (.*)")]
        public void GivenISearchForProduct(string searchValue)
        {
            homePage.Search(searchValue);
        }

        [Then(@"I should see results containing (.*) under product title")]
        public void ThenIShouldSeeResultsContainingProductUnderProductTitle(string searchValue)
        {
            homePage.ProductSearchResultList(searchValue);
        }

        [Then(@"I should see the result with (.*)")]
        public void ThenIShouldSeeTheResultWithCano(string productName)
        {
            homePage.AProductSearchResult(productName);
        }

        [Then(@"I should see invalid search message (.*)")]
        public void ThenIShouldSeeInvalidSearchMessag(string errorMessage)
        {
            homePage.SearchErrorMessage(errorMessage);
        }

        [When(@"I filter by (.*)")]
        public void WhenIFilterByBrand(string brandName)
        {
            searchR.SearchByBrand(brandName);
        }
    }
}