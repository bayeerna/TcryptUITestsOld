using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Taxnet.Tcrypt.Autotests
{
    [TestFixture]
    public class IncomingDocumentsFixture:TestBase
    {
        [Test]
        public void AcceptIncomingUnformalizedDocument()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Костров Евгений")
                .CloseTrainingPage();

            app.SearchHelper.FillSearchParameters("Неизвестный", "На подписи/Требуется подпись", "Входящие");

            app.IncomingDocuments
                .GoToCardOfDocument()
                .CheckingStateOfDocument("Требуется подпись")
                .AcceptDocument()
                .CheckingStateOfDocument("Завершен");
        }

        [Test]
        public void RejectIncomingUnformalizedDocument()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Костров Евгений")
                .CloseTrainingPage();
            app.SearchHelper.FillSearchParameters("Неизвестный", "На подписи/Требуется подпись", "Входящие");
            app.IncomingDocuments
                .GoToCardOfDocument()
                .CheckingStateOfDocument("Требуется подпись")
                .RejectDocument()
                .CheckingStateOfDocument("Отказано");
        }

        [Test]
        public void AcceptIncomingUKD()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Костров Евгений")
                .CloseTrainingPage();

            app.SearchHelper.FillSearchParameters("УКД", "На подписи/Требуется подпись", "Входящие");

            app.IncomingDocuments
                .GoToCardOfDocument()
                .CheckingStateOfDocument("Требуется подпись")
                .AcceptDocument()
                .CheckingStateOfDocument("Завершен");
        }

        [Test]
        public void AcceptIncomingUPD820()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Костров Евгений")
                .CloseTrainingPage();

            app.SearchHelper.FillSearchParameters("УПД820", "На подписи/Требуется подпись", "Входящие");

            app.IncomingDocuments
                .GoToCardOfDocument()
                .CheckingStateOfDocument("Требуется подпись")
                .AcceptDocument()
                .CheckingStateOfDocument("Завершен");
        }

        [Test]
        public void RejectIncomingUKD()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Костров Евгений")
                .CloseTrainingPage();

            app.SearchHelper.FillSearchParameters("УКД", "На подписи/Требуется подпись", "Входящие");

            app.IncomingDocuments
                .GoToCardOfDocument()
                .CheckingStateOfDocument("Требуется подпись")
                .RejectDocument()
                .CheckingStateOfDocument("Отказано");
        }

        [Test]
        public void RejectIncomingUPD820()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Костров Евгений")
                .CloseTrainingPage();

            app.SearchHelper.FillSearchParameters("УПД820", "На подписи/Требуется подпись", "Входящие");

            app.IncomingDocuments
                .GoToCardOfDocument()
                .CheckingStateOfDocument("Требуется подпись")
                .RejectDocument()
                .CheckingStateOfDocument("Отказано");
        }


    }
}
