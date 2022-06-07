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

namespace Taxnet.Tcrypt.Autotests
{
    public class SearchHelper : HelperBase
    {
        public SearchHelper(ApplicationManager manager)
        : base(manager)
        {
        }

        /// <summary>
        /// Заполнение параметров поиска
        /// </summary>
        /// <param name="state">Область полномочий</param>
        /// <param name="status">Статус</param>
        /// <param name="post">Должность</param>
        /// <param name="basis">Основание</param>
        public SearchHelper FillSearchParameters(string type, string state, string folder)
        {
            //Нажимаем на строку поиска
            GetElement(By.ClassName("search__input")).Click();
            GetElement(By.Id("search-advanced")).Click();

            var modalSearch = By.ClassName("advanced-search");
            WaitForElementIsVisible(modalSearch, 15);

            SelectTypeOfDocuments(type);
            SelectStateOfDocument(state);
            SelectFolder(folder);

            var btnFound = GetElement(By.XPath("//*[contains(text(), 'Найти')]"));
            actions.MoveToElement(btnFound);
            actions.Perform();
            btnFound.Click();

            return this;
        }


        /// <summary>
        /// Выбор типа документа
        /// </summary>
        /// <param name="type">Тип документа</param>
        /// <returns></returns>
        public SearchHelper SelectTypeOfDocuments(string type)
        {

            //Клик на селект "Тип документа"

            Actions actions = new Actions(driver);
            List<IWebElement> listOfSelects = GetElements(By.CssSelector(".Select-arrow"));

            listOfSelects[0].Click();

            switch (type)
            {
                case "Любой":

                    var type0 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Любой']"));
                    actions.MoveToElement(type0);
                    actions.Perform();
                    type0.Click();
                    break;

                case "Неизвестный":

                    var type1 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Неизвестный']"));
                    actions.MoveToElement(type1);
                    actions.Perform();
                    type1.Click();
                    break;

                case "УКД":

                    var type2 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Универсальный корректировочный документ']"));
                    ScrollToElement(type2);
                    actions.MoveToElement(type2);
                    actions.Perform();
                    type2.Click();
                    break;

                case "УПД820":

                    var type3 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Универсальный передаточный документ (формата 820 приказа)']"));
                    ScrollToElement(type3);
                    actions.MoveToElement(type3);
                    actions.Perform();
                    type3.Click();
                    break;
            }
            return this;
        }



        /// <summary>
        /// Выбор статуса
        /// </summary>
        /// <param name="state">Статус документа</param>
        /// <returns></returns>
        public SearchHelper SelectStateOfDocument(string state)
        {
            Actions actions = new Actions(driver);
            //Клик на селект "Область полномочий для исходящих"
            List<IWebElement> listOfSelects = GetElements(By.CssSelector(".Select-arrow"));
            listOfSelects[1].Click();

            switch (state)
            {
                case "Любой":
                    var state0 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Любой']"));
                    actions.MoveToElement(state0);
                    actions.Perform();
                    state0.Click();
                    break;

                case "Выставлен":
                    var state1 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Выставлен']"));
                    actions.MoveToElement(state1);
                    actions.Perform();
                    state1.Click();
                    break;

                case "На подписи/Требуется подпись":
                    var state2 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='На подписи/Требуется подпись']"));
                    actions.MoveToElement(state2);
                    actions.Perform();
                    state2.Click();
                    break;

                case "Отказано":
                    var state3 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Отказано']"));
                    actions.MoveToElement(state3);
                    actions.Perform();
                    state3.Click();
                    break;

                case "Отправлено":
                    var state4 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Отправлено']"));
                    actions.MoveToElement(state4);
                    actions.Perform();
                    state4.Click();
                    break;

                case "Завершен":
                    var state5 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Завершен']"));
                    actions.MoveToElement(state5);
                    actions.Perform();
                    state5.Click();
                    break;

                case "Ожидается аннулирование":
                    var state6 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Ожидается аннулирование']"));
                    actions.MoveToElement(state6);
                    actions.Perform();
                    state6.Click();
                    break;

                case "Требуется аннулирование":
                    var state7 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Требуется аннулирование']"));
                    actions.MoveToElement(state7);
                    actions.Perform();
                    state7.Click();
                    break;

                case "Аннулирован":
                    var state8 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Аннулирован']"));
                    actions.MoveToElement(state8);
                    actions.Perform();
                    state8.Click();
                    break;
            }
            return this;
        }

        /// <summary>
        /// Выбор типа документа
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <returns></returns>
        public SearchHelper SelectFolder(string folder)
        {

            //Клик на селект "Искать в папке"
            Actions actions = new Actions(driver);

            List<IWebElement> listOfSelects = GetElements(By.CssSelector(".Select-arrow"));

            listOfSelects[2].Click();

            switch (folder)
            {
                case "Везде":

                    var folder0 = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Везде']"));
                    actions.MoveToElement(folder0);
                    actions.Perform();
                    folder0.Click();
                    break;

                case "Входящие":

                    var folder1 = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Входящие']"));
                    actions.MoveToElement(folder1);
                    actions.Perform();
                    folder1.Click();
                    break;

                case "Исходящие":

                    var folder2 = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Исходящие']"));
                    actions.MoveToElement(folder2);
                    actions.Perform();
                    folder2.Click();
                    break;

                case "Черновики":

                    var folder3 = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Черновики']"));
                    actions.MoveToElement(folder3);
                    actions.Perform();
                    folder3.Click();
                    break;

                case "Удаленные":

                    var folder4 = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='Удаленные']"));
                    actions.MoveToElement(folder4);
                    actions.Perform();
                    folder4.Click();
                    break;
            }
            return this;
        }
    }
}
