using Newtonsoft.Json;

namespace SmartId.Rest.Dao
{
    public class SessionStatus
    {
        [JsonIgnore]
        public string State { get; set; }

        [JsonIgnore]
        public SessionResult Result { get; set; }

        [JsonIgnore]
        public SessionSignature Signature { get; set; }
    }
}
