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
    public class FilterHelper : HelperBase
    {
        public FilterHelper(ApplicationManager manager)
        : base(manager)
        {
        }

        public FilterHelper OpenFilter()
        {
            //Нажимаем на кнопку фильтра
            var btnFilter = By.XPath("//button[@name='filter']");
            WaitForElementToBeClickable(btnFilter, 15);
            GetElement(btnFilter).Click();

            var modalFilter = By.Id("filter-content");
            WaitForElementIsVisible(modalFilter, 15);

            return this;
        }

        public FilterHelper ClickFoundInFilter()
        {
            var btnFound = By.XPath("//*[contains(text(), 'Найти')]");
            WaitForElementToBeClickable(btnFound, 15);
            GetElement(btnFound).Click();

            return this;
        }

        /// <summary>
        /// Выбор статуса
        /// </summary>
        /// <param name="state">Статус документа</param>
        /// <returns></returns>
        public FilterHelper SelectStateOfDocument(string state)
        {
            //OpenFilter();
            Actions actions = new Actions(driver);
            List<IWebElement> listOfSelects = GetElements(By.CssSelector(".Select-arrow"));
            listOfSelects[0].Click();

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

                case "Требуется подпись":
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

                case "В процессе":
                    var state9 = GetElement(By.XPath("//div[@class='Select-menu-outer']//div[@title='В процессе']"));
                    actions.MoveToElement(state9);
                    actions.Perform();
                    state9.Click();
                    break;
            }
            return this;
        }

        /// <summary>
        /// Выбор признака "Требуется действие"
        /// </summary>
        /// <returns></returns>
        public FilterHelper SelectNeedAction()
        {
            var btnNeedAction = By.XPath("//label[@for='needAction1']");
            WaitForElementToBeClickable(btnNeedAction, 15);
            GetElement(btnNeedAction).Click();

            return this;
        }

        /// <summary>
        /// Ввод данных в поле "Тема"
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public FilterHelper FillTopic(string topic)
        {
            var inputTopic = By.XPath("//input[@name='routingworkflowTheme']");
            WaitForElementToBeClickable(inputTopic, 15);
            GetElement(inputTopic).SendKeys(topic);
            return this;
        }
    }
}
