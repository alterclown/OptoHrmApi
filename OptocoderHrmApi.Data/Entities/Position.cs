﻿using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Position
    {
        public int PositionId { get; set; }
        public int? EmployeeId { get; set; }
        public string PositionName { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
