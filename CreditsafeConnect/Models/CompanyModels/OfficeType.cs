// <copyright file="OfficeType.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CompanyModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a company office type.
    /// </summary>
    public enum OfficeType
    {
        [Display(Name = "Nevenvestiging")]
        Branch,
        [Display(Name = "Franchise")]
        Franchise,
        [Display(Name = "Franchisor")]
        Franchisor,
        [Display(Name = "Hoofdkantoor")]
        HeadOffice,
        [Display(Name = "Overig")]
        Other,
        [Display(Name = "Geregistreerd")]
        Registered,
        [Display(Name = "Enkel kantoor")]
        SingleOffice,
    }
}
