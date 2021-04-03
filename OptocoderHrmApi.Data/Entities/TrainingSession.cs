using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class TrainingSession
    {
        public int TrainingSessionId { get; set; }
        public string Course { get; set; }
        public string TrainingName { get; set; }
        public string Details { get; set; }
        public DateTime ScheduledTime { get; set; }
        public DateTime AssignmentDueDate { get; set; }
        public string DeliveryMethod { get; set; }
        public string DeliveryLocation { get; set; }
        public string AttendanceType { get; set; }
        public string AttendanceStatus { get; set; }
        public string AttendanceFeedback { get; set; }
        public string ProofOfCompletion { get; set; }
        public byte[] Attachment { get; set; }
        public byte[] TrainingCertificate { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int TrainingSetupId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual TrainingSetup TrainingSetup { get; set; }
        public virtual User User { get; set; }
    }
}
