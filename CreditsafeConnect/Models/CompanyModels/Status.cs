// <copyright file="Status.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CompanyModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a company status.
    /// </summary>
    public enum Status
    {
        [Display(Name = "Actief")]
        Active,
        [Display(Name = "Inactief")]
        NonActive,
        [Display(Name = "In Afwachting")]
        Pending,
        [Display(Name = "Overig")]
        Other,
    }
}