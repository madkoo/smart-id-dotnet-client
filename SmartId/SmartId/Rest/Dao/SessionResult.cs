using Newtonsoft.Json;

namespace SmartId.Rest.Dao
{
    public class SessionResult
    {
        [JsonIgnore]
        public string EndResult { get; set; }

        [JsonIgnore]
        public string DocumentNumber { get; set; }

    }
}
