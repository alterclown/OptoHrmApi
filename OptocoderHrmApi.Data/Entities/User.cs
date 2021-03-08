using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class User
    {
        public User()
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
            training = new HashSet<training>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserGender { get; set; }
        public string Token { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string Count { get; set; }
        public bool? IsAdmin { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
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
        public virtual ICollection<training> training { get; set; }
    }
}
