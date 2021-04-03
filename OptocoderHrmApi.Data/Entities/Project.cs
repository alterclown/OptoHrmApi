using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Client { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
