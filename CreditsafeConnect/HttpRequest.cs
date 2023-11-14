using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CreditsafeConnect
{
    public class HttpRequest
    {
        private readonly HttpClient _client;
        private readonly string _authEndpoint;

        public HttpRequest(string baseAddress, string authEndpoint, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(baseAddress)) throw new ArgumentException("BaseAddress value was invalid.");
            if (string.IsNullOrWhiteSpace(authEndpoint)) throw new ArgumentException("AuthEndpoint value was invalid.");

            baseAddress = baseAddress.Trim();
            authEndpoint = authEndpoint.Trim();
            
            if (!baseAddress.EndsWith("/"))
            {
                baseAddress += '/';
            }

            if (!authEndpoint.StartsWith("/"))
            {
                _authEndpoint = '/' + authEndpoint;
            }

            _client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };

            Authorize(username, password).GetAwaiter().GetResult();
        }

        private async Task Authorize(string username, string password)
        {
            AuthRequest authRequest = new AuthRequest
            {
                Username = username,
                Password = password
            };

            StringContent payload = new StringContent(JsonConvert.SerializeObject(authRequest), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(
                this._authEndpoint, payload);

            response.EnsureSuccessStatusCode();

            _client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<string> GetCompanies(string country, string name, string status = "Active", int pageSize = 20)
        {
            HttpResponseMessage response = await _client.GetAsync(
                $"companies?countries={country}&name={name}&status={status}&pagesize={pageSize}");

            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStringAsync().Result;
        }
    }

    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
