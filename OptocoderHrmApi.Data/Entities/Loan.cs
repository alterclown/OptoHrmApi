using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Loan
    {
        public Loan()
        {
            Payrolls = new HashSet<Payroll>();
        }

        public int LoanId { get; set; }
        public string LoanType { get; set; }
        public DateTime LoanStartDate { get; set; }
        public string LoanPeriod { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
    }
}
