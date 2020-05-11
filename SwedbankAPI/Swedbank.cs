using System.Collections.Generic;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwedbankAPI.Consent.Responses;
using SwedbankAPI.Consent.Requests;
using SwedbankAPI.Consent;
using SwedbankAPI.Accounts;

namespace SwedbankAPI
{
    public class Swedbank
    {
        public ConsentService Consent { get; private set; }
        public AccountService Accounts { get; private set; }

        public Swedbank(string appId)
        {
            Consent = new ConsentService(appId);
            Accounts = new AccountService(appId);
        }
    }
}