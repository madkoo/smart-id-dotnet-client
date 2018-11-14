using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using Newtonsoft.Json;

using SmartId.Helper;
using SmartId.Rest.Dao;

namespace SmartId.Rest
{
    public class SmartIdRestConnector : ISmartIdConnector
    {

        protected static readonly string AuthenticateByNationalIdPath = "authentication/pno/{0}/{1}";
        protected static readonly string SessionStatusPath = "session/{0}";
        public string EndpointUrl { get; set; }

        public SmartIdRestConnector(string endpointUrl)
        {
            EndpointUrl = endpointUrl;
        }


        public AuthenticationSessionResponse Authenticate(NationalIdentity identity, AuthenticationSessionRequest request)
        {
            var urlPath = string.Format(AuthenticateByNationalIdPath, identity.CountryCode, identity.NationalIdentityNumber);
            return PostAuthenticationRequest(urlPath, request);
        }

        public SessionStatus GetSessionStatus(SessionStatusRequest request)
        {
            var getPath = string.Format(SessionStatusPath, request.SessionId);
            try
            {
                using (var client = PrepareClient())
                {
                    using (var response = client.GetAsync(getPath).Result)
                    {
                        return JsonConvert.DeserializeObject<SessionStatus>(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected AuthenticationSessionResponse PostAuthenticationRequest(string url, AuthenticationSessionRequest request)
        {
            try
            {
                return PostRequest<AuthenticationSessionResponse, AuthenticationSessionRequest>(url, request);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected T PostRequest<T, V>(string postUrl, V request)
        {
            var dataAsString = JsonConvert.SerializeObject(request);
            using (var content = new StringContent(dataAsString, Encoding.UTF8, "application/json"))
            {
                try
                {
                    using (var client = PrepareClient())
                    {
                        using (var response = client.PostAsync(postUrl, content).Result)
                        {
                            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                        }
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        protected HttpClient PrepareClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(EndpointUrl.EnsureEndsWith("/"))
            };
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
