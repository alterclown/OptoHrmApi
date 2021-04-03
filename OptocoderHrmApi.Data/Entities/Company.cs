using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Company
    {
        public Company()
        {
            Attendances = new HashSet<Attendance>();
            Certifications = new HashSet<Certification>();
            Clients = new HashSet<Client>();
            Educations = new HashSet<Education>();
            EmployeeArchiveds = new HashSet<EmployeeArchived>();
            EmployeeCertifications = new HashSet<EmployeeCertification>();
            EmployeeDeactivateds = new HashSet<EmployeeDeactivated>();
            EmployeeDependents = new HashSet<EmployeeDependent>();
            EmployeeEducations = new HashSet<EmployeeEducation>();
            EmployeeEmergencyContacts = new HashSet<EmployeeEmergencyContact>();
            EmployeeExpenses = new HashSet<EmployeeExpense>();
            EmployeeLanguages = new HashSet<EmployeeLanguage>();
            EmployeeLeaves = new HashSet<EmployeeLeave>();
            EmployeeProjects = new HashSet<EmployeeProject>();
            EmployeeSkills = new HashSet<EmployeeSkill>();
            Employees = new HashSet<Employee>();
            EmploymentStatuses = new HashSet<EmploymentStatus>();
            Expenses = new HashSet<Expense>();
            Holidays = new HashSet<Holiday>();
            JobTitles = new HashSet<JobTitle>();
            Languages = new HashSet<Language>();
            LeavePeriods = new HashSet<LeavePeriod>();
            LeaveRules = new HashSet<LeaveRule>();
            LeaveTypes = new HashSet<LeaveType>();
            LoanTypes = new HashSet<LoanType>();
            Loans = new HashSet<Loan>();
            MonitorAttendances = new HashSet<MonitorAttendance>();
            MyProjects = new HashSet<MyProject>();
            OverTimeRequests = new HashSet<OverTimeRequest>();
            OverTimes = new HashSet<OverTime>();
            PaidTimeOffs = new HashSet<PaidTimeOff>();
            PayGrades = new HashSet<PayGrade>();
            PaymentMethods = new HashSet<PaymentMethod>();
            Payrolls = new HashSet<Payroll>();
            PersonalDocuments = new HashSet<PersonalDocument>();
            Projects = new HashSet<Project>();
            Salaries = new HashSet<Salary>();
            Skills = new HashSet<Skill>();
            Taxes = new HashSet<Taxis>();
            TrainingSessions = new HashSet<TrainingSession>();
            TrainingSetups = new HashSet<TrainingSetup>();
            Travels = new HashSet<Travel>();
            Users = new HashSet<User>();
            WorkWeeks = new HashSet<WorkWeek>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDetails { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyType { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyTimeZone { get; set; }
        public string LicenseKey { get; set; }
        public DateTime LicenseKeyStartDate { get; set; }
        public DateTime LicenseKeyExpireDate { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<EmployeeArchived> EmployeeArchiveds { get; set; }
        public virtual ICollection<EmployeeCertification> EmployeeCertifications { get; set; }
        public virtual ICollection<EmployeeDeactivated> EmployeeDeactivateds { get; set; }
        public virtual ICollection<EmployeeDependent> EmployeeDependents { get; set; }
        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }
        public virtual ICollection<EmployeeEmergencyContact> EmployeeEmergencyContacts { get; set; }
        public virtual ICollection<EmployeeExpense> EmployeeExpenses { get; set; }
        public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }
        public virtual ICollection<EmployeeLeave> EmployeeLeaves { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<EmploymentStatus> EmploymentStatuses { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
        public virtual ICollection<JobTitle> JobTitles { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<LeavePeriod> LeavePeriods { get; set; }
        public virtual ICollection<LeaveRule> LeaveRules { get; set; }
        public virtual ICollection<LeaveType> LeaveTypes { get; set; }
        public virtual ICollection<LoanType> LoanTypes { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<MonitorAttendance> MonitorAttendances { get; set; }
        public virtual ICollection<MyProject> MyProjects { get; set; }
        public virtual ICollection<OverTimeRequest> OverTimeRequests { get; set; }
        public virtual ICollection<OverTime> OverTimes { get; set; }
        public virtual ICollection<PaidTimeOff> PaidTimeOffs { get; set; }
        public virtual ICollection<PayGrade> PayGrades { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
        public virtual ICollection<PersonalDocument> PersonalDocuments { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Taxis> Taxes { get; set; }
        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
        public virtual ICollection<TrainingSetup> TrainingSetups { get; set; }
        public virtual ICollection<Travel> Travels { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<WorkWeek> WorkWeeks { get; set; }
    }
}
