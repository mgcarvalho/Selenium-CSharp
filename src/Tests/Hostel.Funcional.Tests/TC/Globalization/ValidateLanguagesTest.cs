namespace Hostel.Funcional.Tests.TC.Globalization
{
    using Xunit;
    using OpenQA.Selenium;

    using Hostel.Funcional.Tests.Enum;
    using Hostel.Funcional.Tests.Extension;
    using Hostel.Funcional.Tests.Helper;
    using System;

    public class ValidateLanguagesTest
    {
        public IWebDriver Driver;
        const Browser browserSelection = Browser.Chrome;
        const string URLContact = "https://www.mobilityfriendshostel.pt/rooms-and-suites/";
        #region xPath
        private string btnSpanhishxPath = "/html/body/header[2]/div[2]/nav/ul/li[7]/a/img";
        private string btnEnglishxPath = "/html/body/header[2]/div[2]/nav/ul/li[5]/a/img";
        private string btnPortuguesexPath = "/html/body/header[2]/div[2]/nav/ul/li[6]/a/img";
        private string titlexPathEN = "/html/body/div[3]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[2]/div/div/div/div/h1/span/font/font";
        private string titlexPathPT = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[2]/div/div/div/div/h1/span";
        private string titlexPathES = "/html/body/div[3]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[2]/div/div/div/div/h1/span/font/font";

        #endregion

        [Fact]
        [Trait("TestCategory", "TC6 Globalization Spanish")]
        public void CheckSpanish_Sucess()
        {
            try
            {
                //Arrange & Actions
                Driver = TestHelper.Create(browserSelection, URLContact);
                var dTimeout = Driver.TimeoutWindow(20);

                Driver.WaitClickButtonByXPath(dTimeout, btnSpanhishxPath);
                Driver.WaitByXPath(dTimeout, titlexPathES);
                var textResut = Driver.GetElementByXPath(titlexPathES).Text;

                //Asserts
                var comparText = "Diversión y Relajación";
                Assert.Contains(comparText.ToUpper(), textResut.ToUpper());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Close
                Driver.Close();
            }
        }

        [Fact]
        [Trait("TestCategory", "TC6 Globalization English")]
        public void CheckEnglish_Sucess()
        {
            try
            {
                //Arrange & Actions
                Driver = TestHelper.Create(browserSelection, URLContact);
                var dTimeout = Driver.TimeoutWindow(20);

                Driver.WaitClickButtonByXPath(dTimeout, btnEnglishxPath);
                Driver.WaitByXPath(dTimeout, titlexPathEN);
                var textResut = Driver.GetElementByXPath(titlexPathEN).Text;

                //Asserts
                var comparText = "Fun & Relax";
                Assert.Contains(comparText.ToUpper(), textResut.ToUpper());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Close
                Driver.Close();
            }
        }

        [Fact]
        [Trait("TestCategory", "TC6 Globalization Portuguese")]
        public void CheckPortuguese_Sucess()
        {
            try
            {
                //Arrange & Actions
                Driver = TestHelper.Create(browserSelection, URLContact);
                var dTimeout = Driver.TimeoutWindow(20);

                Driver.WaitClickButtonByXPath(dTimeout, btnPortuguesexPath);
                Driver.WaitByXPath(dTimeout, titlexPathPT);
                var textResut = Driver.GetElementByXPath(titlexPathPT).Text;

                //Asserts
                var comparText = "Diversão & Relax";
                Assert.Contains(comparText.ToUpper(), textResut.ToUpper());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Close
                Driver.Close();
            }
        }
    }
}