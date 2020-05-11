using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Consent.Requests
{
    public partial class SetStrongAuthMethodRes
    {
        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("challengeData")]
        public ChallengeData ChallengeData { get; set; }

        [JsonProperty("chosenScaMethod")]
        public ChosenScaMethod ChosenScaMethod { get; set; }

        [JsonProperty("psuMessage")]
        public string PsuMessage { get; set; }

        [JsonProperty("scaStatus")]
        public string ScaStatus { get; set; }
    }

    public partial class ChallengeData
    {
        [JsonProperty("code")]        
        public string Code { get; set; }
    }

    public partial class ChosenScaMethod
    {
        [JsonProperty("authenticationMethodId")]
        public string AuthenticationMethodId { get; set; }

        [JsonProperty("authenticationType")]
        public string AuthenticationType { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("scaStatus")]
        public ScaStatus ScaStatus { get; set; }
    }

    public partial class ScaStatus
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
