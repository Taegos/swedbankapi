using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Consent.Requests
{
    public partial class CreateConsentReq
    {
        [JsonProperty("access")]
        public Access Access { get; set; } = new Access();

        [JsonProperty("combinedServiceIndicator")]
        public bool CombinedServiceIndicator { get; set; } = true;

        [JsonProperty("frequencyPerDay")]
        public long FrequencyPerDay { get; set; } = 0;

        [JsonProperty("recurringIndicator")]
        public bool RecurringIndicator { get; set; } = false;

        [JsonProperty("validUntil")]
        public DateTimeOffset ValidUntil { get; set; } = DateTime.Now.AddDays(89);

    }

    public partial class Access
    {
        [JsonProperty("availableAccounts")]
        public string AvailableAccounts { get; set; } = "allAccounts";

        [JsonProperty("accounts")]
        public Account[] Accounts { get; set; } = new Account[] { new Account() };

        [JsonProperty("balances")]
        public Account[] Balances { get; set; } = new Account[] { new Account() };

        [JsonProperty("transactions")]
        public Account[] Transactions { get; set; } = new Account[] { new Account() };
    }

    public partial class Account
    {
        [JsonProperty("iban")]
        public string Iban { get; set; } = "string";
    }
}