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
        /// Открыть первый документ в списке
        /// </summary>
        public IncomingDocumentsHelper GoToCardOfDocument()
        {
            var currentSelector = By.XPath("//*[contains(text(), 'Загрузка документов')]");
            WaitUntilElementIsNotVisible(currentSelector, 40);
            //GetElement(By.XPath("//*[contains(text(),'.doc')]")).Click();
            List<IWebElement> listOfDocuments = GetElements(By.ClassName("c-doc"));
            listOfDocuments[0].Click();

            return this;
        }


        /// <summary>
        /// Подписание документа в карточке
        /// </summary>
        public IncomingDocumentsHelper AcceptDocument()
        {
            var btnAccept = By.XPath("//button[.='Подписать']");
            WaitForElementIsVisible(btnAccept, 15);
            GetElement(btnAccept).Click();

            var loading = By.CssSelector("loading-overlay--div");
            WaitUntilElementIsNotVisible(loading,15);

            var modalAcc = By.ClassName("tc-modal-header");

            try
            {
                if (driver.FindElement(By.ClassName("tc-modal-header")).Enabled)
                {
                    driver.SwitchTo().ActiveElement();
                    var btnConfirmation = By.XPath("//button[.='Принять']");
                    WaitForElementIsVisible(btnConfirmation, 15);
                    GetElement(btnConfirmation).Click();
                    //TODO добавить заполнение полномочий при возникновении ошибки "Неправильно заполнен блок полномочий"

                    WaitUntilElementIsNotVisible(modalAcc, 10);

                    return this;
                }
            }
            catch
            {

            }


            return this;
        }

        /// <summary>
        /// Отклонение документа в карточке
        /// </summary>
        public IncomingDocumentsHelper RejectDocument()
        {
            var btnReject = By.XPath("//button[.='Отказать']");
            WaitForElementIsVisible(btnReject, 15);
            GetElement(btnReject).Click();

            var loading = By.CssSelector("loading-overlay--div");
            WaitUntilElementIsNotVisible(loading, 15);

            var modalRej = By.ClassName("tc-modal-header");
            WaitForElementIsVisible(modalRej,15);

            driver.SwitchTo().ActiveElement();
            driver.FindElements(By.XPath("//button[.='Отказать']"))[1].Click();
            WaitUntilElementIsNotVisible(modalRej, 10);

            return this;
        }

        //TODO вынести методы по фильтрам в отдельный класс
        /// <summary>
        /// Установка фильтра в списке входящих
        /// </summary>
        public IncomingDocumentsHelper FiltrOfIncomingDocuments(int state)
        {

            //TODO добавить ожидание исчезновения лоадинга
            var filter = By.Name("filter");
            GetElement(filter).Click();

            //получаем список фильтров
            List<IWebElement> listOfSelects = GetElements(By.CssSelector(".Select-arrow"));
            WaitUntilElementIsNotVisible(By.CssSelector("loading-overlay--div"), 10);
            listOfSelects[0].Click();

            //получаем список статусов
            List<IWebElement> listOfStates = GetElements(By.CssSelector(".Select-option"));
            listOfStates[state].Click();

            return this;
        }


        /// <summary>
        /// Нажатие кнопки "Найти" в фильтре
        /// </summary>
        public IncomingDocumentsHelper ClickFoundInFilter()
        {
            GetElement(By.XPath("//button[.='Найти']")).Click();

            return this;
        }


        /// <summary>
        /// Проверка статуса после подписания входящего документа
        /// </summary>
        public IncomingDocumentsHelper CheckingStateOfDocument(string state)
        {
            var loading = By.CssSelector("loading-overlay--div");
            WaitUntilElementIsNotVisible(loading, 20);

            WaitForElementIsVisible(By.XPath("//div[@class='c-flex']/p"), 20);
            var actualState = GetElement(By.XPath("//div[@class='c-flex']/p")).Text;
            switch (state)
            {
                case "Отказано":
                    Assert.AreEqual("Отказано (Посмотреть комментарий)", actualState);
                    break;

                case "Выставлен":
                    Assert.AreEqual("Выставлен ", actualState);
                    break;

                case "Отправлен":
                    Assert.True(actualState.Equals("Отправлен ") | actualState.Equals("Завершен "));
                    break;

                case "Завершен":
                    Assert.True(actualState.Equals("Отправлен ") | actualState.Equals("Завершен "));
                    break;

                case "На подписи":
                    Assert.AreEqual("На подписи ", actualState);
                    break;

                case "Требуется подпись":
                    Assert.AreEqual("Требуется подпись ", actualState);
                    break;

                case "Ожидается аннулирование":
                    Assert.AreEqual("Ожидается аннулирование ", actualState);
                    break;

                case "Требуется аннулирование":
                    Assert.AreEqual("Требуется аннулирование ", actualState);
                    break;

                case "Аннулирован":
                    Assert.AreEqual("Аннулирован ", actualState);
                    break;
            }
            return this;
        }
    }
}
    

