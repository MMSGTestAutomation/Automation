namespace WebServiceTestProject.Utilities
{
    public interface IConfig
    {
        BrowserType? GetBrowser();

        string GetUsername();

        string GetPassword();

        string GetWebsite();

        int GetPageLoadTimeOut();

        int GetElementLoadTimeOut();
    }
}