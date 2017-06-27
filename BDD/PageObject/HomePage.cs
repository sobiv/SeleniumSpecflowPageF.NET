using BDD.BaseClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace BDD.PageObject
{
    public class HomePage : PageBase
    {
        private IWebDriver driver;

        #region WebElement
        [FindsBy(How = How.ClassName, Using = "yieldifyPopup__closeIcon")]
        private IWebElement CloseYieldPopUp;

        [FindsBy(How = How.Id, Using = "term")]
        private IWebElement SearchBox;
        [FindsBy(How = How.Id, Using = "searchButton")]
        [CacheLookup]
        private IWebElement SearchButton;

        [FindsBy(How = How.CssSelector, Using = ".fn.product-title")]
        private IList<IWebElement> SearchResultProductTitle;

        [FindsBy(How = How.XPath, Using = ".//div[@id='product-results']/div/p[1]")]
        private IWebElement InvalidSearchErrorMessage;


        #endregion

        public HomePage(IWebDriver _driver) : base(_driver)
        {

            driver = _driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

        }

        public void ClearAdIfExist()
        {
            try
            {
                if (CloseYieldPopUp.Enabled)
                {
                    CloseYieldPopUp.Click();
                }

            }
            catch (Exception e1)
            {
                //
            }
        }

        public void Search(string searchValue)
        {
            SearchBox.Clear();
            SearchBox.SendKeys(searchValue);
            SearchButton.Click();
        }

        public void AProductSearchResult(string searchValue)
        {
            var resultText = SearchResultProductTitle;
            int sratchCount = 1;
            if (resultText.Count.Equals(sratchCount))
            {
                foreach (var searchText in resultText)
                {
                    Assert.IsTrue(searchText.Text.ToLower().Equals(searchValue.ToLower()), "");
                }
            }
            else
            {
                Assert.Fail("Count of search result was greater then 1, actual count was {0}", resultText.Count);
            }
        }

        public void ProductSearchResultList(string searchValue)
        {
            var resultText = SearchResultProductTitle;
            foreach (var searchText in resultText)
            {
                if (searchText.Text.ToLower().Contains(searchValue.ToLower()))
                {
                    // Pass
                }
                else
                {
                    Assert.Fail("Contained: {0}", searchText.Text);
                }
            }
        }

        public void SearchErrorMessage(string searchMsg)
        {
            var expectedError = searchMsg.Replace(@"""", "");
            var getSearchErrorTxt = InvalidSearchErrorMessage.Text.Replace(@"""", "\"");
            expectedError.Equals(getSearchErrorTxt);
        }
    }
}
