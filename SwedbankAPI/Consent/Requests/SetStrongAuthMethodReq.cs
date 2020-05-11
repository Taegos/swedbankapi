using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Consent.Requests
{
    public partial class SetStrongAuthMethodReq
    {
        [JsonProperty("authenticationMethodId")]
        public string AuthenticationMethodId { get; set; }

        [JsonProperty("psuData")]
        public PsuData PsuData { get; set; }
    }

    public partial class PsuData
    {
        [JsonProperty("personalID")]
        public string PersonalId { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}