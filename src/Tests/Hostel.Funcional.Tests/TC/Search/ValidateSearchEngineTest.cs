namespace Hostel.Funcional.Tests.TC.Search
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

        #region xPath
        private string checkInInputxPath = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[4]/div/div/div/form/p[2]/input";
        private string checkOutInputxPath = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[4]/div/div/div/form/p[3]/input";
        private string adultsComboxPath = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[4]/div/div/div/form/p[4]/select";
        private string childComboxPath = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[4]/div/div/div/form/p[5]/select";
        private string buttonSearchxPath = "/html/body/div[2]/div/div/section/div/div/div/section[1]/div[2]/div/div/div/div/div[4]/div/div/div/form/p[6]/input";
        private string successResultTextxPath = "/html/body/div[2]/div/div/section/div/div/div/section[2]/div/div/div[1]/div/div/div/div/div/div/p";
        private string failResultxPath = "/html/body/div[2]/div/div/section/div/div/div/section[2]/div/div/div[1]/div/div/div/div/div/div/div";
        #endregion

        [Theory]
        [Trait("TestCategory", "Functional")]
        [Trait("Application", "Mobile Hostel Friend")]
        [Trait("Priority", "Meddium")]
        [InlineData("22/01/2022", "23/01/2022", "1", "0")]
        [InlineData("01/01/2023", "01/01/2024", "10", "0")]
        [InlineData("01/01/2023", "02/01/2023", "1", "2")]
        [InlineData("01/01/2023", "02/01/2023", "1", "10")]
        public void SearchValidation_Chrome_TrueData_Success(string checkIn, string checkOut, string adults, string children)
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
                var textResut = Driver.GetElementByXPath(successResultTextxPath).Text;

                var cultureInfo = new CultureInfo("pt-PT");
                var dateresultIn = DateTime.Parse(checkIn, cultureInfo);
                var dateresultOut = DateTime.Parse(checkOut, cultureInfo);

                //Asserts
                var comparText = $"De {dateresultIn.ToString("d \\de MMMM, yyyy")} - à {dateresultOut.ToString("d \\de MMMM, yyyy")}";
                Assert.Contains(comparText.ToUpper(), textResut.ToUpper());
            }
            catch(Exception ex)
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
        [Trait("TestCategory", "Functional")]
        [Trait("Application", "Mobile Hostel Friend")]
        [Trait("Priority", "Meddium")]
        [InlineData("13/13/2023", "14/15/2023", "1", "0")]
        [InlineData("01/01/2020", "02/01/2019", "1", "0")]
        public void SearchValidation_Chrome_Unsuccess(string checkIn, string checkOut, string adults, string children)
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

                var comboChildBox = Driver.FindElement(By.XPath(childComboxPath));
                new SelectElement(comboChildBox).SelectByText(children);

                Driver.WaitClickButtonByXPath(dTimeout, buttonSearchxPath);
                Driver.WaitByXPath(dTimeout, failResultxPath);
                var textResut = Driver.GetElementByXPath(failResultxPath).Text;

                //Asserts
                var comparValido = "não é válido";
                var comparCorreta = "não está correta";

                //Asserts
                Assert.Contains(comparValido.ToUpper(), textResut.ToUpper());
                Assert.Contains(comparCorreta.ToUpper(), textResut.ToUpper());
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
