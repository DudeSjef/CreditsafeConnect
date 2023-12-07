// <copyright file="Request.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models
{
    using System.Net.Http;
    using System.Net.Http.Headers;

    /// <summary>
    /// Class with all information required to make HTTP requests.
    /// </summary>
    internal class Request
    {
        /// <summary>
        /// Gets or sets the URI of the endpoint.
        /// </summary>
        internal string EndpointUri { get; set; }

        /// <summary>
        /// Gets or sets the request body as a <see cref="StringContent"/>.
        /// </summary>
        internal StringContent Payload { get; set; }

        /// <summary>
        /// Gets or sets the request parameters.
        /// </summary>
        internal string RequestParameters { get; set; }

        /// <summary>
        /// Gets or sets the path parameters.
        /// </summary>
        internal string PathParameters { get; set; }

        /// <summary>
        /// Gets or sets the authentication token.
        /// </summary>
        internal AuthenticationHeaderValue AuthenticationToken { get; set; }
    }
}
