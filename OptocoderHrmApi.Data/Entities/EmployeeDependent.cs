using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class EmployeeDependent
    {
        public int EmployeeDependentId { get; set; }
        public string EmployeeName { get; set; }
        public string Name { get; set; }
        public string Relationship { get; set; }
        public DateTime DateofBirth { get; set; }
        public string IdNumber { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
