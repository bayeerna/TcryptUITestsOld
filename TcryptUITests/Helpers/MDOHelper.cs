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
            //var recipientField = By.XPath("//input[@type='text']");
            var recipientField = By.XPath("//*[@id=\"root\"]/main/section/div/section/section/form/div/div[1]/div[1]/div/div/input");
            WaitForElementIsVisible(recipientField, 10);
            GetElement(recipientField).Click();

            //Ввод данных получателя
            GetElement(recipientField).SendKeys(INN);

            //Выбор из списка
            Thread.Sleep(10000);
            var recipient = By.XPath("//*[contains(text(),'" + nameOfOrganisation + "')]");
            WaitForElementIsVisible(recipient, 10);
            GetElement(recipient).Click();

            IWebElement listOfRecipient = GetElement(By.Id("react-autowhatever-organization-name"));
            if (listOfRecipient.Displayed)
            {
                GetElement(By.XPath("//body")).Click();
            }

            return this;
        }

        public MDOCreateHelper EnterTopic()
        {
            var inputTopic = By.XPath("//*[@id='title']");
            GetElement(inputTopic).SendKeys("autotest");
            return this;
        }

        public MDOCreateHelper SelectTypeOfDocument()
        {
            driver.FindElements(By.XPath("//*[@class='Select-value-label']"))[1].Click();
            //GetElement(By.XPath("//*[@class='Select-value-label']")).Click();
            GetElement(By.XPath("//*[contains(text(), 'Акт о приеме-передаче')]")).Click();
            return this;
        }

        public MDOCreateHelper SendDocumentOfMDO()
        {
            GetElement(By.XPath("//*[@id=\"root\"]/main/section/div/section/section/form/div/div[5]/button")).Click();
            return this;
        }

    }
}
