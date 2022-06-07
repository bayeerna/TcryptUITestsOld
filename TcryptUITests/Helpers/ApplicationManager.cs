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
using TcryptUITests.Helpers;

namespace Taxnet.Tcrypt.Autotests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected LoginHelper loginHelper;
        protected CreateDocumentHelper createDocumentHelper;
        protected AuthoritiesHelper authoritiesHelper;
        protected PrintFormsHelper printFormHelper;
        protected IncomingDocumentsHelper incomingDocuments;
        protected MDOCreateHelper mdoCreate;
        protected SearchHelper searchHelper;
        //protected MessageProcessingHelper messageProcessingHelper;

        public ApplicationManager()

        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            loginHelper = new LoginHelper(this);
            createDocumentHelper = new CreateDocumentHelper(this);
            authoritiesHelper = new AuthoritiesHelper(this);
            printFormHelper = new PrintFormsHelper(this);
            incomingDocuments = new IncomingDocumentsHelper(this);
            mdoCreate = new MDOCreateHelper(this);
            searchHelper = new SearchHelper(this);
            //messageProcessingHelper = new MessageProcessingHelper(this);
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        [TearDown]
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch
            {
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public CreateDocumentHelper CreateDocuments
        {
            get
            {
                return createDocumentHelper;
            }
        }
        
        public AuthoritiesHelper InputAuthorities
        {
            get
            {
                return authoritiesHelper;
            }
        }

        public PrintFormsHelper PrintForms
        {
            get
            { return printFormHelper;
            }
        }

        public IncomingDocumentsHelper IncomingDocuments
        {
            get
            {
                return incomingDocuments;
            }
        }

        public MDOCreateHelper MDOCreate
        {
            get
            {
                return mdoCreate;
            }
        }

        public SearchHelper SearchHelper
        {
            get
            {
                return searchHelper;
            }
        }
    }
}
