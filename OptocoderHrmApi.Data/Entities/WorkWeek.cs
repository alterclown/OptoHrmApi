using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class WorkWeek
    {
        public WorkWeek()
        {
            Holidays = new HashSet<Holiday>();
        }

        public int WorkWeekId { get; set; }
        public string Day { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
    }
}
