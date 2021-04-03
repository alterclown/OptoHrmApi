using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class EmployeeLanguage
    {
        public int EmployeeLanguageId { get; set; }
        public string EmployeeName { get; set; }
        public string Language { get; set; }
        public string Reading { get; set; }
        public string Speaking { get; set; }
        public string Writing { get; set; }
        public string Listening { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int LanguageId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Language LanguageNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
