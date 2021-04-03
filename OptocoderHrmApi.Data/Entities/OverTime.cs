using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class OverTime
    {
        public OverTime()
        {
            OverTimeRequests = new HashSet<OverTimeRequest>();
        }

        public int OverTimeId { get; set; }
        public string Category { get; set; }
        public string OverTimeName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Project { get; set; }
        public string Notes { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OverTimeRequest> OverTimeRequests { get; set; }
    }
}
