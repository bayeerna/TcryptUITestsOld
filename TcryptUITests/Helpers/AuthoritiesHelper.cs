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
    public class AuthoritiesHelper:HelperBase
    {
        public AuthoritiesHelper(ApplicationManager manager)
        : base(manager)
        {
        }

        /// <summary>
        /// Заполнение полномочий
        /// </summary>
        /// <param name="scope">Область полномочий</param>
        /// <param name="status">Статус</param>
        /// <param name="post">Должность</param>
        /// <param name="basis">Основание</param>
        public AuthoritiesHelper InputAuthorities(int scope, int status, string post, string basis)
        {
            //скроллим страницу до нужно элемента
            ScrollToElement(GetElement(By.Id("edit-authorities-intro")));
            //Нажимаем на кнопку "Редактировать полномочия"
            GetElement(By.Id("edit-authorities-intro")).Click();
            SelectScopeForOutgoingDocuments(scope);
            SelectStatus(status);
            InputPost(post);
            InputBasis(basis);
            GetElement(By.Id("save-authorities")).Click();
            /*if (GetElement(By.Id("confirmation-success")).Displayed)
            {
                GetElement(By.Id("confirmation-success")).Click();
            }*/
            try
            {
                driver.FindElement(By.Id("confirmation-success")).Click();
            }
            catch (Exception)
            {
            }
            return this;
        }

        /// <summary>
        /// Выбор Области полномочий
        /// </summary>
        /// <param name="scope">Область полномочий</param>
        /// <returns></returns>
        public AuthoritiesHelper SelectScopeForOutgoingDocuments(int scope)
        {
            Actions actions = new Actions(driver);
            //Клик на селект "Область полномочий для исходящих"
            List<IWebElement> listOfSelects = GetElements(By.CssSelector(".Select-arrow"));
            WaitUntilElementIsNotVisible(By.CssSelector("loading-overlay--div"), 10);
            listOfSelects[0].Click();

            switch (scope)
            {
                case 0:
                    IWebElement scope0 = driver.FindElement(By.XPath("//*[contains(text(), 'Лицо, ответственное за подписание счетов-фактур')]"));
                    actions.MoveToElement(scope0).Click().Build().Perform();
                    break;

                case 1:
                    IWebElement scope1 = driver.FindElement(By.XPath("//*[contains(text(), 'Лицо, совершившее сделку, операцию')]"));
                    actions.MoveToElement(scope1).Click().Build().Perform();
                    break;

                case 2:
                    IWebElement scope2 = driver.FindElement(By.XPath("//*[contains(text(), 'Лицо, совершившее сделку, операцию и ответственное за ее оформление')]"));
                    actions.MoveToElement(scope2).Click().Build().Perform();
                    break;

                case 3:
                    IWebElement scope3 = driver.FindElement(By.XPath("//*[contains(text(), 'Лицо, ответственное за оформление свершившегося события')]"));
                    actions.MoveToElement(scope3).Click().Build().Perform();
                    break;

                case 4:
                    IWebElement scope4 = driver.FindElement(By.XPath("//*[contains(text(), 'Лицо, совершившее сделку, операцию и ответственное за подписание счетов-фактур')]"));
                    actions.MoveToElement(scope4).Click().Build().Perform();
                    break;

                case 5:
                    IWebElement scope5 = driver.FindElement(By.XPath("//*[contains(text(), 'Лицо, совершившее сделку, операцию и ответственное за ее оформление и за подписание счетов-фактур')]"));
                    actions.MoveToElement(scope5).Click().Build().Perform();
                    break;

                case 6:
                    IWebElement scope6 = driver.FindElement(By.XPath("//*[contains(text(), 'Лицо, ответственное за оформление свершившегося события и за подписание счетов-фактур')]"));
                    actions.MoveToElement(scope6).Click().Build().Perform();
                    break;
            }
            return this;
        }

        /// <summary>
        /// Выбор статуса сотрудника
        /// </summary>
        /// <param name="status">статус</param>
        /// <returns></returns>
        public AuthoritiesHelper SelectStatus(int status)
        {
            Actions actions = new Actions(driver);
            //Клик на селект "Статус"
            List<IWebElement> listOfSelects = GetElements(By.CssSelector(".Select-arrow"));
            listOfSelects[1].Click();
            switch (status)
            {
                case 1:
                    IWebElement status1 = driver.FindElement(By.XPath("//*[contains(text(), 'Работник организации продавца или покупателя')]"));
                    actions.MoveToElement(status1).Click().Build().Perform();
                    break;

                case 2:
                    IWebElement status2 = driver.FindElement(By.XPath("//*[contains(text(), 'Работник организации - составителя информации')]"));
                    actions.MoveToElement(status2).Click().Build().Perform();
                    break;

                case 3:
                    IWebElement status3 = driver.FindElement(By.XPath("//*[contains(text(), 'Работник иной уполномоченной организации')]"));
                    actions.MoveToElement(status3).Click().Build().Perform();
                    break;

                case 4:
                    IWebElement status4 = driver.FindElement(By.XPath("//*[contains(text(), 'Уполномоченное физическое лицо')]"));
                    actions.MoveToElement(status4).Click().Build().Perform();
                    break;
            }
            return this;
        }

        /// <summary>
        /// Ввод должности сотрудника
        /// </summary>
        /// <param name="post">Должность</param>
        public AuthoritiesHelper InputPost(string post)
        {
            GetElement(By.Id("post-input")).Clear();
            GetElement(By.Id("post-input")).SendKeys(post);
            return this;
        }

        /// <summary>
        /// Ввод основания сотрудника
        /// </summary>
        /// <param name="basis">Основание</param>
        public AuthoritiesHelper InputBasis(string basis)
        {
            GetElement(By.Id("basis-input")).Clear();
            GetElement(By.Id("basis-input")).SendKeys(basis);
            return this;
        }
    }
}
