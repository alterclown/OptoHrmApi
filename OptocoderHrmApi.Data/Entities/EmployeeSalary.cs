using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class EmployeeSalary
    {
        public int SalaryId { get; set; }
        public int? EmployeeId { get; set; }
        public string SalaryAmount { get; set; }
        public string Tax { get; set; }
        public string Status { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
