using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CreditsafeConnect
{
    /// <summary>
    /// Class  <c>HttpRequest</c> handles all HTTP traffic and authentication between the caller and the Creditsafe API.
    /// </summary>
    public class HttpRequest
    {
        private readonly HttpClient _client;
        private readonly string _authEndpoint;

        /// <summary>
        /// Initializes a new instance of the <c>HttpRequest</c> class and authenticates to the Creditsafe API
        /// using the provided <paramref name="authEndpoint"/>, <paramref name="username"/>, and <paramref name="password"/>.
        /// </summary>
        /// <param name="baseAddress">Base address URI of the Creditsafe API.</param>
        /// <param name="authEndpoint">URI of the authentication endpoint of the Creditsafe API.</param>
        /// <param name="username">Username for authenticating to the Creditsafe API.</param>
        /// <param name="password">Password for authenticating to the Creditsafe API.</param>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided is invalid.</exception>
        public HttpRequest(string baseAddress, string authEndpoint, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(baseAddress)) throw new ArgumentException("BaseAddress value was invalid.");
            if (string.IsNullOrWhiteSpace(authEndpoint)) throw new ArgumentException("AuthEndpoint value was invalid.");
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username was invalid.");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password was invalid.");

            baseAddress = baseAddress.Trim();
            authEndpoint = authEndpoint.Trim();
            
            // HttpClient BaseAddress must always end with a '/'
            if (!baseAddress.EndsWith("/"))
            {
                baseAddress += '/';
            }

            // HttpClient requestUri should never start with a '/'
            while (authEndpoint.StartsWith("/"))
            {
                authEndpoint = authEndpoint.Remove(0, 1);
            }

            _authEndpoint = authEndpoint;

            _client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };

            Authenticate(username, password).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Uses the <paramref name="username"/> and <paramref name="password"/> to authenticate to the Creditsafe API.
        /// Sets the authorization header of the HttpClient using the returned JWT token.
        /// </summary>
        /// <param name="username">Username for authenticating to the Creditsafe API.</param>
        /// <param name="password">Password for authenticating to the Creditsafe API.</param>
        /// <returns></returns>
        private async Task Authenticate(string username, string password)
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

        /// <summary>
        /// Requests a list of companies from the Creditsafe API based on the provided criteria.
        /// </summary>
        /// <param name="countries">Comma-separated list of two-letter countries codes (ISO 3166-1 alpha-2) for the countries to search in.</param>
        /// <param name="name">Name of the company to be searched for.</param>
        /// <param name="status">Status of the company to be searched for. The default value is <see cref="Status.Active"/></param>
        /// <param name="pageSize">Number of companies to retrieve. Value should be between 1 and 100. The default value is 20.</param>
        /// <returns>
        /// List of companies as a string.
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<string> GetCompanies(string countries, string name, string status = "Active", int pageSize = 20)
        {
            if (string.IsNullOrWhiteSpace(countries)) throw new ArgumentException("Countries was invalid.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name was invalid.");
            if (!Enum.TryParse(status, out Status statusEnum)) throw new ArgumentException("Status was invalid.");
            if (pageSize < 1 || pageSize > 100) throw new ArgumentException("Page size not allowed.");

            HttpResponseMessage response = await _client.GetAsync(
                $"companies?countries={countries}&name={name}&status={statusEnum}&pagesize={pageSize}");

            response.EnsureSuccessStatusCode();
            
            return response.Content.ReadAsStringAsync().Result;
        }
    }

    /// <summary>
    /// Represents a the payload to be sent in an authentication request to the Creditsafe authentication endpoint.
    /// </summary>
    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Represents a company status.
    /// </summary>
    public enum Status
    {
        Active,
        NonActive,
        Pending,
        Other
    }
}
