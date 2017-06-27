using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDD.Configuration;
using BDD.Setting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDD.BaseClasses
{
[TestClass]
    public class BaseClass
    {
    private static ChromeOptions GetChromeOptions()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("start-maximized");
        return options;
    }
        public static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        [AssemblyInitialize]
        public static void InitDriver(TestContext tc)
        {
            ObjectRepo.Config = new AppConfigReader();

            switch (ObjectRepo.Config.GetBrowser())
            {
                case BrowserTypes.Chrome:
                    ObjectRepo.Driver = GetChromeDriver();
                    break;
                default:
                    throw new NoSuchElementException("Driver not found: " + ObjectRepo.Config.GetBrowser());
            }
        }

    [AssemblyCleanup]
    public static void CleanUp()
    {
        if (ObjectRepo.Driver != null )
        {
         ObjectRepo.Driver.Close();
            ObjectRepo.Driver.Quit();
        }
    }


    }
}
