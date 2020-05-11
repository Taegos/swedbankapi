using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Consent.Responses
{

    public partial class GetConsentDetailsRes
    {
        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("access")]
        public Access Access { get; set; }

        [JsonProperty("consentStatus")]
        public string ConsentStatus { get; set; }

        [JsonProperty("frequencyPerDay")]
        public long FrequencyPerDay { get; set; }

        [JsonProperty("lastActionDate")]
        public DateTimeOffset LastActionDate { get; set; }

        [JsonProperty("recurringIndicator")]
        public bool RecurringIndicator { get; set; }

        [JsonProperty("validUntil")]
        public DateTimeOffset ValidUntil { get; set; }
    }

    public partial class Access
    {
        [JsonProperty("accounts")]
        public AccountElement[] Accounts { get; set; }

        [JsonProperty("balances")]
        public AccountElement[] Balances { get; set; }

        [JsonProperty("transactions")]
        public AccountElement[] Transactions { get; set; }

        [JsonProperty("availableAccounts")]
        public string AvailableAccounts { get; set; }
    }

    public partial class AccountElement
    {
        [JsonProperty("iban")]
        public string Iban { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("account")]
        public LinksAccount Account { get; set; }
    }

    public partial class LinksAccount
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}