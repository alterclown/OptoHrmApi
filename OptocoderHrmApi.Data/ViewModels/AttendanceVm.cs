using System;
using System.Collections.Generic;
using System.Text;

namespace OptocoderHrmApi.Data.ViewModels
{
    public class AttendanceVm
    {
        public int AttendanceId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string Note { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
    }
}
