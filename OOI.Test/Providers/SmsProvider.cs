using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOI.Sms.DTO;
using OOI.Sms.Manager;

namespace OOI.Test.Providers
{
    [TestClass]
    public class SmsProvider
    {
        [TestMethod]
        public void SmsTest()
        {
            SMSDTO model = new SMSDTO();
            model.Content = "Test";
            model.PhoneNumber = "+905447840013";
            SmsManager.SendSMS(model);
        }
    }
}
