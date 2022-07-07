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
    public class MDOCreateHelper : HelperBase
    {
        public MDOCreateHelper(ApplicationManager manager)
        : base(manager)
        {
        }

        /// <summary>
        /// Выбрать получателя
        /// </summary>
        public MDOCreateHelper SelectRecipient(string INN, string nameOfOrganisation)
        {
            //Поиск поля "Получатель"
            var recipientField = By.XPath("//input[@name='учреждениему/муп']");                                                                                                                         /// 
            WaitForElementIsVisible(recipientField, 10);
            GetElement(recipientField).Click();

            //Ввод данных получателя
            GetElement(recipientField).SendKeys(INN);

            //Выбор из списка
            Thread.Sleep(10000);
            var recipient = By.XPath("//*[contains(text(),'" + nameOfOrganisation + "')]");
            WaitForElementIsVisible(recipient, 10);
            GetElement(recipient).Click();

            //Для случаев, когда выпадающий список не закрылся - кликаем в любое место на странице для его закрытия
            IWebElement listOfRecipient = GetElement(By.Id("react-autowhatever-organization-name"));
            if (listOfRecipient.Displayed)
            {
                GetElement(By.XPath("//body")).Click();
            }

            return this;
        }

        /// <summary>
        /// Заполнить тему
        /// </summary>
        public MDOCreateHelper EnterTopic()
        {
            var inputTopic = By.XPath("//*[@id='title']");
            GetElement(inputTopic).SendKeys("autotest");
            return this;
        }

        /// <summary>
        /// Выбрать тип документа
        /// </summary>
        public MDOCreateHelper SelectTypeOfDocument(string type)
        {
            /*GetElement(By.XPath("//div[@id='react-select-4--value']/div[@class='Select-value']")).Click();
            //GetElement(By.XPath("//*[contains(text(), 'Акт о приеме-передаче')]")).Click();////div[@class='Select-menu-outer']//div[@title='Любой']
            GetElement(By.XPath(
                "div[@class='Select-menu-outer']//div[@title='Акт приема-передачи техники (орг.техники)']")).Click();*/

            Actions actions = new Actions(driver);
            GetElement(By.XPath("//div[@id='react-select-4--value']/div[@class='Select-value']")).Click();
            switch (type)
            {
                case "Акт приема-передачи техники (орг.техники)":
                    IWebElement type1 = driver.FindElement(By.XPath("//*[contains(text(), 'Акт приема-передачи техники (орг.техники)')]"));
                    actions.MoveToElement(type1).Click().Build().Perform();
                    break;

                case "Акт о приеме-передаче объектов нефинансовых активов":
                    IWebElement type2 = driver.FindElement(By.XPath("//*[contains(text(), 'Акт о приеме-передаче объектов нефинансовых активов')]"));
                    actions.MoveToElement(type2).Click().Build().Perform();
                    break;

                case "Договор":
                    IWebElement type3 = driver.FindElement(By.XPath("//*[contains(text(), 'Договор')]"));
                    actions.MoveToElement(type3).Click().Build().Perform();
                    break;
            }
            return this;
        }

        /// <summary>
        /// Нажать кнопку "Отправить"
        /// </summary>
        public MDOCreateHelper SendDocumentOfMDO()
        {
            var btnSend = By.XPath("//button[@type='submit']");                                                                                                                         /// 
            WaitForElementToBeClickable(btnSend, 10);
            GetElement(btnSend).Click();
            return this;
        }

        /// <summary>
        /// Перейти в раздел "ЭДО по маршруту"
        /// </summary>
        public MDOCreateHelper GoToEDOPage()
        {
            driver.FindElements(By.XPath("//a[@class='c-section__link c-section__link--multilateral']/span[text()='ЭДО по маршруту']"))[1].Click();

            var loading = By.XPath("//p[text()='Загрузка документов...']");
            WaitUntilElementIsNotVisible(loading, 15);
            return this;
        }

        /// <summary>
        /// Согласование маршрутного ДО в карточке
        /// </summary>
        public MDOCreateHelper ApprovalDocument()
        {
            var btnApproval = By.XPath("//button[text()='Согласовать']");                                                                                                                         /// 
            WaitForElementToBeClickable(btnApproval, 10);
            GetElement(btnApproval).Click();

            var inputComment = By.XPath("//textarea[@name='userComment']");
            GetElement(inputComment).SendKeys("Согласование автотест");

            var btnConfirmApproval = By.XPath("//div[@class='c-flex pr-2']/button[text()='Согласовать']");
            GetElement(btnConfirmApproval).Click();

            var commentField = By.XPath("//span[@class='accordion__content__comment--text']");
            WaitForElementIsVisible(commentField,15);
            var commentText= GetElement(By.XPath("//span[@class='accordion__content__comment--text']")).Text;
            Assert.AreEqual("Согласование автотест", commentText);
            return this;
        }

        /// <summary>
        /// Отклонение маршрутного ДО в карточке
        /// </summary>
        public MDOCreateHelper RejectlDocument()
        {
            var btnReject = By.XPath("//button[text()='Отказать']");                                                                                                                         /// 
            WaitForElementToBeClickable(btnReject, 10);
            GetElement(btnReject).Click();

            var inputComment = By.XPath("//textarea[@placeholder='Введите причину отказа']");
            GetElement(inputComment).SendKeys("Отклонение автотест");

            var btnConfirmReject = By.XPath("//div[@class='c-flex pr-2']/button[text()='Отказать']");
            GetElement(btnConfirmReject).Click();

            var stateReject = By.XPath("//div[@class='package-contents__document-state package-contents__document-state--refused package-contents__document-state__rejection-reason']");
            WaitForElementIsVisible(stateReject, 15);
            return this;
        }

    }
}
