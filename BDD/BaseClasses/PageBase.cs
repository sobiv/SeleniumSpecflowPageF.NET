using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BDD.BaseClasses
{
    public class PageBase
    {

        private IWebDriver driver;

        public PageBase(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;
        }

        public string Title
        {
            get { return driver.Title; }
        }
    }
}
