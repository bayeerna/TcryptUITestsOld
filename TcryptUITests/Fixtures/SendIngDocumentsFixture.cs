using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using TcryptUITests.Files;
using TcryptUITests;

namespace Taxnet.Tcrypt.Autotests
{
    [TestFixture]
    public class SendIngDocumentsFixture : TestBase
    {
        string nameOfOrganisation = "КЗИО";
        string INN = Properties.Default.Inn_KZIO;
        string nameOfDepartment = "Головное подразделение";

        /// <summary>
        /// Создание черновика по логину
        /// </summary>
        [Test]
        public void CreateDraftByLogin()
        {
            app.Auth.OpenLoginPage()
                    .LoginByEmail("Саянова Кристина")
                    .CloseTrainingPage();
            app.CreateDocuments
                               .ClickCreateDocumentButton()
                               .ClickClearButton()
                               .SelectRecipient(INN, nameOfDepartment, nameOfOrganisation)
                               .UploadDocument(FilesData.UnformalizedFiles + FilesData.UnformalizedTxtFile)
                               .SaveDraft();
            app.Auth.Logout();
        }

        /// <summary>
        /// Отправка документа с расширением .txt
        /// </summary>
        [Test]
        public void SendDocumentTxt()
        {
            app.Auth.OpenLoginPage()
                    .LoginByCert("Саянова Кристина")
                    .CloseTrainingPage();
            app.CreateDocuments//.StopMessageProcessing()
                               .ClickCreateDocumentButton()
                               .ClickClearButton()
                               .SelectRecipient(INN, nameOfDepartment, nameOfOrganisation)
                               .UploadDocument(FilesData.UnformalizedFiles + FilesData.UnformalizedTxtFile)
                               .ClickSendDocumentButton();
        }

        /// <summary>
        /// Отправка документа с расширением .pdf
        /// </summary>
        [Test]
        public void SendDocumentPdf()
        {
            app.Auth.OpenLoginPage()
                    .LoginByCert("Саянова Кристина")
                    .CloseTrainingPage();
            app.CreateDocuments//.StopMessageProcessing()
                               .ClickCreateDocumentButton()
                               .ClickClearButton()
                               .SelectRecipient(INN, nameOfDepartment, nameOfOrganisation)
                               .UploadDocument(FilesData.UnformalizedFiles + FilesData.UnformalizedActFile)
                               .ClickSendDocumentButton(); 
        }

        /// <summary>
        /// Отправка СФ формата 820 приказа
        /// </summary>
        [Test]
        public void SendDocumentSF()
        {
            app.Auth.OpenLoginPage()
                    .LoginByCert("Саянова Кристина")
                    .CloseTrainingPage();
            app.CreateDocuments//.StopMessageProcessing()
                               .ClickCreateDocumentButton()
                               .ClickClearButton()
                               .SelectRecipient(INN, nameOfDepartment, nameOfOrganisation)
                               .UploadDocument(FilesData.FormalizedFiles + FilesData.FormalizedSF820PrikazPath + FilesData.FormalizedSF820Prikaz);
            app.InputAuthorities.InputAuthorities(6, 2, "Руководитель", "Должностные обязанности");
            app.CreateDocuments.ClickSendDocumentButton();
        }

        /// <summary>
        /// Отправка УПД формата 820 приказа
        /// </summary>
        [Test]
        public void SendDocumentUPD()
        {
            app.Auth.OpenLoginPage()
                    .LoginByCert("Саянова Кристина")
                    .CloseTrainingPage();
            app.CreateDocuments//.StopMessageProcessing()
                               .ClickCreateDocumentButton()
                               .ClickClearButton()
                               .SelectRecipient(INN, nameOfDepartment, nameOfOrganisation)
                               .UploadDocument(FilesData.FormalizedFiles + 
                                               FilesData.FormalizedUpd820Path + 
                                               FilesData.FormalizedUpd820Prikaz);
            app.InputAuthorities.InputAuthorities(0, 2, "Директор", "Должностные обязанности");
            app.CreateDocuments.ClickSendDocumentButton();
        }

        /// <summary>
        /// Отправка КСФ
        /// </summary>
        [Test]
        public void SendDocumentKSF()
        {
            app.Auth.OpenLoginPage()
                    .LoginByCert("Саянова Кристина")
                    .CloseTrainingPage();
            app.CreateDocuments//.StopMessageProcessing()
                               .ClickCreateDocumentButton()
                               .ClickClearButton()
                               .SelectRecipient(INN, nameOfDepartment, nameOfOrganisation)
                               .UploadDocument(FilesData.FormalizedFiles + FilesData.FormalizedKsfPath + FilesData.FormalizedKsfFile);
            app.InputAuthorities.InputAuthorities(3, 2, "Директор", "Должностные обязанности");
            app.CreateDocuments.ClickSendDocumentButton();
        }

        /// <summary>
        /// Отправка УКД 
        /// </summary>
        [Test]
        public void SendDocumentUKD()
        {
            app.Auth.OpenLoginPage()
                    .LoginByCert("Саянова Кристина")
                    .CloseTrainingPage();
            app.CreateDocuments//.StopMessageProcessing()
                               .ClickCreateDocumentButton()
                               .ClickClearButton()
                               .SelectRecipient(INN, nameOfDepartment, nameOfOrganisation)
                               .UploadDocument(FilesData.FormalizedFiles + FilesData.FormalizedUkdPath + FilesData.FormalizedUkdFiles);
            app.InputAuthorities.InputAuthorities(3, 4, "Директор", "Должностные обязанности");
            app.CreateDocuments.ClickSendDocumentButton();
        }

        /// <summary>
        /// Отправка неформализованного xml
        /// </summary>
        [Test]
        public void SendingUnformalizedXmlFile()
        {
            app.Auth
                .OpenLoginPage()
                .LoginByCert("Саянова Кристина")
                .CloseTrainingPage();
            app.CreateDocuments
                .ClickCreateDocumentButton()
                .ClickClearButton()
                .SelectRecipient(INN, nameOfDepartment, nameOfOrganisation)
                .UploadDocument(FilesData.UnformalizedFiles + FilesData.UnformalizedXmlFile)
                .CloseInfoModalWindow()
                .CheckFileUploaded(FilesData.UnformalizedXmlFile)
                .ClickSendDocumentButton();
        }
    }
}
