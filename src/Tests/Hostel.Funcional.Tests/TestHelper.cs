using Hostel.Funcional.Tests.Enum;
using OpenQA.Selenium;

namespace Hostel.Funcional.Tests
{
    public class TestHelper
    {
        #region Const
        public const string URLmain = "";
        #endregion

        public IWebDriver Create(Browser browserSelection = Browser.Chrome)
        {
            //Will need to construct the remoteServerUri so it can be passed to the remoteWebDriver.
            var remoteServer = BuildRemoteServer(configuration.SeleniumHubUrl, configuration.SeleniumHubPort);
            switch (browserSelection)
            {
               case Browser.Chrome:
                    ChromeOptions coptions = new ChromeOptions();
                    TimeSpan timeout = new TimeSpan(0, 5, 0);
                    coptions.AddArguments("--no-sandbox");
                    coptions.AddArguments("--enable-features=NetworkService,NetworkServiceInProcess");
                    coptions.AddArguments("incognito");
                    coptions.AddArguments("start-maximized");
                    coptions.AcceptInsecureCertificates = true;
                    //coptions.AddArguments("--remote - debugging - port = 4445");
                    _driver = new RemoteWebDriver(new Uri(remoteServer), coptions);
                    break;

                case Browser.InternetExplorer:
                    _driver = new RemoteWebDriver(new Uri(remoteServer), new InternetExplorerOptions());
                    break;
            }

            //This method adds additional information to the desired capabilities, in this instance browser version and operating system.
            //SetCapabilities(configuration.Platform, configuration.BrowserVersion);

            //We then create a new RemoteWebDriver with the Uri created earlier and the desired capabilities object.
            //This would then call your GRID instance and find a match and start the browser on the matching node.

            //Return the driver to the calling class.
            return _driver;
        }

    }
}
