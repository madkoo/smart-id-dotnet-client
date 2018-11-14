using SmartId.Rest.Dao;

namespace SmartId.Rest
{
    public interface ISmartIdConnector
    {
        SessionStatus GetSessionStatus(SessionStatusRequest request);

        AuthenticationSessionResponse Authenticate(NationalIdentity identity, AuthenticationSessionRequest request);

    }
}
