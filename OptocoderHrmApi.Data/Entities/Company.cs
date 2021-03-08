using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Company
    {
        public Company()
        {
            Departments = new HashSet<Department>();
            EmployeeAttendances = new HashSet<EmployeeAttendance>();
            EmployeeProjects = new HashSet<EmployeeProject>();
            EmployeeSalaries = new HashSet<EmployeeSalary>();
            Employees = new HashSet<Employee>();
            GeoLocations = new HashSet<GeoLocation>();
            Leaves = new HashSet<Leave>();
            Loans = new HashSet<Loan>();
            Payrolls = new HashSet<Payroll>();
            Positions = new HashSet<Position>();
            Taxes = new HashSet<Taxis>();
            Users = new HashSet<User>();
            training = new HashSet<training>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LicenseKey { get; set; }
        public DateTime LicenseKeyStartDate { get; set; }
        public DateTime LicenseKeyExpireDate { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<EmployeeAttendance> EmployeeAttendances { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<GeoLocation> GeoLocations { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<Taxis> Taxes { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<training> training { get; set; }
    }
}
