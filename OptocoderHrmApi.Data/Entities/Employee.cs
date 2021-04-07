using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Attendances = new HashSet<Attendance>();
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
            Holidays = new HashSet<Holiday>();
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
            PaymentMethods = new HashSet<PaymentMethod>();
            Payrolls = new HashSet<Payroll>();
            PersonalDocuments = new HashSet<PersonalDocument>();
            Salaries = new HashSet<Salary>();
            Taxes = new HashSet<Taxis>();
            TrainingSessions = new HashSet<TrainingSession>();
            TrainingSetups = new HashSet<TrainingSetup>();
            Travels = new HashSet<Travel>();
            WorkWeeks = new HashSet<WorkWeek>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Ethnicity { get; set; }
        public string ImmigrationStatus { get; set; }
        public byte[] SsnNric { get; set; }
        public byte[] Nic { get; set; }
        public string OtherId { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string EmploymentStatus { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string PayGrade { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string WorkStationId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string PostalZipCode { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string WorkEmail { get; set; }
        public string PrivateEmail { get; set; }
        public string Supervisor { get; set; }
        public string IndirectSupervisors { get; set; }
        public string FirstLevelApprover { get; set; }
        public string SecondLevelApprover { get; set; }
        public string ThirdLevelApprover { get; set; }
        public string Notes { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
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
        public virtual ICollection<Holiday> Holidays { get; set; }
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
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
        public virtual ICollection<PersonalDocument> PersonalDocuments { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Taxis> Taxes { get; set; }
        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
        public virtual ICollection<TrainingSetup> TrainingSetups { get; set; }
        public virtual ICollection<Travel> Travels { get; set; }
        public virtual ICollection<WorkWeek> WorkWeeks { get; set; }
    }
}
