using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class OverTimeRequest
    {
        public int OverTimeRequestId { get; set; }
        public string EmployeeName { get; set; }
        public string Category { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Project { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int OverTimeId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual OverTime OverTime { get; set; }
        public virtual User User { get; set; }
    }
}
