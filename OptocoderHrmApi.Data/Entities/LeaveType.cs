using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class LeaveType
    {
        public LeaveType()
        {
            EmployeeLeaves = new HashSet<EmployeeLeave>();
            LeavePeriods = new HashSet<LeavePeriod>();
            LeaveRules = new HashSet<LeaveRule>();
        }

        public int LeaveTypeId { get; set; }
        public string LeaveName { get; set; }
        public bool? LeaveEnabled { get; set; }
        public bool? LeaveForward { get; set; }
        public string LeavePerYear { get; set; }
        public string LeaveGroup { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<EmployeeLeave> EmployeeLeaves { get; set; }
        public virtual ICollection<LeavePeriod> LeavePeriods { get; set; }
        public virtual ICollection<LeaveRule> LeaveRules { get; set; }
    }
}
