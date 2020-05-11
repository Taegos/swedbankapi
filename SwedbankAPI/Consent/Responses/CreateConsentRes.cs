using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Consent.Responses
{
    public partial class CreateConsentRes
    {
        [JsonProperty("consentStatus")]
        public string ConsentStatus { get; set; }

        [JsonProperty("consentId")]
        public string ConsentId { get; set; }
    }
}