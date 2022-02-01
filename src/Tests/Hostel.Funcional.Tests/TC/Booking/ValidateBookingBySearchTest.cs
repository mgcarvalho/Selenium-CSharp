namespace Hostel.Funcional.Tests.TC.Booking
{
    using Xunit;
    using OpenQA.Selenium;

    using Hostel.Funcional.Tests.Enum;
    using Hostel.Funcional.Tests.Extension;
    using Hostel.Funcional.Tests.Helper;
    using System;
    using OpenQA.Selenium.Support.UI;
    using System.Globalization;

    public class ValidateSearchEngineTest
    {
        public IWebDriver Driver;
        const Browser browserSelection = Browser.Chrome;

        //Search Page
        private string checkInInputxPath = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[4]/div/div/div/form/p[2]/input";
        private string checkOutInputxPath = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[4]/div/div/div/form/p[3]/input";
        private string adultsComboxPath = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[4]/div/div/div/form/p[4]/select";
        private string childComboxPath = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[4]/div/div/div/form/p[5]/select";
        private string buttonSearchxPath = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[4]/div/div/div/form/p[6]/input";
        private string successResultTextxPath = "/html/body/div[2]/div/div/section/div/div/div/section[2]/div/div/div[1]/div/div/div/div/div/div/p";

        [Theory]
        [Trait("TestCategory", "TC2 Booking")]
        [InlineData("10/01/2030", "15/01/2030", "1", "0")]
        [InlineData("10/01/2030", "15/01/2030", "1", "1")]
        [InlineData("10/01/2030", "15/01/2030", "1", "2")]
        [InlineData("10/01/2030", "15/01/2030", "1", "3")]
        public void BookingValidation_TrueData_Success(string checkIn, string checkOut, string adults, string children)
        {
            try
            {
                //Arrange & Actions
                Driver = TestHelper.Create(Browser.Chrome);
                var dTimeout = Driver.TimeoutWindow(20);
                Driver.WaitSendKeysByXPath(dTimeout, checkInInputxPath, checkIn);
                Driver.WaitSendKeysByXPath(dTimeout, checkOutInputxPath, checkOut);

                Driver.WaitSelectDropdownValueByXPath(dTimeout, adultsComboxPath, adults);
                Driver.WaitSelectDropdownValueByXPath(dTimeout, childComboxPath, children);

                Driver.WaitClickButtonByXPath(dTimeout, buttonSearchxPath);
                Driver.WaitByXPath(dTimeout, successResultTextxPath);


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