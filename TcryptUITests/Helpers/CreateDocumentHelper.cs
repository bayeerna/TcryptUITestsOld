using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using TcryptUITests;

namespace Taxnet.Tcrypt.Autotests
{
    public class CreateDocumentHelper : HelperBase
    {
        
        private readonly string filesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files\\");

        public CreateDocumentHelper(ApplicationManager manager)
        : base(manager)
        {
        }

        /// <summary>
        /// Нажатие кнопки "Создать документ"
        /// </summary>
        public CreateDocumentHelper ClickCreateDocumentButton()
        {
            Thread.Sleep(1000);
            driver.FindElements(By.XPath("//a[@id='create-document-js']"))[1].Click();
            var currentSelector = By.XPath("//*[contains(text(), 'Подождите, идет загрузка')]");
            WaitUntilElementIsNotVisible(currentSelector, 40);
            return this;
        }

        /// <summary>
        /// Загрузка документа
        /// </summary>
        public CreateDocumentHelper UploadDocument(string filepath)
        {
            driver.FindElement(By.XPath("//input[@type='file']"))
            .SendKeys(Path.Combine(filesFolder + filepath));
            Thread.Sleep(4000);
            return this;
        }

        /// <summary>
        /// Сохранение черновика
        /// </summary>
        public CreateDocumentHelper SaveDraft()
        {
            var saveButton = By.Id("saveDraftButton");
            ScrollToElement(driver.FindElement(saveButton));
            WaitForElementToBeClickable(saveButton, 10);
            GetElement(saveButton).Click();

            var closeButton = By.XPath("//button[.='Закрыть']");
            WaitForElementIsVisible(closeButton, 10);
            GetElement(closeButton).Click();
            return this;
        }

        /// <summary>
        /// Очищает форму создания документа (от файлов и получателя)
        /// </summary>
        public CreateDocumentHelper ClickClearButton()
        {
            var clearButton = By.XPath("//button[.='Очистить все данные']");
            WaitForElementIsVisible(clearButton, 70); //на случай, если долго открывается мастер создания документа. 
            GetElement(clearButton).Click();
            
            //нажатие на кнопку Да, для подтверждения очистки формы
            var confirmButtonForClearForm = By.Id("confirmation-success");
            WaitForElementIsVisible(confirmButtonForClearForm, 10);
            GetElement(confirmButtonForClearForm).Click();
            WaitUntilElementIsNotVisible(confirmButtonForClearForm, 10);
            return this;
        }

        /// <summary>
        /// Выбрать получателя
        /// </summary>
        public CreateDocumentHelper SelectRecipient(string INN, string department, string nameOfOrganisation)
        {
            //Поиск поля "Получатель"
            var recipientField = By.XPath("//*[@id=\"root\"]/main/section/div/section/section/form/div[2]/div[1]/div/div/input"); //TODO изменить селектор
            WaitForElementIsVisible(recipientField, 10);
            GetElement(recipientField).Click();
           
            //Ввод данных получателя
            GetElement(recipientField).SendKeys(INN);

            //Выбор из списка
            Thread.Sleep(10000); //TODO убрать паузу
            var recipient = By.XPath("//*[contains(text(),'" + nameOfOrganisation + "')]");
            WaitForElementIsVisible(recipient, 10);
            GetElement(recipient).Click();

            IWebElement listOfRecipient = GetElement(By.Id("react-autowhatever-organization-name"));
            if (listOfRecipient.Displayed)
            {
                GetElement(By.XPath("//body")).Click();
            }

            //Выбор подразделения
            var departmentField = By.CssSelector("#contragent-department-input > div > input");
            GetElement(departmentField).Click();
            //actions.MoveToElement(driver.FindElement(By.CssSelector("#contragent-department-input > div > input"))).Click().Build().Perform();
            
            GetElement(departmentField).SendKeys(department);

            GetElement(By.CssSelector("[data-contact*=\"Головное подразделение\"]")).Click();

            return this;
        }

        /// <summary>
        /// Отправка документа
        /// </summary>
        public CreateDocumentHelper ClickSendDocumentButton()
        {
            WaitForElementIsVisible(By.Id("signAndSendButtonId"),10);
            ScrollToElement(driver.FindElement(By.Id("signAndSendButtonId")));
            GetElement(By.Id("signAndSendButtonId")).Click();

            WaitForElementIsVisible(By.Id("closeBtn"), 5);
            GetElement(By.Id("closeBtn")).Click();
            WaitUntilElementIsNotVisible(By.Id("closeBtn"), 5);
            return this;
        }


        /// <summary>
        /// закрытие модального окна Загруженный документ не соответствует формату 
        /// </summary>
        /// <returns></returns>
        public CreateDocumentHelper CloseInfoModalWindow()
        {
            //var currentSelector = By.Id("close-info-model");
            driver.FindElement(By.Id("close-info-model")).Click();
            //GetElement(currentSelector).Click();

            return this;

        }

        /// <summary>
        /// проверяет, что файл загрузился
        /// </summary>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public CreateDocumentHelper CheckFileUploaded(string documentName) //TODO добавить в тесты
        {
            var uploadedFile = By.CssSelector(".uploaded-doc__info__name");
            //WaitForElementIsVisible(documentName, 7);
            Assert.True(driver.PageSource.Contains(documentName));
            return this;
        }

        public CreateDocumentHelper GoToEdoPage()
        {
            var edoTab = By.XPath("/html/body/div[1]/main/section/div/section/div/a[2]");
            WaitForElementIsVisible(edoTab,10);
            GetElement(edoTab).Click();
            return this;
        }

        public CreateDocumentHelper SelectTypeOfEdo(string type)
        {
            Actions actions = new Actions(driver);
            GetElement(By.CssSelector(".Select-value")).Click();
            switch (type)
            {
                case "Договор оперативного управления":
                    IWebElement status1 = driver.FindElement(By.XPath("//*[contains(text(), 'Договор оперативного управления/хозяйственного ведения и актов приёма-передачи имущества')]"));
                    actions.MoveToElement(status1).Click().Build().Perform();
                    break;

                case "Договор безвозмездного пользования":
                    IWebElement status2 = driver.FindElement(By.CssSelector("//*[contains(text(), 'Договор безвозмездного пользования')]"));
                    actions.MoveToElement(status2).Click().Build().Perform();
                    break;
            }
            return this;
        }


        /*public CreateDocumentHelper StopMessageProcessing()
        {
            var currentSelector = By.XPath("//button[.='Остановить']");
            IWebElement stopMessageProcessingButton = driver.FindElement(currentSelector);

            if (GetElement(By.XPath("//button[.='Остановить']")).Displayed)
            {
                try
                {
                    stopMessageProcessingButton.Click();
                    WaitUntilElementIsNotVisible(currentSelector, 70);
                }
                catch { };

            }
            return this;
        }*/
    }
    }


