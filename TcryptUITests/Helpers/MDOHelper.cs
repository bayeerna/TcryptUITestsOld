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
        public MDOCreateHelper SelectTypeOfDocument()
        {
            GetElement(By.XPath("//div[@id='react-select-4--value']/div[@class='Select-value']")).Click();
            GetElement(By.XPath("//*[contains(text(), 'Акт о приеме-передаче')]")).Click();
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

    }
}
