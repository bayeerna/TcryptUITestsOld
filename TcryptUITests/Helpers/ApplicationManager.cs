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
        protected IWebDriver _driver;
        protected LoginHelper _loginHelper;
        protected CreateDocumentHelper _createDocumentHelper;
        protected AuthoritiesHelper _authoritiesHelper;
        protected PrintFormsHelper _printFormHelper;
        protected IncomingDocumentsHelper _incomingDocuments;
        protected MDOCreateHelper _mdoCreate;
        //protected MessageProcessingHelper messageProcessingHelper;

        public ApplicationManager()

        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _loginHelper = new LoginHelper(this);
            _createDocumentHelper = new CreateDocumentHelper(this);
            _authoritiesHelper = new AuthoritiesHelper(this);
            _printFormHelper = new PrintFormsHelper(this);
            _incomingDocuments = new IncomingDocumentsHelper(this);
            _mdoCreate = new MDOCreateHelper(this);
            //messageProcessingHelper = new MessageProcessingHelper(this);
        }

        public IWebDriver Driver
        {
            get
            {
                return _driver;
            }
        }

        [TearDown]
        public void Stop()
        {
            try
            {
                _driver.Quit();
            }
            catch
            {
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return _loginHelper;
            }
        }
        public CreateDocumentHelper CreateDocuments
        {
            get
            {
                return _createDocumentHelper;
            }
        }
        
        public AuthoritiesHelper InputAuthorities
        {
            get
            {
                return _authoritiesHelper;
            }
        }

        public PrintFormsHelper PrintForms
        {
            get
            { return _printFormHelper;
            }
        }

        public IncomingDocumentsHelper IncomingDocuments
        {
            get
            {
                return _incomingDocuments;
            }
        }

        public MDOCreateHelper MDOCreate
        {
            get
            {
                return _mdoCreate;
            }
        }
    }
}
