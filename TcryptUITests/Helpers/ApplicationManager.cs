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
        protected OutcomingDocumentsHelper outcomingDocuments;
        protected MDOCreateHelper mdoHelper;
        protected SearchHelper searchHelper;
        protected FilterHelper filterHelper;
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
            outcomingDocuments = new OutcomingDocumentsHelper(this);
            mdoHelper = new MDOCreateHelper(this);
            searchHelper = new SearchHelper(this);
            filterHelper = new FilterHelper(this);
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

        public OutcomingDocumentsHelper OutcomingDocuments
        {
            get
            {
                return outcomingDocuments;
            }
        }

        public MDOCreateHelper MDOHelper
        {
            get
            {
                return mdoHelper;
            }
        }

        public SearchHelper SearchHelper
        {
            get
            {
                return searchHelper;
            }
        }

        public FilterHelper Filter
        {
            get
            {
                return filterHelper;
            }
        }
    }
}
