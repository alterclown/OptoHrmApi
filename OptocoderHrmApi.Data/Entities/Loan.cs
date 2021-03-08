using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public int? EmployeeId { get; set; }
        public string TypeOfLoan { get; set; }
        public DateTime DateOfApplication { get; set; }
        public string ProposedAmount { get; set; }
        public string NoOfInstRecovery { get; set; }
        public DateTime StartDateOfRecovery { get; set; }
        public DateTime EndDateOfRecovery { get; set; }
        public string NoOfDays { get; set; }
        public string InterestRate { get; set; }
        public string InterestAmount { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
