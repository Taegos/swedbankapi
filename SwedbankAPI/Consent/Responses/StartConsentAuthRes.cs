using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Consent.Responses
{
    public partial class StartConsentAuthRes
    {
        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("authorisationId")]
        public string AuthorisationId { get; set; }

        [JsonProperty("scaStatus")]
        public string ScaStatus { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("scaRedirect")]
        public Sca ScaRedirect { get; set; }

        [JsonProperty("scaStatus")]
        public Sca ScaStatus { get; set; }
    }

    public partial class Sca
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
