namespace Hostel.Funcional.Tests.TC.Contacts
{
    using Xunit;
    using OpenQA.Selenium;

    using Hostel.Funcional.Tests.Enum;
    using Hostel.Funcional.Tests.Extension;
    using Hostel.Funcional.Tests.Helper;
    using System;

    public class ValidateContactFormTest
    {
        public IWebDriver Driver;
        const Browser browserSelection = Browser.Chrome;
        const string URLContact = "https://www.mobilityfriendshostel.pt/contatos/";
        #region xPath
        private string namexPath = "/html/body/div[2]/div/div/section/form/fieldset/input[8]";
        private string emailxPath = "/html/body/div[2]/div/div/section/form/fieldset/input[9]";
        private string phonexPath = "/html/body/div[2]/div/div/section/form/fieldset/input[10]";
        private string subjectxPath = "/html/body/div[2]/div/div/section/form/fieldset/input[11]";
        private string messagexPath = "/html/body/div[2]/div/div/section/form/fieldset/textarea";
        private string captchaxPath = "/html/body/div[2]/div/div/section/form/fieldset/input[13]";
        private string sendButtonxPath = "/html/body/div[2]/div/div/section/form/fieldset/input[14]";
        private string errorMessagexPath = "/html/body/div[3]/div/div/section/form/fieldset/label[8]";
        #endregion

        [Theory]
        [Trait("TestCategory", "TC4 Form Contact")]
        [InlineData("Ana", "teste@email.pt", "", "Teste", "Teste", "")]
        [InlineData("Ana", "teste@email.pt", "910000000", "Teste", "Teste", "")]
        public void SearchValidation_TrueData_Success(string nameForm, string emailForm, string phoneForm, string subjectForm, string messageForm, string captchaForm)
        {
            try
            {
                //Arrange & Actions
                Driver = TestHelper.Create(browserSelection, URLContact);
                var dTimeout = Driver.TimeoutWindow(20);

                Driver.WaitByXPath(dTimeout, namexPath);
                Driver.SendKeysByXPath(namexPath, nameForm);
                Driver.SendKeysByXPath(emailxPath, emailForm);
                Driver.SendKeysByXPath(phonexPath, phoneForm);
                Driver.SendKeysByXPath(subjectxPath, subjectForm);
                Driver.SendKeysByXPath(messagexPath, messageForm);
                Driver.SendKeysByXPath(captchaxPath, captchaForm);
                Driver.WaitClickButtonByXPath(dTimeout, sendButtonxPath);

                var elem = Driver.FindElement(By.XPath(sendButtonxPath));
                //Asserts
                Assert.True(elem.Exists());
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
        [Trait("TestCategory", "TC5 Form Contact")]
        [InlineData("Ana", "teste@email.pt", "", "Teste", "Teste", "teste@email.pt")]
        [InlineData("Ana", "teste@email.pt", "910000000", "Teste", "Teste", "teste@email.pt")]
        [InlineData("Ana", "", "910000000", "Teste", "Teste", "teste@email.pt")]
        [InlineData("Ana", "teste@email.pt", "", "Teste", "", "")]
        [InlineData("Ana", "teste@email.pt", "910000000", "Teste", "", "")]
        public void SearchValidation_TrueData_Unsuccess(string nameForm, string emailForm, string phoneForm, string subjectForm, string messageForm, string captchaForm)
        {
            try
            {
                //Arrange & Actions
                Driver = TestHelper.Create(browserSelection, URLContact);
                var dTimeout = Driver.TimeoutWindow(20);

                Driver.WaitByXPath(dTimeout, namexPath);
                Driver.SendKeysByXPath(namexPath, nameForm);
                Driver.SendKeysByXPath(emailxPath, emailForm);
                Driver.SendKeysByXPath(phonexPath, phoneForm);
                Driver.SendKeysByXPath(subjectxPath, subjectForm);
                Driver.SendKeysByXPath(messagexPath, messageForm);
                Driver.SendKeysByXPath(captchaxPath, captchaForm);
                Driver.WaitClickButtonByXPath(dTimeout, sendButtonxPath);

                var elem = Driver.FindElement(By.XPath(errorMessagexPath));
                //Asserts
                Assert.True(elem.Exists());
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
