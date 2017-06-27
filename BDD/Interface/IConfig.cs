using BDD.Configuration;

namespace BDD.Interface
{
    public interface IConfig
    {
        BrowserTypes GetBrowser();
        string GetHomePage();
        string GoToAPage(string page);

    }
}
