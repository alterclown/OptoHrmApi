using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class EmployeeSkill
    {
        public int EmployeeSkillsId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSkill1 { get; set; }
        public string Details { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual User User { get; set; }
    }
}
