using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class TrainingSetup
    {
        public TrainingSetup()
        {
            TrainingSessions = new HashSet<TrainingSession>();
        }

        public int TrainingSetupId { get; set; }
        public string Code { get; set; }
        public string TrainingName { get; set; }
        public string Coordinator { get; set; }
        public string Trainer { get; set; }
        public string TraineeName { get; set; }
        public string TrainingDetails { get; set; }
        public string PaymentType { get; set; }
        public string Currency { get; set; }
        public string Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
