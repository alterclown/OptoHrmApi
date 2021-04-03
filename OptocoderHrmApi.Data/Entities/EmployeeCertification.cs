using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class EmployeeCertification
    {
        public int EmployeeCertificationId { get; set; }
        public string EmployeeName { get; set; }
        public string Certification { get; set; }
        public string Institute { get; set; }
        public DateTime GrantedOn { get; set; }
        public DateTime ValidThru { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int CertificationId { get; set; }

        public virtual Certification CertificationNavigation { get; set; }
        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
