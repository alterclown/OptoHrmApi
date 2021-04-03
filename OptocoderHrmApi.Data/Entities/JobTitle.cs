using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class JobTitle
    {
        public JobTitle()
        {
            LeaveRules = new HashSet<LeaveRule>();
        }

        public int JobTitleId { get; set; }
        public string JobTitleCode { get; set; }
        public string JobTitle1 { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<LeaveRule> LeaveRules { get; set; }
    }
}
