using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class EmploymentStatus
    {
        public int EmploymentStatusId { get; set; }
        public string EmploymentStatusName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
