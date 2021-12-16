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

    public class PrintFormsHelper : HelperBase
    {
        public PrintFormsHelper(ApplicationManager manager) : base(manager)
        {
        }

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



    }
}
