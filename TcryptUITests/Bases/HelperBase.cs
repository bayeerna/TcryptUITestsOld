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
using TcryptUITests.Data;
using OpenQA.Selenium.Interactions.Internal;

namespace Taxnet.Tcrypt.Autotests
{
    public class HelperBase
    {
        public Actions actions;
        protected ApplicationManager manager;
        protected IWebDriver driver;
        public int TimeLimit = Convert.ToInt32(Properties.Default.TimeLimit);
        public readonly WebDriverWait wait;
        public static List<OrgInfo> Organizations;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
            Organizations = OrgInfo.GetOrgInfo();
            actions = new Actions(driver);
        }


        /// <summary>
        /// Ожидает, пока искомый элемент станет видимым
        /// </summary>
        /// <param name="by">Селектор элемента на странице</param>
        /// <param name="timeLimit">Максимальное время ожидания</param>
        public void WaitForElementIsVisible(By by, int timeLimit)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(timeLimit)));
            //wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            wait.Until(ExpectedConditions.ElementIsVisible(by));

            //IWebElement dynamicElement = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        /// <summary>
        /// Ожидает пока элемент станет кликабельным
        /// </summary>
        /// <param name="by">Элемент, появление которого ожидается</param>
        /// <param name="timeLimit">Время ожидания появления элемента в секундах</param>
        public void WaitForElementToBeClickable(By by, int timeLimit)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(timeLimit)));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }


        /// <summary>
        /// ищет элемент на странице по заданному селектору
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public IWebElement GetElement(By by)
        {
            return driver.FindElement(by);
        }

        /// <summary>
        /// Ожидает исчезновения элемента со страницы
        /// </summary>
        /// <param name="by">Селектор элемента</param>
        public void WaitUntilElementIsNotVisible(By by, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(timeout)));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));

        }

        public void WaitHideElement(By selector)
        {
            WebDriverWait iWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            iWait.Until(ExpectedConditions.InvisibilityOfElementLocated(selector));
            // iClassName: By.Id("id"), By.CssSelector("selector") и т.д.
        }

        /// <summary>
        /// скроллит до нужного элемента на странице
        /// </summary>
        /// <param name="selector"></param>
        public void ScrollToElement(IWebElement webElement)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView();", webElement);
        }

        public List<IWebElement> GetElements(By by)
        {
            return driver.FindElements(by).ToList();
        }
    }
}
