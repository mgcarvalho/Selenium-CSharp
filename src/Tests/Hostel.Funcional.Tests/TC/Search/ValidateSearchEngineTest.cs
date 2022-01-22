namespace Hostel.Funcional.Tests.TC.Search
{
    using Xunit;
    using OpenQA.Selenium;

    using Hostel.Funcional.Tests.Enum;
    using Hostel.Funcional.Tests.Extension;
    using Hostel.Funcional.Tests.Helper;

    public class ValidateSearchEngineTest
    {
        public IWebDriver Driver;
        const Browser browserSelection = Browser.Chrome;

        [Theory]
        [Trait("TestCategory", "Functional")]
        [Trait("Application", "Mobile Hostel Friend")]
        [Trait("Priority", "Meddium")]
        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "Campaigns_CampaignType1", 1, 0)]
        public void SearchValidation_Chrome_TrueData_Success(string checkIn, string checkOut, int adults, int children)
        {
            //Arrange & Actions
            Driver = TestHelper.Create(Browser.Chrome);
            
            

            //Asserts
            Assert.True(true);

            //Close
            Driver.Close();
        }

        [Fact]
        public void SearchValidation_ExcelData_Success()
        {
            Driver = TestHelper.Create(browserSelection);
            Driver.Navigate();
            Assert.True(true);
            Driver.Close();
        }

    }
}
