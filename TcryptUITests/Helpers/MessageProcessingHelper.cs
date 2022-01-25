/*using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxnet.Tcrypt.Autotests
{
    public class MessageProcessingHelper:HelperBase
    {
        public MessageProcessingHelper(ApplicationManager manager)
        : base(manager)
        {
        }

        public void StartMessageProcessing()
        {
            while (GetElement(By.XPath("//button[.='Остановить']")).Displayed)
            {
                WaitUntilElementIsNotVisible(By.XPath("//button[.='Остановить']"), 6000);
                if (GetElement(By.XPath("//button[.='Обработать']")).Displayed)
                {
                    GetElement(By.XPath("//button[.='Обработать']")).Click();
                }    
                else
                {
                    
                }
            }
        }
    }
}*/
