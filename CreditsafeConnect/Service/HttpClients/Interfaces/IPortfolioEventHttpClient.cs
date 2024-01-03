// <copyright file="IPortfolioEventHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioEventModels;

    internal interface IPortfolioEventHttpClient
    {
        Task<List<PortfolioEvent>> GetAllPortfolioEvents(Request getAllPortfolioEventsRequest);
    }
}
