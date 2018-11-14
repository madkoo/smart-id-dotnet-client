using Newtonsoft.Json;

namespace SmartId.Rest.Dao
{
    public class AuthenticationSessionRequest
    {
        [JsonProperty]
        public string RelyingPartyUUID { get; set; }

        [JsonProperty]
        public string RelyingPartyName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CertificateLevel { get; set; }

        [JsonProperty]
        public string Hash { get; set; }

        [JsonProperty]
        public string HashType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayText { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Nonce { get; set; }
    }
}
