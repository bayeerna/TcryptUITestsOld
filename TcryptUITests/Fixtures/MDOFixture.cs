using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TcryptUITests.Files;

namespace Taxnet.Tcrypt.Autotests
{
    [TestFixture]
    public class EDOFixtures : TestBase
    {

        [Test]
        public void SendMDO()
        {
            app.Auth
                .OpenLoginPage()
                .LoginByCert(specOfKomitet)
                .CloseTrainingPage();
            app.CreateDocuments
                .ClickCreateDocumentButton()
                .GoToEdoPage()
                .SelectTypeOfEdo("Договор оперативного управления");
            app.MDOCreate.SelectRecipient("1699739465", "ПАО «ФинансТест»")
                .EnterTopic();
            app.CreateDocuments.UploadDocument(FilesData.UnformalizedFiles + FilesData.UnformalizedActFile);
            app.MDOCreate.SelectTypeOfDocument()
                .SendDocumentOfMDO();
        }
        private string specOfKomitet = "Ефимов Тихон Павлович";
    }
}
