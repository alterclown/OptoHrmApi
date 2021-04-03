using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string CompanyUrl { get; set; }
        public string Status { get; set; }
        public DateTime FirstContactDate { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
