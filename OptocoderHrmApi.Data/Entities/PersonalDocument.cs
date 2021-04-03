using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class PersonalDocument
    {
        public int PersonalDocumentId { get; set; }
        public byte[] Document { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public byte[] Attachment { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
