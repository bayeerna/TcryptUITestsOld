namespace TcryptUITests.Fixtures.Unformalized
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using System.IO;
    using System.ComponentModel.Design;
    using System.Threading;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    //using TcryptUITests.Bases;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using Taxnet.Tcrypt.Autotests;
    using TcryptUITests.Files;


    /// <summary>
    /// Класс предназначен для отправки неформализованного XML-файла 
    /// </summary>

    [TestFixture]
    class SendingUnformalizedXmlFileFixture : TestBase
    {
        string nameOfOrganisation = "Приказ";
        string INN = Properties.Default.Inn_Prikaz;
        string nameOfDepartment = "Головное подразделение";

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
