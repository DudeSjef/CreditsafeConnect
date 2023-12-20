// <copyright file="EnumExtensions.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Static class that has extension methods for enums.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Method that returns the display name associated with an enum value.
        /// </summary>
        /// <param name="enumValue">The enum value from which to return the display name.</param>
        /// <returns>Enum display name as a string.</returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}
