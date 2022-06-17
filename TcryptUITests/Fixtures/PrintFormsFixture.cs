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
    public class PrintFormsFixture : TestBase
    {
        /// <summary>
        /// Проверка формирования печатной формы со штампами неформализованного документа
        /// </summary>
        [Test]
        public void CheckingPrintFormUnformalized()
        {
            app.Auth.OpenLoginPage()
                .LoginByEmail("Саянова Кристина")
                .CloseTrainingPage();
            app.SearchHelper.FillSearchParameters("Неизвестный", "Завершен", "Входящие");
            app.IncomingDocuments
                .GoToCardOfDocument();
            app.PrintForms.OpenPrintedWithES();
            app.PrintForms.CheckingPrintFormWithStamp();
        }

        /// <summary>
        /// Проверка формирования печатной формы со штампами формализованного документа
        /// </summary>
        [Test]
        public void CheckingPrintFormFormalized()
        {
            app.Auth.OpenLoginPage()
                .LoginByEmail("Саянова Кристина")
                .CloseTrainingPage();
            app.SearchHelper.FillSearchParameters("УПД820", "Завершен", "Входящие");
            app.IncomingDocuments
                .GoToCardOfDocument();
            app.PrintForms.OpenPrintedWithES()
                .CheckingPrintFormWithStamp();
        }
    }
}
