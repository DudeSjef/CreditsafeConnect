// <copyright file="AuthenticationToken.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models
{
    /// <summary>
    /// Token that is used for authenticating for API calls.
    /// </summary>
    public class AuthenticationToken
    {
        /// <summary>
        /// Gets or sets the token for the <see cref="AuthenticationToken"/>.
        /// </summary>
        public string Token { get; set; }
    }
}
