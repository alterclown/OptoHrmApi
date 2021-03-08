using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class training
    {
        public int TrainingId { get; set; }
        public int? EmployeeId { get; set; }
        public string TrainingProvider { get; set; }
        public string Trainee { get; set; }
        public string ProjectName { get; set; }
        public string TrainingLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
