namespace CreditsafeConnect.Models.PortfolioEventModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Company information in an <see cref="PortfolioEvent"/> object.
    /// </summary>
    public class EventCompany
    {
        /// <summary>
        /// Gets or sets the company unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the company name
        /// </summary>
        public string Name { get; set; }
    }
}
