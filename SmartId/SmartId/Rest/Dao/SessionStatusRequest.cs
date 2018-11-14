namespace SmartId.Rest.Dao
{
    public class SessionStatusRequest
    {
        public string SessionId;
        //public TimeUnit ResponseSocketOpenTimeUnit;
        //public long ResponseSocketOpenTimeValue;

        public SessionStatusRequest(string sessionId)
        {
            SessionId = sessionId;
        }
    }
}
