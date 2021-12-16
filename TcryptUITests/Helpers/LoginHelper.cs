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
    public class LoginHelper:HelperBase
    {
        //protected IWebDriver driver;
        public LoginHelper(ApplicationManager manager)
        : base(manager)
        {
        }

        /// <summary>
        /// Переход на страницу авторизации
        /// </summary>
        public LoginHelper OpenLoginPage()
        {
            driver.Navigate().GoToUrl(Properties.Default.LoginPage);
            return this;
        }

        /// <summary>
        /// Авторизация по логину
        /// </summary>
        public LoginHelper LoginByEmail(string nameOfUser)
        {
            driver.FindElement(By.Id("login")).SendKeys(Organizations.Find((org) => org.NameOfUser == nameOfUser).Email); //Properties.Default.Login);
            driver.FindElement(By.Id("password")).SendKeys(Organizations.Find((org) => org.NameOfUser == nameOfUser).Password); //Properties.Default.Password);
            driver.FindElement(By.CssSelector(".btn")).Click();
            return this;
        }

        /// <summary>
        /// Авторизация по сертификату, поиск по ФИО сотрудника 
        /// </summary>
        public LoginHelper LoginByCert(string nameOfUser)
        {
            var certTab = By.Id("byCert");
            var cert = By.XPath("//*[contains(text(),'" +  Organizations.Find((org) => org.NameOfUser == nameOfUser).NameOfUser + "')]");
            WaitForElementIsVisible(certTab, 5);
            driver.FindElement(certTab).Click();
            WaitForElementIsVisible(cert, 5);
            driver.FindElement(cert).Click();
            return this;
        }

        /// <summary>
        /// Выход из учетки
        /// </summary>
        public LoginHelper Logout()
        {
            driver.FindElement(By.CssSelector("img")).Click();
            driver.FindElement(By.LinkText("Выйти")).Click();
            return this;
        }

        /// <summary>
        /// Закрытие обучалки
        /// </summary>
        public LoginHelper CloseTrainingPage()
        {
            var closeTrainingButton = By.XPath("//button[.='Пропустить']");
            WaitForElementIsVisible(closeTrainingButton, 25);
            WaitForElementToBeClickable(closeTrainingButton, 25);

            driver.FindElement(closeTrainingButton).Click();

            var nameOfOrganization = By.XPath("//*[@id=\"root\"]/header[2]/nav/a[3]/div[1]/div");
            //var nameOfOrganization = By.CssSelector(".organization-name");
            WaitForElementIsVisible(nameOfOrganization, 40);
            return this;
        }
    }
}
