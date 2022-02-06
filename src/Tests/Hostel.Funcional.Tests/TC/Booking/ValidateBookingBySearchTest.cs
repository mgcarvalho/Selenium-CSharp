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
        private string roomCheckInInputxPath = "/html/body/div[2]/div[1]/div/div[1]/div/section/div/div/div/section[9]/div/div/div/div/div/div[5]/div/div/div/form/p[2]/input[1]";
        private string roomCheckOutInputxPath = "/html/body/div[2]/div[1]/div/div[1]/div/section/div/div/div/section[9]/div/div/div/div/div/div[5]/div/div/div/form/p[3]/input[1]";
        private string roomButtonSearchxPath = "/html/body/div[2]/div[1]/div/div[1]/div/section/div/div/div/section[9]/div/div/div/div/div/div[5]/div/div/div/form/p[4]/input";
        private string roomFailResultxPath = "/html/body/div[2]/div/div/section/div/div/div/section[2]/div/div/div[1]/div/div/div/div/div/div/div";
        private string roomErrorResultTextxPath = "/html/body/div[2]/div[1]/div/div[1]/div/section/div/div/div/section[9]/div/div/div/div/div/div[5]/div/div/div/form/div[1]/p";

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
                var notFoundFail = "Nenhuma acomodação encontrada";

                Driver = TestHelper.Create(Browser.Chrome);
                var dTimeout = Driver.TimeoutWindow(20);
                Driver.WaitSendKeysByXPath(dTimeout, checkInInputxPath, checkIn);
                Driver.WaitSendKeysByXPath(dTimeout, checkOutInputxPath, checkOut);

                Driver.WaitSelectDropdownValueByXPath(dTimeout, adultsComboxPath, adults);
                Driver.WaitSelectDropdownValueByXPath(dTimeout, childComboxPath, children);

                Driver.WaitClickButtonByXPath(dTimeout, buttonSearchxPath);
                Driver.WaitByXPath(dTimeout, successResultTextxPath);

                //Find?
                var textResut = Driver.GetElementByXPath(roomErrorResultTextxPath).Text;
                Assert.DoesNotContain(notFoundFail.ToUpper(), textResut.ToUpper());
                //Continue with booking

                //This part is not possible continue cos's site stop work!


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

        [Theory]
        [Trait("TestCategory", "TC2 Booking")]
        [InlineData("01/01/2020", "01/02/2020")]
        [InlineData("01/01/1900", "01/02/1900")]
        public void BookingValidation_TrueData_Unsuccess(string checkIn, string checkOut)
        {
            try
            {
                //Arrange & Actions
                Driver = TestHelper.Create(Browser.Chrome);
                var dTimeout = Driver.TimeoutWindow(20);

                Driver.WaitSendKeysByXPath(dTimeout, roomCheckInInputxPath, checkIn);
                Driver.WaitSendKeysByXPath(dTimeout, roomCheckOutInputxPath, checkOut);

                Driver.WaitClickButtonByXPath(dTimeout, roomButtonSearchxPath);
                Driver.WaitByXPath(dTimeout, roomErrorResultTextxPath);
                var textResut = Driver.GetElementByXPath(roomErrorResultTextxPath).Text;

                //Asserts
                var notFound = "Nada encontrado. Por favor, tente novamente com parâmetros de pesquisa diferentes.";

                //Asserts
                Assert.Contains(notFound.ToUpper(), textResut.ToUpper());
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