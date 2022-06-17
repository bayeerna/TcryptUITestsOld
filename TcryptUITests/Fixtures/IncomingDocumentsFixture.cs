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
        /// <summary>
        /// Подписание входящей неформалки
        /// </summary>
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

        /// <summary>
        /// Отклонение входящей неформалки
        /// </summary>
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

        /// <summary>
        /// Подписание входящего УКД
        /// </summary>
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

        /// <summary>
        /// Подписание входящего УПД
        /// </summary>
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

        /// <summary>
        /// Отклонение входящего УКД
        /// </summary>
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

        /// <summary>
        /// Отклонение входящего УПД
        /// </summary>
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

        /// <summary>
        /// Аннулирование входящей неформалки
        /// </summary>
        [Test]
        public void CancellationIncomingUnformalizedDocument()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Костров Евгений")
                .CloseTrainingPage();

            app.Filter.SelectStateOfDocument("Завершен")
                .ClickFoundInFilter();

            app.IncomingDocuments
                .GoToCardOfDocument()
                .CheckingStateOfDocument("Завершен")
                .CancellationDocument()
                .CheckingStateOfDocument("Ожидается аннулирование");
        }

        /// <summary>
        /// Подтверждение аннулирования исходящей неформалки
        /// </summary>
        [Test]
        public void ConfirmCancellationIncomingUnformalizedDocument()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Саянова Кристина")
                .CloseTrainingPage();

            app.OutcomingDocuments.GoToOutcomingPage();
            app.Filter.SelectStateOfDocument("Требуется аннулирование")
                .ClickFoundInFilter();

            app.IncomingDocuments
                .GoToCardOfDocument()
                .CheckingStateOfDocument("Требуется аннулирование")
                .ConfirmationCancellation()
                .CheckingStateOfDocument("Аннулирован");
        }


    }
}
