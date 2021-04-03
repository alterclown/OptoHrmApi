using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class PayGrade
    {
        public int PayGradeId { get; set; }
        public string PayGradeName { get; set; }
        public string MinSalary { get; set; }
        public string MaxSalary { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
