namespace Hostel.Funcional.Tests
{
    using Hostel.Funcional.Tests.Enum;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    using System;
    using System.Diagnostics;
    using System.IO;
    public  class BaseTester : IDisposable
    {
        public IWebDriver Driver;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~BaseTester()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            //// Cleanup
            if (Driver != null)
            {
                Driver.Close();

                Driver.Quit();

                Driver.Dispose();
            }
        }
    }
}
