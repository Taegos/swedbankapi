using RestSharp;
using SwedbankAPI.Consent.Requests;
using SwedbankAPI.Consent.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Consent
{
    public class ConsentService
    { 
        private readonly IRestClient client;
        private readonly string appId;
        public ConsentService(string appId)
        {
            this.appId = appId;
            client = new RestClient("https://psd2.api.swedbank.com:443");

            var serializer = new RestSharpJsonNetSerializer();

            client.AddHandler("application/json", () => serializer);
            client.AddHandler("text/json", () => serializer);
            client.AddHandler("text/x-json", () => serializer);
            client.AddHandler("text/javascript", () => serializer);
            client.AddHandler("*+json", () => serializer);

        }

        private IRestRequest Request(Method method, string resource = "")
        {
            var request = new RestRequest("sandbox/v3/consents/" + resource, method)
                .AddParameter("bic", "SANDSESS", ParameterType.QueryString)
                .AddParameter("app-id", appId, ParameterType.QueryString); ;

            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Origin", "https://developer.swedbank.com");
            request.AddHeader("Authorization", "Bearer dummyToken");
            request.AddHeader("X-Request-ID", Guid.NewGuid().ToString());
            request.AddHeader("Date", DateTime.Now.ToString());

            request.JsonSerializer = new RestSharpJsonNetSerializer();
         
            return request;
        }

        public async Task<IRestResponse<CreateConsentRes>> Create(CreateConsentReq dto)
        {
            var request = Request(Method.POST);
           
            request.AddJsonBody(dto);

            request.AddHeader("PSU-IP-Address", "0");
            request.AddHeader("PSU-User-Agent", "0");
            request.AddHeader("TPP-Redirect-Preferred", "false");
            request.AddHeader("TPP-Redirect-URI", "https://google.com");
            request.AddHeader("TPP-Explicit-Authorisation-Preferred", "false");

            return await client.ExecuteAsync<CreateConsentRes>(request);
        }

        public async Task<IRestResponse<RestResponse>> Delete(string consentId)
        {
            var request = Request(Method.DELETE, consentId);
            return await client.ExecuteAsync<RestResponse>(request);
        }

        public async Task<IRestResponse<GetConsentDetailsRes>> GetDetails(string consentId)
        {
            var request = Request(Method.GET, consentId);
            return await client.ExecuteAsync<GetConsentDetailsRes>(request);
        }
        
        //

        public async Task<IRestResponse<StartConsentAuthRes>> StartAuthProcess(string consentId)
        {
            var request = Request(Method.POST, consentId + "/authorisations/");

            request.AddHeader("PSU-IP-Address", "0");
            request.AddHeader("PSU-User-Agent", "0");
            request.AddHeader("TPP-Redirect-URI", "https://google.com");

            return await client.ExecuteAsync<StartConsentAuthRes>(request);
        }

        public async Task<IRestResponse<GetConsentAuthStatusRes>> GetAuthProcesStatus(string consentId, string authId)
        {
            var request = Request(Method.GET, consentId + "/authorisations/" + authId.ToString());
            Console.WriteLine(request.Resource);
            return await client.ExecuteAsync<GetConsentAuthStatusRes>(request);
        }

        public async Task<IRestResponse<SetStrongAuthMethodRes>> SetStrongCustomerAuthMethod(string consentId, string authId, SetStrongAuthMethodReq dto)
        {
            var request = Request(Method.PUT, consentId + "/authorisations/" + authId.ToString());

            request.AddJsonBody(dto);

            return await client.ExecuteAsync<SetStrongAuthMethodRes>(request);
        }

        public async Task<IRestResponse<GetConsentStatusRes>> GetStatus(string consentId)
        {
            var request = Request(Method.GET, consentId + "/status");            
            return await client.ExecuteAsync<GetConsentStatusRes>(request);
        }
    }

    //get
    //start auth process post
    //get auth state
    //PutStrongCustomerAuthMethod
    //getStatus
}