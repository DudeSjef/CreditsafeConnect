// <copyright file="AuthRequest.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models
{
    /// <summary>
    /// Represents a the payload to be sent in an authentication request to the Creditsafe authentication endpoint.
    /// </summary>
    public class AuthRequest
    {
        /// <summary>
        /// Gets or sets the username of the <see cref="AuthRequest"/>.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password of the <see cref="AuthRequest"/>.
        /// </summary>
        public string Password { get; set; }
    }
}