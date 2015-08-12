
using OpenQA.Selenium;

namespace UnitTestProject.Pages
{
    public class BasePage
    {
        readonly IWebDriver _webDriver;
        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void VisitBase(string pageAddress)
        {
            _webDriver.Navigate().GoToUrl(pageAddress);
        }

        public void CloseBrowser()
        {
            _webDriver.Close();
        }

        public void MaxMize()
        {
            _webDriver.Manage().Window.Maximize();
        }
    }
}
