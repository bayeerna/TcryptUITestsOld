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
        /// <summary>
        /// Отправка документов по маршруту "Договор оперативного управления"
        /// </summary>
        [Test]
        public void SendMDODogovor()
        {
            app.Auth
                .OpenLoginPage()
                .LoginByEmail(specKomitet)
                .CloseTrainingPage();
            app.CreateDocuments
                .ClickCreateDocumentButton()
                .GoToEdoPage()
                .SelectTypeOfEdo("Договор оперативного управления");
            app.MDOHelper.SelectRecipient("1699739465", "ПАО «ФинансТест»")
                .EnterTopic();
            app.CreateDocuments.UploadDocument(FilesData.UnformalizedFiles + FilesData.UnformalizedActFile);
            app.MDOHelper.SelectTypeOfDocument("Акт о приеме-передаче объектов нефинансовых активов")
                .SendDocumentOfMDO();
        }

        /// <summary>
        /// Отправка документов по маршруту УИТиСа
        /// </summary>
        [Test]
        public void SendMDOUITIS()
        {
            app.Auth
                .OpenLoginPage()
                .LoginByEmail(specUploadUITIS)
                .CloseTrainingPage();
            app.CreateDocuments
                .ClickCreateDocumentButton()
                .GoToEdoPage()
                .SelectTypeOfEdo("187 - Обмен актами приёма-передачи техники между МКУ УИТиС и КЗИО (2-х сторонний)");
            app.MDOHelper.EnterTopic();
            app.CreateDocuments.UploadDocument(FilesData.UnformalizedFiles + FilesData.UnformalizedActFile);
            app.MDOHelper.SelectTypeOfDocument("Акт приема-передачи техники (орг.техники)")
                .SendDocumentOfMDO();
        }

        /// <summary>
        /// Согласовать документ в маршрутном ДО
        /// </summary>
        [Test]
        public void ApprovalMDO()
        {
            app.Auth
                .OpenLoginPage()
                .LoginByEmail(specOneUITIS)
                .CloseTrainingPage();
            app.MDOHelper.GoToEDOPage();
            app.Filter.OpenFilter()
                .SelectStateOfDocument("В процессе")
                .FillTopic("autotest")
                .SelectNeedAction()
                .ClickFoundInFilter();
            app.IncomingDocuments.GoToCardOfDocument();
            app.MDOHelper.ApprovalDocument();
        }

        /// <summary>
        /// Отклонить документ в маршрутном ДО
        /// </summary>
        [Test]
        public void RejectMDO()
        {
            app.Auth
                .OpenLoginPage()
                .LoginByEmail(specTwoUITIS)
                .CloseTrainingPage();
            app.MDOHelper.GoToEDOPage();
            app.Filter.OpenFilter()
                .SelectStateOfDocument("В процессе")
                .FillTopic("autotest")
                .SelectNeedAction()
                .ClickFoundInFilter();
            app.IncomingDocuments.GoToCardOfDocument();
            app.MDOHelper.RejectlDocument();
        }
        private string specKomitet = "Костров Евгений";
        private string specUploadUITIS = "Специалист Загрузки";
        private string specOneUITIS = "Специалист комиссии";
        private string specTwoUITIS = "Специалист 2";
    }
}
