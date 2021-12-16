using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxnet.Tcrypt.Autotests
{
    [TestFixture]
    
    public class MessageProcessingFixture : TestBase
    {
        [Test]
        public void MessageProcessingTest()
        {
            app.Auth.OpenLoginPage()
                .LoginByCert("Саянова Кристина")
                .CloseTrainingPage();
            app.MessageProcessing.StartMessageProcessing();
            app.Auth.Logout();


        }
    }
}
