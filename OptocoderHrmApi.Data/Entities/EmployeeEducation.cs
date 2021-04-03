using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class EmployeeEducation
    {
        public int EmployeeEducationId { get; set; }
        public string EmployeeName { get; set; }
        public string Institute { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletedOn { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int EducationId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Education Education { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
