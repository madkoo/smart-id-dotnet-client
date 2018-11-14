using Newtonsoft.Json;

namespace SmartId.Rest.Dao
{

    public class AuthenticationSessionResponse
    {
        [JsonProperty]
        public string SessionId { get; set; }
    }
}
