using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDD.Interface;
using BDD.Setting;

namespace BDD.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserTypes GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            return (BrowserTypes) Enum.Parse(typeof (BrowserTypes), browser);

        }

        public string GetHomePage()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.HomePage);
        }

        public string GoToAPage(string page)
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.HomePage+page);
        }
    }
}
