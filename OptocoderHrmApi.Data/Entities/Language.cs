using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Language
    {
        public Language()
        {
            EmployeeLanguages = new HashSet<EmployeeLanguage>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }
    }
}
