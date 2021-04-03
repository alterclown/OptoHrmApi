using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Travel
    {
        public int TravelId { get; set; }
        public string MeansofTransportation { get; set; }
        public string PurposeofTravel { get; set; }
        public string TravelFrom { get; set; }
        public string TravelTo { get; set; }
        public DateTime TravelDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Notes { get; set; }
        public string Currency { get; set; }
        public string TotalFundingProposed { get; set; }
        public string Attachment { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
