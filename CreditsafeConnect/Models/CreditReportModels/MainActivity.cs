// <copyright file="MainActivity.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels
{
    using System.Linq;

    /// <summary>
    /// A class containing information about the company main activity.
    /// </summary>
    public class MainActivity
    {
        private string code;

        /// <summary>
        /// Gets or sets the code for the company's main activity.
        /// </summary>
        public string Code
        {
            get => this.code;
            set
            {
                this.code = new string(value.Where(char.IsDigit).ToArray());
            }
        }

        /// <summary>
        /// Gets or sets the description of the company's main activity.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the classification of the company's main activity.
        /// </summary>
        public string Classification { get; set; }
    }
}
