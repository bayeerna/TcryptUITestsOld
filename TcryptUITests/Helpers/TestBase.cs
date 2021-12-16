using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Taxnet.Tcrypt.Autotests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetUpTest()
        {
            app = new ApplicationManager();
        }
        [TearDown]
        protected void TearDown()
        {
            app.Stop();
        }


    }
}
