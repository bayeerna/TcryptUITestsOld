namespace TcryptUITests.Helpers
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxnet.Tcrypt.Autotests;
using OpenQA.Selenium;
using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium.Support.UI;

    public class PrintFormsHelper : HelperBase
    {
        public PrintFormsHelper(ApplicationManager manager) : base(manager)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        private IReadOnlyCollection<object> windowHandles; 

        /// <summary>
        /// нажатие на кнопку Просмотреть для открытия печатной формы на экране создания документа
        /// </summary>
        /// <returns></returns>
        public PrintFormsHelper OpenPrintForm()
        {
            var currentSelector = By.Id("actionType-view");
            WaitForElementIsVisible(currentSelector, TimeLimit); 
            GetElement(currentSelector).Click();
            Thread.Sleep(1000); 
            return this;
        }


        /// <summary>
        /// Закрытие печатной формы 
        /// </summary>
        /// <returns></returns>
        public PrintFormsHelper ClosePrintForm()
        {
            var currentSelector = By.CssSelector(".tc-modal-close-btn");
            WaitForElementIsVisible(currentSelector, TimeLimit); 
            GetElement(currentSelector).Click(); 


            return this; 

        }

        /// <summary>
        /// нажатие на кнопку Просмотреть для открытия печатной формы на экране создания документа
        /// </summary>
        /// <returns></returns>
        public PrintFormsHelper OpenPrintedWithES()
        {
            var currentSelector = By.XPath("//*[@id=\"selected-document-placeholder\"]/div[1]/div/div[3]/div/div/a");
            WaitForElementIsVisible(currentSelector, TimeLimit);
            GetElement(currentSelector).Click();
            return this;
        }

        /// <summary>
        /// Проверка открытия печатной формы со штампами
        /// </summary>
        public PrintFormsHelper CheckingPrintFormWithStamp()
        {
            //Store the ID of the original window
            string originalWindow = driver.CurrentWindowHandle;

            //Проверяем, что открыты две вкладки
            Assert.AreEqual(driver.WindowHandles.Count, 2);

            //Переключаемся на вкладку с ПФ
            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }

            Thread.Sleep(10000);
            string actResult = driver.Title;

            string expResult = "PrintFromWithStamp";
            
            Assert.AreEqual(expResult, actResult);
            return this;

        }
    }
}
