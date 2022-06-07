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
        [Test]
        public void CheckingPrintFormUnformalized()
        {
            app.Auth.OpenLoginPage()
                .LoginByEmail("Саянова Кристина")
                .CloseTrainingPage();
            app.IncomingDocuments
                .GoToCardOfDocument();
            app.PrintForms.OpenPrintedWithES();
            app.PrintForms.CheckingPrintFormWithStamp();
        }
    }
}
