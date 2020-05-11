using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Consent.Responses
{
    public partial class GetConsentAuthStatusRes
    {
        [JsonProperty("scaStatus")]
        public string ScaStatus { get; set; }
    }
}