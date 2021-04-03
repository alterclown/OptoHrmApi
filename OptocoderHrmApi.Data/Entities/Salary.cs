using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Salary
    {
        public Salary()
        {
            Payrolls = new HashSet<Payroll>();
        }

        public int SalaryId { get; set; }
        public string SalaryComponent { get; set; }
        public string Amount { get; set; }
        public string Details { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
    }
}
