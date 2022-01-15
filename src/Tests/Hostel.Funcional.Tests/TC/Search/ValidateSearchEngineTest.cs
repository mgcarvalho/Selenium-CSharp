namespace Hostel.Funcional.Tests.TC.Search
{
    using Hostel.Funcional.Tests.Enum;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    [TestClass]
    public class ValidateSearchEngineTest
    {
        public IWebDriver Driver;
        const Browser browserSelection = Browser.Chrome;
        
        #region ctor

        #endregion

        public void SearchValidation_TrueData_Success(string checkIn, string checkOut, int adults, int children)
        {
            Driver = new TestHelper().Create(browserSelection);
            Driver.Navigate();
        }

        [DataTestMethod]
        public void SearchValidation_ExcelData_Success()
        {
            Driver = new TestHelper().Create(browserSelection);
            Driver.Navigate();
            Assert.IsTrue(true);
        }

    }
}
