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
    public class EDOFixtures : TestBase
    {

        [Test]
        public void test()
        {
            app.Auth
                .OpenLoginPage()
                .LoginByCert(specOfKomitet)
                .CloseTrainingPage();
            app.CreateDocuments
               //.StopMessageProcessing()
               .ClickCreateDocumentButton()
               .GoToEdoPage()
            .SelectTypeOfEdo("Договор оперативного управления");
            Thread.Sleep(10000);
        }
        private string specOfKomitet = "Ефимов Тихон Павлович";
    }
}
