using Newtonsoft.Json;

namespace SmartId.Rest.Dao
{
    public class SessionSignature
    {
        public string Algorithm { get; set; }

        [JsonProperty("value")]
        public string valueInBase64 { get; set; }
    }
}