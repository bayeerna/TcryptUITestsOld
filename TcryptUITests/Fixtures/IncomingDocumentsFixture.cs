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
        public void AcceptIncomingDocument()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Саянова Кристина")
                .CloseTrainingPage();
            app.IncomingDocuments
                .FiltrOfIncomingDocuments(2)
                .GoToCardOfDocument()
                .AcceptDocument();
        }

        [Test]
        public void RejectIncomingDocument()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Саянова Кристина")
                .CloseTrainingPage();
            app.IncomingDocuments
                .FiltrOfIncomingDocuments(2)
                .GoToCardOfDocument()
                .RejectDocument();
        }
    }
}
