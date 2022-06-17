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
    public class OutcomingDocumentsHelper : HelperBase
    {
        public OutcomingDocumentsHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        /// <summary>
        /// переход к списку "Исходящие"
        /// </summary>
        public OutcomingDocumentsHelper GoToOutcomingPage()
        {
            driver.FindElements(By.XPath("//a[@id='outbox-aside-intro']/span[text()='Исходящие']"))[1].Click();
            return this;
        }
    }
}
    

