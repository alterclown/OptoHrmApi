using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Taxis
    {
        public int TaxesId { get; set; }
        public int? EmployeeId { get; set; }
        public string TaxName { get; set; }
        public int? TaxValue { get; set; }
        public string Status { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
