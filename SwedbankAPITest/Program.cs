using RestSharp;
using SwedbankAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SwedbankAPI.Swedbank;
using SwedbankAPI.Consent.Requests;
using SwedbankAPI.Consent.Responses;

namespace SwedbankAPITest
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "l73dc43920d81245ec9dc9ec4bccce51b8";

            Swedbank swedbank = new Swedbank(key);
          
            var res0 = swedbank.Consent.Create(new CreateConsentReq()).Result;
            Console.WriteLine(res0.Content);

            var consentId = res0.Data.ConsentId;

            var res1 = swedbank.Consent.GetDetails(consentId).Result;
            Console.WriteLine(res1.Content);

            var res2 = swedbank.Consent.StartAuthProcess(consentId).Result;

            var authId = res2.Data.AuthorisationId;
            Console.WriteLine(res2.Content);
            Console.WriteLine(authId);

            var res3 = swedbank.Consent.GetAuthProcesStatus(consentId, authId).Result;
            Console.WriteLine(res3.Content);


            SetStrongAuthMethodReq req0 = new SetStrongAuthMethodReq();
            req0.AuthenticationMethodId = "MOBILE_ID";
            req0.PsuData = new PsuData() {
                PersonalId = "199506178855",
                PhoneNumber = "0737243272"
            };

            var res4 = swedbank.Consent.SetStrongCustomerAuthMethod(consentId, authId, req0).Result;
            Console.WriteLine(res4.Content);

            var res5 = swedbank.Consent.GetStatus(consentId).Result;
            Console.WriteLine(res5.Content);

            var res6 = swedbank.Consent.GetAuthProcesStatus(consentId, authId).Result;
            Console.WriteLine(res3.Content);

            while (true) { }            
        }
    }
}

