using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Accounts.Responses
{
    public partial class AccountList
    {
        [JsonProperty("accounts")]
        public List<Account> Accounts { get; set; }
    }

    public partial class Account
    {
        [JsonProperty("resourceId")]
        public string ResourceId { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("cashAccountType")]
        public string CashAccountType { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("bankId")]
        public string BankId { get; set; }

        [JsonProperty("bban")]
        public string Bban { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("balances")]
        public List<string> Balances { get; set; }
        
        [JsonProperty("transactions")]
        public List<string> Transactions { get; set; }
    }
}