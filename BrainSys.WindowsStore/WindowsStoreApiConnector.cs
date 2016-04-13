using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BrainSys.WindowsStore
{
    public class WindowsStoreApiConnector
    {
        private string accessToken;

        public string TenantId { get; private set; }
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }

        public WindowsStoreApiConnector(string tenantId, string clientId, string clientSecret)
        {
            this.TenantId = tenantId;
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }

        public async Task<AppAcquisitionsResponse> GetAppAcquisitionsAsync(AppAcquisitionsRequest request)
        {
            AppAcquisitionsResponse result = new AppAcquisitionsResponse();
            var json = await CallAPIAsync(request.ApplicationId, request.StartDate, request.EndDate, "appacquisitions", request.Top, request.Skip, request.AggregationLevel, request.OrderBy);
            result = JsonConvert.DeserializeObject<AppAcquisitionsResponse>(json);

            return result;
        }

        public async Task<InAppAcquisitionsResponse> GetInAppAcquisitionsAsync(InAppAcquisitionsRequest request)
        {
            InAppAcquisitionsResponse result = new InAppAcquisitionsResponse();
            string json = await CallAPIAsync(request.ApplicationId, request.StartDate, request.EndDate, "inappacquisitions", request.Top, request.Skip, request.AggregationLevel, request.OrderBy);
            result = JsonConvert.DeserializeObject<InAppAcquisitionsResponse>(json);

            return result;
        }

        public async Task<AppFailuresResponse> GetAppFailuresAsync(AppFailuresRequest request)
        {
            AppFailuresResponse result = new AppFailuresResponse();
            string json = await CallAPIAsync(request.ApplicationId, request.StartDate, request.EndDate, "failurehits", request.Top, request.Skip, request.AggregationLevel, request.OrderBy);
            result = JsonConvert.DeserializeObject<AppFailuresResponse>(json);

            return result;
        }

        public async Task<AppRatingsResponse> GetAppRatingsAsync(AppRatingsRequest request)
        {
            AppRatingsResponse result = new AppRatingsResponse();
            string json = await CallAPIAsync(request.ApplicationId, request.StartDate, request.EndDate, "ratings", request.Top, request.Skip, request.AggregationLevel, request.OrderBy);
            result = JsonConvert.DeserializeObject<AppRatingsResponse>(json);

            return result;
        }

        public async Task<AppReviewsResponse> GetAppReviewsAsync(AppReviewsRequest request)
        {
            AppReviewsResponse result = new AppReviewsResponse();
            string json = await CallAPIAsync(request.ApplicationId, request.StartDate, request.EndDate, "reviews", request.Top, request.Skip, AggregationLevel.None, request.OrderBy);
            result = JsonConvert.DeserializeObject<AppReviewsResponse>(json);

            return result;
        }

        private async Task<string> CallAPIAsync(string appID, DateTime startDate, DateTime endDate, string verb, int top, int skip, AggregationLevel aggregationLevel, List<OrderBy> orderBy)
        {
            string result = string.Empty;
            string scope = "https://manage.devcenter.microsoft.com";

            if (string.IsNullOrEmpty(accessToken))
            {
                accessToken = GetClientCredentialAccessToken(
                      this.TenantId,
                      this.ClientId,
                      this.ClientSecret,
                      scope).Result;
            }

            // Get app acquisitions
            string requestURI = BuildRequest(verb, appID, startDate, endDate, top, skip, aggregationLevel, orderBy);

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, requestURI);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
            result = await response.Content.ReadAsStringAsync();
            response.Dispose();

            return result;
        }

        private string BuildRequest(string verb, string appID, DateTime startDate, DateTime endDate, int top, int skip, AggregationLevel aggregationLevel, List<OrderBy> orderBy)
        {
            // Get app acquisitions
            //string requestURI = string.Format(
            //    "https://manage.devcenter.microsoft.com/v1.0/my/analytics/{5}?applicationId={0}&startDate={1}&endDate={2}&top={3}&skip={4}",
            //    appID, startDate, endDate, 1000, 0, verb);

            string requestURI = string.Format("https://manage.devcenter.microsoft.com/v1.0/my/analytics/{0}?applicationId={1}&startDate={2}&endDate={3}&top={4}&skip={5}",
                verb, appID, startDate, endDate, top, skip);

            if (aggregationLevel != AggregationLevel.None && aggregationLevel != AggregationLevel.Day)
            {
                requestURI += "&aggregationLevel=" + aggregationLevel.ToString().ToLower();
            }

            if (orderBy.Any())
            {
                requestURI += "&orderby=";
                foreach (OrderBy ob in orderBy)
                {
                    requestURI += ob.ToString().ToLower() + ",";
                }

                requestURI = requestURI.Remove(requestURI.Length - 1);
            }

            return requestURI;
        }

        public async Task<string> GetClientCredentialAccessToken(string tenantId, string clientId, string clientSecret, string scope)
        {
            string tokenEndpointFormat = "https://login.microsoftonline.com/{0}/oauth2/token";
            string tokenEndpoint = string.Format(tokenEndpointFormat, tenantId);

            dynamic result;
            using (HttpClient client = new HttpClient())
            {
                string tokenUrl = tokenEndpoint;
                using (
                    HttpRequestMessage request = new HttpRequestMessage(
                        HttpMethod.Post,
                        tokenUrl))
                {
                    string content =
                        string.Format(
                            "grant_type=client_credentials&client_id={0}&client_secret={1}&resource={2}",
                            clientId,
                            clientSecret,
                            scope);

                    request.Content = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject(responseContent);
                    }
                }
            }

            JToken token = null;
            JObject jObj = result as JObject;

            if (jObj.TryGetValue("access_token", out token))
            {
                return token.ToString();
            }
            else
            {
                throw new UnauthorizedAccessException("Tenant Id, Client Id or Client Secret are invalid!");
            }
        }
    }
}