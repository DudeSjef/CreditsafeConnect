// <copyright file="RequestBuilder.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using CreditsafeConnect.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Builder class that creates a request object.
    /// </summary>
    public class RequestBuilder
    {
        private readonly Request request = new Request();

        /// <summary>
        /// Returns the <see cref="request"/> object.
        /// </summary>
        /// <returns>The <see cref="request"/> object.</returns>
        public Request Build()
        {
            return this.request;
        }

        /// <summary>
        /// Sets the URI endpoint of the request object.
        /// </summary>
        /// <param name="endpoint">URI of the endpoint.</param>
        /// <returns>An instance of the <see cref="RequestBuilder"/> class with the <see cref="request"/> object which has the property Endpoint set to the value of <paramref name="endpoint"/>.</returns>
        public RequestBuilder Endpoint(string endpoint)
        {
            endpoint = endpoint.Trim();

            while (endpoint.StartsWith("/"))
            {
                endpoint = endpoint.Remove(0, 1);
            }

            this.request.EndpointUri = endpoint;

            return this;
        }

        /// <summary>
        /// Sets the payload of the request object.
        /// </summary>
        /// <param name="obj">Payload to be sent in the request.</param>
        /// <returns>An instance of the <see cref="RequestBuilder"/> class with the <see cref="request"/> object which has the property Payload set to the value of <paramref name="obj"/>.</returns>
        public RequestBuilder Payload(object obj)
        {
            StringContent payload = new StringContent(
                JsonConvert.SerializeObject(obj),
                Encoding.UTF8,
                "application/json");

            this.request.Payload = payload;

            return this;
        }

        /// <summary>
        /// Sets the request parameters of the request object.
        /// </summary>
        /// <param name="parameters">Request parameters of the request.</param>
        /// <returns>An instance of the <see cref="RequestBuilder"/> class with the <see cref="request"/> object which has the property RequestParameters set to the value of <paramref name="parameters"/>.</returns>
        public RequestBuilder RequestParameters(Dictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count < 1) return this;

            StringBuilder stringBuilder = new StringBuilder();

            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                stringBuilder.Append($"{parameter.Key}={parameter.Value.Trim()}&");
            }

            stringBuilder.Remove(stringBuilder.Length - 1, 1);

            string requestParameters = stringBuilder.ToString();

            if (!requestParameters.StartsWith("?"))
            {
                requestParameters = requestParameters.Insert(0, "?");
            }

            this.request.RequestParameters = requestParameters;

            return this;
        }

        /// <summary>
        /// Sets the path parameters of the request object.
        /// </summary>
        /// <param name="pathParameters">Path parameters of the request.</param>
        /// <returns>An instance of the <see cref="RequestBuilder"/> class with the <see cref="request"/> object which has the property PathParameters set to the value of <paramref name="pathParameters"/>.</returns>
        public RequestBuilder PathParameters(string pathParameters)
        {
            pathParameters = pathParameters.Trim();

            if (!pathParameters.StartsWith("/"))
            {
                pathParameters = pathParameters.Insert(0, "/");
            }

            this.request.PathParameters = pathParameters;

            return this;
        }

        /// <summary>
        /// Sets the authentication token of the request object.
        /// </summary>
        /// <param name="authenticationToken">Authentication token as a string.</param>
        /// <returns>An instance of the <see cref="RequestBuilder"/> class with the <see cref="request"/> object which has the property AuthenticationHeader set to the value of <paramref name="authenticationToken"/>.</returns>
        public RequestBuilder AuthenticationHeader(string authenticationToken)
        {
            this.request.AuthenticationHeader = AuthenticationHeaderValue.Parse(authenticationToken);

            return this;
        }
    }
}
