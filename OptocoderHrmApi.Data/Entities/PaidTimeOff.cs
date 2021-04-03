using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class PaidTimeOff
    {
        public int PaidTimeOffId { get; set; }
        public string LeaveType { get; set; }
        public string EmployeeName { get; set; }
        public DateTime LeavePeriod { get; set; }
        public string LeaveAmount { get; set; }
        public string Note { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
