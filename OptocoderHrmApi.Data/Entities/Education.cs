using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Education
    {
        public Education()
        {
            EmployeeEducations = new HashSet<EmployeeEducation>();
        }

        public int EducationId { get; set; }
        public string EducationName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }
    }
}
