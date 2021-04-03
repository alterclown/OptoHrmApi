using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class LeaveRule
    {
        public int LeaveRulesId { get; set; }
        public string LeaveGroup { get; set; }
        public DateTime JobTitle { get; set; }
        public string EmploymentStatus { get; set; }
        public string EmployeeName { get; set; }
        public string Experience { get; set; }
        public string LeavePerYear { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int LeaveTypeId { get; set; }
        public int JobTitleId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual JobTitle JobTitleNavigation { get; set; }
        public virtual LeaveType LeaveType { get; set; }
        public virtual User User { get; set; }
    }
}
