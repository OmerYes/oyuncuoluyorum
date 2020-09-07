using OOI.Sms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace OOI.Sms.Manager
{
    public class SmsManager
    {
        /// <summary>
        /// Modeldeki örnek telefon numarası "+905437331470" formatında gönderilmelidir. Content ise mesajın içeriğini belirtir
        /// </summary>
        /// <param name="model"></param>
        public static void SendSMS(SMSDTO model)
        {
            const string accountSid = "ACa21d7229451f0422fdb09f5eefefb63a";
            const string authToken = "bb72169aa6a51b8a2a3ec07705783024";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber("+16308286154"),
                body: model.Content,
                to: new Twilio.Types.PhoneNumber(model.PhoneNumber)
            );
        }
    }
}
