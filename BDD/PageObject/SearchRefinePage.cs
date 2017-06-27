using BDD.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace BDD.PageObject
{
    class SearchRefinePage : PageBase
    {
        private IWebDriver driver;

        #region WebElement
        [FindsBy(How = How.XPath, Using = ".//*[@id='product-results']//div[@class='respDiv sidebar-nav border-box']//ul[2]//span[@class ='scroll'][1]//a")]
        private IList<IWebElement> BrandNames;

        #endregion



        public SearchRefinePage(IWebDriver _driver) : base(_driver)
        {
            driver = _driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
        }

        public void SearchByBrand(string BrandName)
        {
            var GetBrandNames = BrandNames;

            foreach (var getBrand in GetBrandNames)
            {
                if (getBrand.Text.StartsWith(BrandName))
                {
                    getBrand.Click();
                    break;
                }
            }
        }
    }
}