using BDD.Interface;
using OpenQA.Selenium;

namespace BDD.Setting
{
    public class ObjectRepo
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }
    }
}
