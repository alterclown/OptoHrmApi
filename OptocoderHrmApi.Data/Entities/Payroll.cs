using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Payroll
    {
        public int PayrollId { get; set; }
        public int? EmployeeId { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string TotalPresent { get; set; }
        public string TotalAbsent { get; set; }
        public string LeaveDays { get; set; }
        public string Deduction { get; set; }
        public string LeaveStatus { get; set; }
        public string FestivalAdvance { get; set; }
        public string HousingLoan { get; set; }
        public string VehicleLoan { get; set; }
        public string OtherLoan { get; set; }
        public string LossOfPay { get; set; }
        public string Tds { get; set; }
        public string ProfessionalFees { get; set; }
        public string OtherDeductions { get; set; }
        public string TotalEarnings { get; set; }
        public string OtherPay { get; set; }
        public string BasicSalary { get; set; }
        public string SalaryPerDay { get; set; }
        public string Pay { get; set; }
        public string Earnings { get; set; }
        public string Deductions { get; set; }
        public string NetPay { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
