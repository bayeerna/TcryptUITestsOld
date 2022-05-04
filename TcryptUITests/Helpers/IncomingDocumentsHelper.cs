using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using TcryptUITests;

namespace Taxnet.Tcrypt.Autotests
{
    public class IncomingDocumentsHelper : HelperBase
    {
        public IncomingDocumentsHelper(ApplicationManager manager)
            : base(manager) {}

        /// <summary>
        /// Переход к карточке документа
        /// </summary>
        public IncomingDocumentsHelper GoToCardOfDocument()
        {
            //driver.FindElements(By.XPath("//*[@id=intro-inbox-aside-link"))[1].Click();
            var currentSelector = By.XPath("//*[contains(text(), 'Загрузка документов')]");
            WaitUntilElementIsNotVisible(currentSelector, 40);
            GetElement(By.XPath("//*[contains(text(),'.doc')]")).Click();

            var btnAccept = By.XPath("//button[.='Подписать']");
            WaitForElementIsVisible(btnAccept,15);
            GetElement(By.XPath("//button[.='Подписать']")).Click();

            var loading = By.CssSelector("loading-overlay--div");
            WaitForElementIsVisible(loading, 15);
            return this;
        }

        /// <summary>
        /// Подписание документа в карточке
        /// </summary>
        public IncomingDocumentsHelper AcceptDocument()
        {
            var btnAccept = By.XPath("//button[.='Подписать']");
            WaitForElementIsVisible(btnAccept, 15);
            GetElement(By.XPath("//button[.='Подписать']")).Click();

            var loading = By.CssSelector("loading-overlay--div");
            WaitForElementIsVisible(loading, 15);

            return this;
        }

        /// <summary>
        /// Отклонение документа в карточке
        /// </summary>
        public IncomingDocumentsHelper RejectDocument()
        {
            var btnAccept = By.XPath("//button[.='Отказать']");
            WaitForElementIsVisible(btnAccept, 15);
            GetElement(By.XPath("//button[.='Отказать']")).Click();

            var loading = By.CssSelector("loading-overlay--div");
            WaitForElementIsVisible(loading, 15);

            return this;
        }



        /// <summary>
        /// Установка фильтра
        /// </summary>
        public IncomingDocumentsHelper FiltrOfIncomingDocuments(int state)
        {
            var filter = By.Name("filter");
            GetElement(filter).Click();
            Actions actions = new Actions(driver);

            List<IWebElement> listOfSelects = GetElements(By.CssSelector(".Select-arrow"));
            WaitUntilElementIsNotVisible(By.CssSelector("loading-overlay--div"), 10);
            listOfSelects[0].Click();

            List<IWebElement> listOfStates = GetElements(By.CssSelector(".Select-option"));
            listOfStates[state].Click();

            GetElement(By.XPath("//button[.='Найти']")).Click();

            return this;
        }


    }

}
    

