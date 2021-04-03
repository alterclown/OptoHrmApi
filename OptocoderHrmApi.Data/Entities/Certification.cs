using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Certification
    {
        public Certification()
        {
            EmployeeCertifications = new HashSet<EmployeeCertification>();
        }

        public int CertificationId { get; set; }
        public string CertificationName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<EmployeeCertification> EmployeeCertifications { get; set; }
    }
}
