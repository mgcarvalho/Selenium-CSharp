namespace Hostel.Funcional.Tests.TC.Search
{
    using Hostel.Funcional.Tests.Enum;
    using OpenQA.Selenium;
    using Xunit;

    [TestCaseOrderer("Search", "Engine")]
    [Collection("Search")]
    public class ValidateSearchEngineTest
    {
        public IWebDriver Driver;
        const Browser browserSelection = Browser.Chrome;
        
        #region ctor
        public ValidateSearchEngineTest()
        { //Driver = new TestHelper().Create(browserSelection); 
        }
        #endregion

        [Trait("TestCategory", "Sanity")]
        [Trait("Application", "Hostel")]
        [Theory]
        [InlineData("01/01/2022", "02/01/2022", 1,0)]
        [InlineData("01/01/2022", "01/01/2023", 10, 0)]
        [InlineData("01/01/2022", "02/01/2022", 1, 2)]
        [InlineData("01/01/2022", "02/01/2022", 2, 10)]
        public void SearchValidation_TrueData_Success(string checkIn, string checkOut, int adults, int children)
        {
            Driver = new TestHelper().Create(browserSelection);
            Driver.Navigate();
        }

        [Fact]
        public void SearchValidation_ExcelData_Success()
        {
            Driver.Navigate();
            Assert.True(true);
        }

    }
}
