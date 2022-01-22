namespace Hostel.Funcional.Tests.Extension
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;

    public static class DriverExtension
    {
        /// <summary>
        /// Waits for HTML element with the same ID as the one specified to appear and performs a click on it
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="buttonId">The ID of the element to be clicked</param>
        public static void WaitClickButtonByID(this IWebDriver driver, WebDriverWait wait, string buttonId)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(buttonId)));
            driver.FindElement(By.Id(buttonId)).Click();
        }


        /// <summary>
        /// Waits for first HTML element with the same Class Name as the one specified to appear and performs a click on it. Does not accept joint classes as parameters
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="cssClass">The Class name of the element to be clicked</param>
        public static void WaitClickButtonByCssClass(this IWebDriver driver, WebDriverWait wait, string cssClass)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(cssClass)));
            driver.FindElement(By.ClassName(cssClass)).Click();
        }

        /// <summary>
        /// Waits for the HTML element with the same XPath as the one specified to appear and performs a click on it
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="xpath">The XPath of the element to be clicked</param>
        public static void WaitClickButtonByXPath(this IWebDriver driver, WebDriverWait wait, string xpath)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            driver.FindElement(By.XPath(xpath)).Click();
        }

        /// <summary>
        /// Waits for HTML element with the same ID as the one specified to appear and performs a click on it
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="buttonCssselector">The CssSelector of the element to be clicked</param>
        public static void WaitClickButtonByCssSelector(this IWebDriver driver, WebDriverWait wait, string buttonCssselector)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(buttonCssselector)));
            driver.FindElement(By.CssSelector(buttonCssselector)).Click();
        }


        /// <summary>
        /// Waits for the HTML element with the same ID as the one specified as the parent to appear and performs a search for the first element inside it with the same Class Name as the specified child to perform a click on it
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="parentId">The ID of the parent element</param>
        /// <param name="childClass">The Class name of the child element to be clicked</param>
        public static void WaitClickButtonChildClassByParentID(this IWebDriver driver, WebDriverWait wait, string parentId, string childClass)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(parentId)));
            driver.FindElement(By.Id(parentId)).FindElement(By.ClassName(childClass)).Click();
        }

        /// <summary>
        /// Waits for the HTML element with the same ID as the one specified to appear and sends the input value defined as parameter
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="id">The ID of the input element</param>
        /// <param name="key">The input value</param>
        public static void WaitSendKeysByID(this IWebDriver driver, WebDriverWait wait, string id, string key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
            driver.FindElement(By.Id(id)).SendKeys(key);
        }

        /// <summary>
        /// Waits for the HTML element with the same ID as the one specified to appear, clears the field entirely and sends the input value defined as parameter
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="id">The ID of the input element</param>
        /// <param name="key">The input value</param>
        public static void WaitClearSendKeysByID(this IWebDriver driver, WebDriverWait wait, string id, string key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
            driver.FindElement(By.Id(id)).Clear();
            driver.FindElement(By.Id(id)).SendKeys(key);
        }

        /// <summary>
        /// Waits for the HTML element with the same Name as the one specified to appear and sends the input value defined as parameter
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="name">The Name of the input element</param>
        /// <param name="key">The input value</param>
        public static void WaitSendKeysByName(this IWebDriver driver, WebDriverWait wait, string name, string key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(name)));
            driver.FindElement(By.Name(name)).SendKeys(key);
        }

        /// <summary>
        /// Waits for the HTML element with the same Name as the one specified to appear, clears the field and sends the input value defined as parameter
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="name">The Name of the input element</param>
        /// <param name="key">The input value</param>
        public static void WaitClearSendKeysByName(this IWebDriver driver, WebDriverWait wait, string name, string key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(name)));
            driver.FindElement(By.Name(name)).Clear();
            driver.FindElement(By.Name(name)).SendKeys(key);
        }


        /// <summary>
        /// Waits for the HTML element with the same Class Name as the one specified to appear and sends the input value defined as parameter
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="cssClass">The Class Name of the input element</param>
        /// <param name="key">The input value</param>
        public static void WaitSendKeysByCssClass(this IWebDriver driver, WebDriverWait wait, string cssClass, string key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(cssClass)));
            driver.FindElement(By.ClassName(cssClass)).SendKeys(key);
        }

        /// <summary>
        /// Waits for the HTML element with the same Class Name as the one specified to appear, clears the field and sends the input value defined as parameter
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="cssClass">The Class Name of the input element</param>
        /// <param name="key">The input value</param>
        public static void WaitClearSendKeysByCssClass(this IWebDriver driver, WebDriverWait wait, string cssClass, string key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(cssClass)));
            driver.FindElement(By.ClassName(cssClass)).Clear();
            driver.FindElement(By.ClassName(cssClass)).SendKeys(key);
        }


        /// <summary>
        /// Waits for the HTML element with the same Css Selector as the one specified to appear and sends the input value defined as parameter
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="cssSelector">The Css Selector of the input element</param>
        /// <param name="key">The input value</param>
        public static void WaitSendKeysByCssSelector(this IWebDriver driver, WebDriverWait wait, string cssSelector, string key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
            driver.FindElement(By.CssSelector(cssSelector)).SendKeys(key);
        }

        /// <summary>
        /// Waits for the HTML element with the same XPath as the one specified to appear and sends the input value defined as parameter
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="xpath">The XPath of the input element</param>
        /// <param name="key">The input value</param>
        public static void WaitSendKeysByXPath(this IWebDriver driver, WebDriverWait wait, string xpath, string key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            driver.FindElement(By.XPath(xpath)).SendKeys(key);
        }

        /// <summary>
        /// Waits for the HTML element with the same XPath as the specified Dropdown to appear and sends the input value defined as parameter 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="xpath">The XPath of the dropdown element</param>
        /// <param name="key">The input value</param>
        public static void WaitSelectDropdownValueByXPath(this IWebDriver driver, WebDriverWait wait, string xpath, string key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath(xpath)));
            dropdown.SelectByValue(key);
        }

        /// <summary>
        /// Waits for the HTML element with the same ID as the specified Dropdown to appear and sends the input value defined as parameter 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="id">The ID of the dropdown element</param>
        /// <param name="key">The input value</param>
        public static void WaitSelectDropdownValueByID(this IWebDriver driver, WebDriverWait wait, string id, string key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id(id)));
            dropdown.SelectByValue(key);
        }

        /// <summary>
        ///  Waits for the HTML element with the same ID as the specified Dropdown to appear and sends the input index value defined as parameter 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="id">The ID of the dropdown element</param>
        /// <param name="key">The index input value</param>
        public static void WaitSelectDropdownIndexByID(this IWebDriver driver, WebDriverWait wait, string id, int key)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id(id)));
            dropdown.SelectByIndex(key);
        }

        /// <summary>
        /// Retrieves an HTML element containing the specified ID
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="id">The ID of the element</param>
        /// <returns></returns>
        public static IWebElement GetElementByID(this IWebDriver driver, string id)
        {
            return driver.FindElement(By.Id(id));
        }


        /// <summary>
        /// Retrieves an HTML element containing the specified Class Name
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="cssClass">The Class Name of the element</param>
        /// <returns></returns>
        public static IWebElement GetElementByCssClass(this IWebDriver driver, string cssClass)
        {
            return driver.FindElement(By.ClassName(cssClass));
        }

        /// <summary>
        /// Retrieves an HTML element containing the specified Css Selector
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="cssSelector">The Css Selector of the element</param>
        /// <returns></returns>
        public static IWebElement GetElementByCssSelector(this IWebDriver driver, string cssSelector)
        {
            return driver.FindElement(By.CssSelector(cssSelector));
        }


        /// <summary>
        /// Retrieves an HTML element containing the specified XPath
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="id">The XPath of the element</param>
        /// <returns></returns>
        public static IWebElement GetElementByXPath(this IWebDriver driver, string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        /// <summary>
        /// Waits for the HTML element with the same ID as the one specified to appear 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="id">The ID of the element to wait for</param>
        public static void WaitByID(this IWebDriver driver, WebDriverWait wait, string id)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
        }

        /// <summary>
        /// Waits for the HTML element with the same ID as the one specified to disappear 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="id">The ID of the element to wait for</param>
        public static void WaitDisappearByID(this IWebDriver driver, WebDriverWait wait, string id)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id(id)));
        }

        /// <summary>
        /// Waits for the HTML element with the same Class Name as the one specified to appear 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="cssClass">The Class Name of the element to wait for</param>
        public static void WaitByCssClass(this IWebDriver driver, WebDriverWait wait, string cssClass)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(cssClass)));
        }

        /// <summary>
        /// Waits for the HTML element with the same Class Name as the one specified to disappear 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="cssClass">The Class Name of the element to wait for</param>
        public static void WaitDisappearByCssClass(this IWebDriver driver, WebDriverWait wait, string cssClass)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName(cssClass)));
        }


        /// <summary>
        /// Waits for the HTML element with the same Css Selector as the one specified to appear 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="cssSelector">The Css Selector of the element to wait for</param>
        public static void WaitByCssSelector(this IWebDriver driver, WebDriverWait wait, string cssSelector)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }

        /// <summary>
        /// Waits for the HTML element with the same Css Selector as the one specified to disappear 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="cssSelector">The Css Selector of the element to wait for</param>
        public static void WaitDisappearByCssSelector(this IWebDriver driver, WebDriverWait wait, string cssSelector)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(cssSelector)));
        }

        /// <summary>
        /// Waits for the HTML element with the same XPath as the one specified to appear 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="xpath">The XPath of the element to wait for</param>
        public static void WaitByXPath(this IWebDriver driver, WebDriverWait wait, string xpath)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        /// <summary>
        /// Waits for the HTML element with the same XPath as the one specified to disappear 
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="xpath">The XPath of the element to wait for</param>
        public static void WaitDisappearByXPath(this IWebDriver driver, WebDriverWait wait, string xpath)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xpath)));
        }

        /// <summary>
        /// Waits for the HTML element with the same XPath as the one specified to appear and returns the number of child elements with the specified tag it contains
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="xpath">The XPath of the parent element to wait for</param>
        /// <param name="tag">The HTML Tag name of the sub elements to count</param>
        /// <returns></returns>
        public static int CountTagsByXPath(this IWebDriver driver, WebDriverWait wait, string xpath, string tag)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            return driver.FindElement(By.XPath(xpath)).FindElements(By.TagName(tag)).Count;
        }


        /// <summary>
        /// Finds the HTML element with the same XPath as the one specified to appear and sends the input value defined as parameter
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="xpath">The XPath of the input element</param>
        /// <param name="key">The input value</param>
        public static void SendKeysByXPath(this IWebDriver driver, string xpath, string key)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(key);
        }


        /// <summary>
        /// Waits for the HTML element with the same ID as the one specified to appear and mouses over it.
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="id">The ID of the element to hover over</param>
        public static void WaitMouseoverByID(this IWebDriver driver, WebDriverWait wait, string id)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
            Actions action = new Actions(driver);
            IWebElement button = driver.FindElement(By.Id(id));
            action.MoveToElement(button).Perform();
        }


        /// <summary>
        /// Waits for the HTML element with the same XPath as the one specified to appear and mouses over it.
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="xpath">The XPath of the element to hover over</param>
        public static void WaitMouseoverByXPath(this IWebDriver driver, WebDriverWait wait, string xpath)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            Actions action = new Actions(driver);
            IWebElement button = driver.FindElement(By.XPath(xpath));
            action.MoveToElement(button).Perform();
        }


        /// <summary>
        /// Waits for the HTML element with the same Class Name as the one specified to appear and mouses over it.
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="cssClass">The Class Name of the element to hover over</param>
        public static void WaitMouseoverByCssClass(this IWebDriver driver, WebDriverWait wait, string cssClass)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(cssClass)));
            Actions action = new Actions(driver);
            IWebElement button = driver.FindElement(By.ClassName(cssClass));
            action.MoveToElement(button).Perform();
        }


        /// <summary>
        /// Waits for the HTML element with the same Css Selector as the one specified to appear and mouses over it.
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="wait">Defines the timeout of the operation</param>
        /// <param name="cssSelector">The Css Selector of the element to hover over</param>
        public static void WaitMouseoverByCssSelector(this IWebDriver driver, WebDriverWait wait, string cssSelector)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
            Actions action = new Actions(driver);
            IWebElement button = driver.FindElement(By.CssSelector(cssSelector));
            action.MoveToElement(button).Perform();
        }

        /// <summary>
        /// Clicks on the first HTML with the same Class Name as he one specified to appear that is currently visible
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="cssClass">The Class Name of the element to click</param>
        public static void ClickByVisibleCssClass(this IWebDriver driver, string cssClass)
        {
            var elementList = (driver.FindElements(By.ClassName(cssClass)));
            var element = elementList[0];

            foreach (var z in elementList)
            {
                if (z.Displayed)
                {
                    element = z;
                    break;
                }
            }
            element.Click();
        }

        /// <summary>
        /// Checks if a file with the same name as the one specified exists in the Downloads folder and deletes it
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="filename">The name of the file to verify</param>
        /// <returns></returns>
        public static bool CheckFileDownloaded(this IWebDriver driver, string filename)
        {
            bool exist = false;
            string Path = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }
        /// <summary>
        /// Verifies if a download is already complete in the specified path
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="downloadsPath">The full path, including the file</param>
        /// <returns></returns>
        public static bool VerifyDownloadStatus(this IWebDriver driver, string downloadsPath)
        {
            for (var i = 0; i < 30; i++)
            {
                if (File.Exists(downloadsPath)) { break; }
                Thread.Sleep(1000);
            }
            if (!File.Exists(downloadsPath))
            {
                return false;
            }

            var length = new FileInfo(downloadsPath).Length;
            for (var i = 0; i < 50; i++)
            {
                Thread.Sleep(1000);
                var newLength = new FileInfo(downloadsPath).Length;
                if (newLength == length && length != 0) { break; }
                length = newLength;
            }
            return true;
        }

        /// <summary>
        /// Retrieves the element with the same ID as the one specified if it exists
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="id">The ID of the element to retrieve</param>
        /// <returns></returns>
        public static IWebElement ElementById(this IWebDriver driver, string id)
        {
            IWebElement e = null;
            try
            {
                e = driver.FindElement(By.Id(id));
            }
            catch (NoSuchElementException) { }
            return e;
        }

        /// <summary>
        /// Retrieves the element with the same Class Name as the one specified if it exists
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="className">The Class Name of the element to retrieve</param>
        /// <returns></returns>
        public static IWebElement ElementByCssClass(this IWebDriver driver, string className)
        {
            IWebElement e = null;
            try
            {
                e = driver.FindElement(By.ClassName(className));
            }
            catch (NoSuchElementException) { }
            return e;
        }


        /// <summary>
        /// Retrieves the element with the same Css Selector as the one specified if it exists
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="cssSelector">The Css Selector of the element to retrieve</param>
        /// <returns></returns>
        public static IWebElement ElementByCssSelector(this IWebDriver driver, string cssSelector)
        {
            IWebElement e = null;
            try
            {
                e = driver.FindElement(By.CssSelector(cssSelector));
            }
            catch (NoSuchElementException) { }
            return e;
        }

        /// <summary>
        /// Retrieves the element with the same XPath as the one specified if it exists
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="xpath">The XPath of the element to retrieve</param>
        /// <returns></returns>
        public static IWebElement ElementByXPath(this IWebDriver driver, string xpath)
        {
            IWebElement e = null;
            try
            {
                e = driver.FindElement(By.XPath(xpath));
            }
            catch (NoSuchElementException) { }
            return e;
        }

        /// <summary>
        /// Checks if a specific element exists
        /// </summary>
        /// <param name="e">The Web element</param>
        /// <returns></returns>
        public static bool Exists(this IWebElement e)
        {
            if (e == null)
                return false;
            return true;
        }

        /// <summary>
        /// Creates a WebDriverWait instance for the amount of seconds required to perform a Timeout operation
        /// </summary>
        /// <param name="driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="seconds">Number of seconds until timeout</param>
        /// <returns></returns>
        public static WebDriverWait TimeoutWindow(this IWebDriver driver, int seconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        }

        /// <summary>
        /// Uses jQuery to set the elements with the ID item.key to the values of item.Value
        /// </summary>
        /// <param name="Driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="List">List containing the IDs in Keys and values in Values.</param>
        public static void SetElementValueByID(this IWebDriver Driver, List<KeyValuePair<string, string>> List)
        {
            foreach (var item in List)
            {
                var jsExecute = "$('#" + item.Key + "').val('" + item.Value + "')";

                ((IJavaScriptExecutor)Driver).ExecuteScript(jsExecute);
            }
        }


        /// <summary>
        /// Uses jQuery to set the elements with the Class Name item.key to the values of item.Value
        /// </summary>
        /// <param name="Driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="List">List containing the Class Names in Keys and values in Values.</param>
        public static void SetElementValueByClassName(this IWebDriver Driver, List<KeyValuePair<string, string>> List)
        {
            foreach (var item in List)
            {
                var jsExecute = "$('." + item.Key + "').val('" + item.Value + "')";

                ((IJavaScriptExecutor)Driver).ExecuteScript(jsExecute);
            }
        }


        /// <summary>
        /// Uses jQuery to execute an action method (item.Value) on the element with the ID of item.Key.
        /// </summary>
        /// <param name="Driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="List">List containing the IDs in Keys and Methods in Values.</param>
        public static void ExecuteActionByID(this IWebDriver Driver, List<KeyValuePair<string, string>> List)
        {
            foreach (var item in List)
            {
                var jsExecute = "$('#" + item.Key + "')." + item.Value + "()";
                ((IJavaScriptExecutor)Driver).ExecuteScript(jsExecute);
            }
        }

        /// <summary>
        /// Uses jQuery to execute an action method (item.Value) on the element with the Class Name of item.Key.
        /// </summary>
        /// <param name="Driver">Current Web Driver running the test. Not required to pass as parameter if called directly by the Driver</param>
        /// <param name="List">List containing the Class Names in Keys and Methods in Values.</param>
        public static void ExecuteActionByCssClass(this IWebDriver Driver, List<KeyValuePair<string, string>> List)
        {
            foreach (var item in List)
            {
                var jsExecute = "$('." + item.Key + "')." + item.Value + "()";
                ((IJavaScriptExecutor)Driver).ExecuteScript(jsExecute);
            }
        }
    }
}
