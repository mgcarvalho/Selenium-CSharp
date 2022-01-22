namespace Hostel.Funcional.Tests.TC.Search
{
    using Xunit;
    using OpenQA.Selenium;

    using Hostel.Funcional.Tests.Enum;
    using Hostel.Funcional.Tests.Extension;
    using Hostel.Funcional.Tests.Helper;
    using System;
    using OpenQA.Selenium.Support.UI;

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
        #endregion

        [Theory]
        [Trait("TestCategory", "Functional")]
        [Trait("Application", "Mobile Hostel Friend")]
        [Trait("Priority", "Meddium")]
        [InlineData("01/01/2023", "02/01/2023", "1", "0")]
        [InlineData("01/01/2023", "01/01/2024", "10", "0")]
        [InlineData("01/01/2023", "02/01/2023", "1", "2")]
        [InlineData("01/01/2023", "02/01/2023", "1", "10")]
        public void SearchValidation_Chrome_TrueData_Success(string checkIn, string checkOut, string adults, string children)
        {
            try
            {
                //Arrange & Actions
                Driver = TestHelper.Create(Browser.Chrome);
                var quickTimeout = Driver.TimeoutWindow(20);
                Driver.WaitSendKeysByXPath(quickTimeout, checkInInputxPath, checkIn);
                Driver.WaitSendKeysByXPath(quickTimeout, checkOutInputxPath, checkOut);

                //TODO: Create a helper (extensions) for combo boxes
                var comboAdultBox = Driver.FindElement(By.XPath(adultsComboxPath));
                new SelectElement(comboAdultBox).SelectByText(adults);

                var comboChildBox = Driver.FindElement(By.XPath(childComboxPath));
                new SelectElement(comboChildBox).SelectByText(children);

                Driver.WaitClickButtonByXPath(quickTimeout, buttonSearchxPath);

                //TODO: catch the value of element
                Driver.WaitByXPath(quickTimeout, successResultTextxPath);
                //Regex with result

                //Asserts
                Assert.True(true);
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
        [InlineData("02/01/2023", "01/01/2023", "1", "0")]
        [InlineData("01/01/2020", "02/01/2020", "1", "0")]
        public void SearchValidation_Chrome_TrueData_Unsuccess(string checkIn, string checkOut, string adults, string children)
        {
            try
            {
                //Arrange & Actions
                Driver = TestHelper.Create(Browser.Chrome);
                var quickTimeout = Driver.TimeoutWindow(20);
                Driver.WaitSendKeysByXPath(quickTimeout, checkInInputxPath, checkIn);
                Driver.WaitSendKeysByXPath(quickTimeout, checkOutInputxPath, checkOut);

                //TODO: Create a helper (extensions) for combo boxes
                var comboAdultBox = Driver.FindElement(By.XPath(adultsComboxPath));
                new SelectElement(comboAdultBox).SelectByText(adults);

                var comboChildBox = Driver.FindElement(By.XPath(childComboxPath));
                new SelectElement(comboChildBox).SelectByText(children);

                Driver.WaitClickButtonByXPath(quickTimeout, buttonSearchxPath);
                Driver.WaitByXPath(quickTimeout, successResultTextxPath);
                //Asserts
                Assert.True(true);
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
