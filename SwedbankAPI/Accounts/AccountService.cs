using RestSharp;
using SwedbankAPI.Accounts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Accounts
{
    public class AccountService
    {
        private readonly string appId;
        private readonly RestClient client;
        public AccountService(string appId)
        {
            client = new RestClient("https://psd2.api.swedbank.com:443");
            this.appId = appId;
        }

        public async Task<IRestResponse<AccountList>> GetAll(string consentId, bool withBalance)
        {

            var request = new RestRequest("sandbox/v3/accounts", Method.GET)
             .AddParameter("bic", "SANDSESS", ParameterType.QueryString)
             .AddParameter("app-id", appId, ParameterType.QueryString)
             .AddParameter("withBalance", withBalance, ParameterType.QueryString);

            request.AddHeader("accept", "application/json");
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Authorization", "Bearer dummyToken");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Origin", "https://developer.swedbank.com");
            request.AddHeader("Consent-ID", consentId);
            request.AddHeader("PSU-IP-Address", "0");
            request.AddHeader("PSU-User-Agent", "0");
            request.AddHeader("TPP-Redirect-Preferred", "true");
            request.AddHeader("TPP-Redirect-URI", "https://google.com");
            request.AddHeader("TPP-Explicit-Authorisation-Preferred", "false");
            request.AddHeader("X-Request-ID", "sddswerfr6ef34345");

            return await client.ExecuteAsync<AccountList>(request);
        }
    }
}
