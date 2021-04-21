using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OptocoderHrmApi.Data.Entities;

#nullable disable

namespace OptocoderHrmApi.Data.DbContexts
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeArchived> EmployeeArchiveds { get; set; }
        public virtual DbSet<EmployeeCertification> EmployeeCertifications { get; set; }
        public virtual DbSet<EmployeeDeactivated> EmployeeDeactivateds { get; set; }
        public virtual DbSet<EmployeeDependent> EmployeeDependents { get; set; }
        public virtual DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public virtual DbSet<EmployeeEmergencyContact> EmployeeEmergencyContacts { get; set; }
        public virtual DbSet<EmployeeExpense> EmployeeExpenses { get; set; }
        public virtual DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }
        public virtual DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
        public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LeavePeriod> LeavePeriods { get; set; }
        public virtual DbSet<LeaveRule> LeaveRules { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<MonitorAttendance> MonitorAttendances { get; set; }
        public virtual DbSet<MyProject> MyProjects { get; set; }
        public virtual DbSet<OverTime> OverTimes { get; set; }
        public virtual DbSet<OverTimeRequest> OverTimeRequests { get; set; }
        public virtual DbSet<PaidTimeOff> PaidTimeOffs { get; set; }
        public virtual DbSet<PayGrade> PayGrades { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Payroll> Payrolls { get; set; }
        public virtual DbSet<PersonalDocument> PersonalDocuments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Taxis> Taxes { get; set; }
        public virtual DbSet<TrainingSession> TrainingSessions { get; set; }
        public virtual DbSet<TrainingSetup> TrainingSetups { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkWeek> WorkWeeks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=optocoderDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.TimeIn).HasColumnType("date");

                entity.Property(e => e.TimeOut).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attendanc__Compa__1332DBDC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attendanc__Emplo__123EB7A3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attendanc__UserI__14270015");
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("Certification");

                entity.Property(e => e.CertificationName).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Certifications)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Certifica__Compa__4E88ABD4");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.ClientName).HasMaxLength(255);

                entity.Property(e => e.CompanyUrl).HasMaxLength(255);

                entity.Property(e => e.ContactEmail).HasMaxLength(255);

                entity.Property(e => e.ContactNumber).HasMaxLength(255);

                entity.Property(e => e.Details).HasMaxLength(255);

                entity.Property(e => e.FirstContactDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Client__CompanyI__571DF1D5");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyAddress).HasMaxLength(255);

                entity.Property(e => e.CompanyCountry).HasMaxLength(255);

                entity.Property(e => e.CompanyDetails).HasMaxLength(255);

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.CompanyTimeZone).HasMaxLength(255);

                entity.Property(e => e.CompanyType).HasMaxLength(255);

                entity.Property(e => e.LicenseKey).HasMaxLength(255);

                entity.Property(e => e.LicenseKeyExpireDate).HasColumnType("date");

                entity.Property(e => e.LicenseKeyStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EducationName).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Education__Compa__4BAC3F29");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.AddressLine1).HasMaxLength(255);

                entity.Property(e => e.AddressLine2).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.ConfirmationDate).HasColumnType("date");

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.DateofBirth).HasColumnType("date");

                entity.Property(e => e.Department).HasMaxLength(255);

                entity.Property(e => e.DrivingLicenseNo).HasMaxLength(255);

                entity.Property(e => e.EmployeeNumber).HasMaxLength(255);

                entity.Property(e => e.EmploymentStatus).HasMaxLength(255);

                entity.Property(e => e.Ethnicity).HasMaxLength(255);

                entity.Property(e => e.FirstLevelApprover).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.Gender).HasMaxLength(255);

                entity.Property(e => e.HomePhone).HasMaxLength(255);

                entity.Property(e => e.ImmigrationStatus).HasMaxLength(255);

                entity.Property(e => e.IndirectSupervisors).HasMaxLength(255);

                entity.Property(e => e.JobTitle).HasMaxLength(255);

                entity.Property(e => e.JoinedDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.MaritalStatus).HasMaxLength(255);

                entity.Property(e => e.MiddleName).HasMaxLength(255);

                entity.Property(e => e.MobilePhone).HasMaxLength(255);

                entity.Property(e => e.Nationality).HasMaxLength(255);

                entity.Property(e => e.Nic).HasColumnName("NIC");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.OtherId)
                    .HasMaxLength(255)
                    .HasColumnName("OtherID");

                entity.Property(e => e.PayGrade).HasMaxLength(255);

                entity.Property(e => e.PostalZipCode)
                    .HasMaxLength(255)
                    .HasColumnName("Postal/Zip Code");

                entity.Property(e => e.PrivateEmail).HasMaxLength(255);

                entity.Property(e => e.Province).HasMaxLength(255);

                entity.Property(e => e.SecondLevelApprover).HasMaxLength(255);

                entity.Property(e => e.SsnNric).HasColumnName("SSN/NRIC");

                entity.Property(e => e.Supervisor).HasMaxLength(255);

                entity.Property(e => e.TerminationDate).HasColumnType("date");

                entity.Property(e => e.ThirdLevelApprover).HasMaxLength(255);

                entity.Property(e => e.WorkEmail).HasMaxLength(255);

                entity.Property(e => e.WorkPhone).HasMaxLength(255);

                entity.Property(e => e.WorkStationId).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Compan__3C69FB99");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__UserId__3D5E1FD2");
            });

            modelBuilder.Entity<EmployeeArchived>(entity =>
            {
                entity.ToTable("EmployeeArchived");

                entity.Property(e => e.Department).HasMaxLength(255);

                entity.Property(e => e.EmployeeNumber).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Supervisor).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeArchiveds)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__Compa__04E4BC85");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeArchiveds)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__Emplo__03F0984C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeArchiveds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__UserI__05D8E0BE");
            });

            modelBuilder.Entity<EmployeeCertification>(entity =>
            {
                entity.ToTable("EmployeeCertification");

                entity.Property(e => e.Certification).HasMaxLength(255);

                entity.Property(e => e.EmployeeName).HasMaxLength(255);

                entity.Property(e => e.GrantedOn).HasColumnType("date");

                entity.Property(e => e.Institute).HasMaxLength(255);

                entity.Property(e => e.ValidThru).HasColumnType("date");

                entity.HasOne(d => d.CertificationNavigation)
                    .WithMany(p => p.EmployeeCertifications)
                    .HasForeignKey(d => d.CertificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeC__Certi__6D0D32F4");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeCertifications)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeC__Compa__6B24EA82");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeCertifications)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeC__Emplo__6A30C649");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeCertifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeC__UserI__6C190EBB");
            });

            modelBuilder.Entity<EmployeeDeactivated>(entity =>
            {
                entity.ToTable("EmployeeDeactivated");

                entity.Property(e => e.Department).HasMaxLength(255);

                entity.Property(e => e.EmployeeNumber).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Supervisor).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeDeactivateds)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeD__Compa__00200768");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDeactivateds)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeD__Emplo__7F2BE32F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeDeactivateds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeD__UserI__01142BA1");
            });

            modelBuilder.Entity<EmployeeDependent>(entity =>
            {
                entity.Property(e => e.DateofBirth).HasColumnType("date");

                entity.Property(e => e.EmployeeName).HasMaxLength(255);

                entity.Property(e => e.IdNumber).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Relationship).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeDependents)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeD__Compa__76969D2E");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDependents)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeD__Emplo__75A278F5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeDependents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeD__UserI__778AC167");
            });

            modelBuilder.Entity<EmployeeEducation>(entity =>
            {
                entity.ToTable("EmployeeEducation");

                entity.Property(e => e.CompletedOn).HasColumnType("date");

                entity.Property(e => e.EmployeeName).HasMaxLength(255);

                entity.Property(e => e.Institute).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeEducations)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Compa__656C112C");

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.EmployeeEducations)
                    .HasForeignKey(d => d.EducationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Educa__6754599E");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeEducations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Emplo__6477ECF3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeEducations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__UserI__66603565");
            });

            modelBuilder.Entity<EmployeeEmergencyContact>(entity =>
            {
                entity.HasKey(e => e.EmployeeContactId)
                    .HasName("PK__Employee__54F63672A3E262B8");

                entity.Property(e => e.EmployeeName).HasMaxLength(255);

                entity.Property(e => e.HomePhone).HasMaxLength(255);

                entity.Property(e => e.MobilePhone).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Relationship).HasMaxLength(255);

                entity.Property(e => e.WorkPhone).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeEmergencyContacts)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Compa__7B5B524B");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeEmergencyContacts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Emplo__7A672E12");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeEmergencyContacts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__UserI__7C4F7684");
            });

            modelBuilder.Entity<EmployeeExpense>(entity =>
            {
                entity.ToTable("EmployeeExpense");

                entity.Property(e => e.Amount).HasMaxLength(20);

                entity.Property(e => e.Category).HasMaxLength(20);

                entity.Property(e => e.Currency).HasMaxLength(20);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmployeeName).HasMaxLength(20);

                entity.Property(e => e.Notes).HasMaxLength(20);

                entity.Property(e => e.Payee).HasMaxLength(20);

                entity.Property(e => e.PaymentMethod).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.TransactionNo).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeExpenses)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Compa__7755B73D");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeExpenses)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Emplo__756D6ECB");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.EmployeeExpenses)
                    .HasForeignKey(d => d.ExpenseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Expen__76619304");

                entity.HasOne(d => d.PaymentMethodNavigation)
                    .WithMany(p => p.EmployeeExpenses)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Payme__793DFFAF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeExpenses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__UserI__7849DB76");
            });

            modelBuilder.Entity<EmployeeLanguage>(entity =>
            {
                entity.ToTable("EmployeeLanguage");

                entity.Property(e => e.EmployeeName).HasMaxLength(255);

                entity.Property(e => e.Language).HasMaxLength(255);

                entity.Property(e => e.Listening).HasMaxLength(255);

                entity.Property(e => e.Reading).HasMaxLength(255);

                entity.Property(e => e.Speaking).HasMaxLength(255);

                entity.Property(e => e.Writing).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeLanguages)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeL__Compa__70DDC3D8");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeLanguages)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeL__Emplo__6FE99F9F");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.EmployeeLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeL__Langu__72C60C4A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeLanguages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeL__UserI__71D1E811");
            });

            modelBuilder.Entity<EmployeeLeave>(entity =>
            {
                entity.ToTable("EmployeeLeave");

                entity.Property(e => e.EmployeeName).HasMaxLength(20);

                entity.Property(e => e.LeaveEndDate).HasColumnType("date");

                entity.Property(e => e.LeaveStartDate).HasColumnType("date");

                entity.Property(e => e.LeaveType).HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeL__Compa__671F4F74");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeL__Emplo__662B2B3B");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeL__Leave__690797E6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeL__UserI__681373AD");
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.ToTable("EmployeeProject");

                entity.Property(e => e.Details).HasMaxLength(255);

                entity.Property(e => e.EmployeeName).HasMaxLength(255);

                entity.Property(e => e.EmployeeProjectName).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__Compa__5AEE82B9");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__Emplo__59FA5E80");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__UserI__5BE2A6F2");
            });

            modelBuilder.Entity<EmployeeSkill>(entity =>
            {
                entity.HasKey(e => e.EmployeeSkillsId)
                    .HasName("PK__Employee__B2E5AD8800FD93FA");

                entity.Property(e => e.Details).HasMaxLength(255);

                entity.Property(e => e.EmployeeName).HasMaxLength(255);

                entity.Property(e => e.EmployeeSkill1)
                    .HasMaxLength(255)
                    .HasColumnName("EmployeeSkill");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__Compa__5FB337D6");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__Emplo__5EBF139D");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__Skill__619B8048");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__UserI__60A75C0F");
            });

            modelBuilder.Entity<EmploymentStatus>(entity =>
            {
                entity.ToTable("EmploymentStatus");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EmploymentStatusName).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmploymentStatuses)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employmen__Compa__45F365D3");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.ToTable("Expense");

                entity.Property(e => e.ExpenseName).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Expense__Company__6CD828CA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Expense__UserId__6DCC4D03");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.HolidaysId)
                    .HasName("PK__Holidays__780EA8012F85AF3E");

                entity.Property(e => e.Country).HasMaxLength(20);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Holidays)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Holidays__Compan__55F4C372");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Holidays)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Holidays__Employ__55009F39");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Holidays)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Holidays__UserId__56E8E7AB");

                entity.HasOne(d => d.WorkWeek)
                    .WithMany(p => p.Holidays)
                    .HasForeignKey(d => d.WorkWeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Holidays__WorkWe__57DD0BE4");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.ToTable("JobTitle");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.JobTitle1)
                    .HasMaxLength(255)
                    .HasColumnName("JobTitle");

                entity.Property(e => e.JobTitleCode).HasMaxLength(255);

                entity.Property(e => e.Specification).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.JobTitles)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobTitle__Compan__403A8C7D");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.LanguageName).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Languages)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Language__Compan__5165187F");
            });

            modelBuilder.Entity<LeavePeriod>(entity =>
            {
                entity.ToTable("LeavePeriod");

                entity.Property(e => e.LeavePeriodName).HasMaxLength(20);

                entity.Property(e => e.PeriodEndDate).HasColumnType("date");

                entity.Property(e => e.PeriodStartDate).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.LeavePeriods)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeavePeri__Compa__4B7734FF");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeavePeriods)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeavePeri__Emplo__4A8310C6");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.LeavePeriods)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeavePeri__Leave__4D5F7D71");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LeavePeriods)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeavePeri__UserI__4C6B5938");
            });

            modelBuilder.Entity<LeaveRule>(entity =>
            {
                entity.HasKey(e => e.LeaveRulesId)
                    .HasName("PK__LeaveRul__FBDB6BE0FDDECCBE");

                entity.Property(e => e.EmployeeName).HasMaxLength(20);

                entity.Property(e => e.EmploymentStatus).HasMaxLength(20);

                entity.Property(e => e.Experience).HasMaxLength(20);

                entity.Property(e => e.JobTitle).HasMaxLength(20);

                entity.Property(e => e.LeaveGroup).HasMaxLength(20);

                entity.Property(e => e.LeavePerYear).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.LeaveRules)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveRule__Compa__0880433F");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveRules)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveRule__Emplo__09746778");

                entity.HasOne(d => d.JobTitleNavigation)
                    .WithMany(p => p.LeaveRules)
                    .HasForeignKey(d => d.JobTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveRule__JobTi__0A688BB1");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.LeaveRules)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveRule__Leave__0B5CAFEA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LeaveRules)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveRule__UserI__0C50D423");
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.ToTable("LeaveType");

                entity.Property(e => e.LeaveGroup).HasMaxLength(20);

                entity.Property(e => e.LeaveName).HasMaxLength(20);

                entity.Property(e => e.LeavePerYear).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.LeaveTypes)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveType__Compa__46B27FE2");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveTypes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveType__Emplo__45BE5BA9");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LeaveTypes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveType__UserI__47A6A41B");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loan");

                entity.Property(e => e.Amount).HasMaxLength(255);

                entity.Property(e => e.Currency).HasMaxLength(255);

                entity.Property(e => e.LoanPeriod).HasMaxLength(255);

                entity.Property(e => e.LoanStartDate).HasColumnType("date");

                entity.Property(e => e.LoanType).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loan__CompanyId__2180FB33");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loan__EmployeeId__208CD6FA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loan__UserId__22751F6C");
            });

            modelBuilder.Entity<LoanType>(entity =>
            {
                entity.ToTable("LoanType");

                entity.Property(e => e.Details).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.LoanTypes)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoanType__Compan__2645B050");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LoanTypes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoanType__Employ__25518C17");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoanTypes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoanType__UserId__2739D489");
            });

            modelBuilder.Entity<MonitorAttendance>(entity =>
            {
                entity.ToTable("MonitorAttendance");

                entity.Property(e => e.EmployeeName).HasMaxLength(255);

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.TimeIn).HasColumnType("date");

                entity.Property(e => e.TimeOut).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.MonitorAttendances)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonitorAt__Compa__09A971A2");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MonitorAttendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonitorAt__Emplo__08B54D69");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MonitorAttendances)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonitorAt__UserI__0A9D95DB");
            });

            modelBuilder.Entity<MyProject>(entity =>
            {
                entity.ToTable("MyProject");

                entity.Property(e => e.MyProjectName).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.MyProjects)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MyProject__Compa__0E6E26BF");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MyProjects)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MyProject__Emplo__0D7A0286");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MyProjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MyProject__UserI__0F624AF8");
            });

            modelBuilder.Entity<OverTime>(entity =>
            {
                entity.ToTable("OverTime");

                entity.Property(e => e.Category).HasMaxLength(255);

                entity.Property(e => e.EndTime).HasColumnType("date");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.OverTimeName).HasMaxLength(20);

                entity.Property(e => e.Project).HasMaxLength(255);

                entity.Property(e => e.StartTime).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.OverTimes)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OverTime__Compan__7D0E9093");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OverTimes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OverTime__Employ__7C1A6C5A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OverTimes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OverTime__UserId__7E02B4CC");
            });

            modelBuilder.Entity<OverTimeRequest>(entity =>
            {
                entity.ToTable("OverTimeRequest");

                entity.Property(e => e.Category).HasMaxLength(20);

                entity.Property(e => e.EmployeeName).HasMaxLength(20);

                entity.Property(e => e.EndTime).HasColumnType("date");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.StartTime).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.OverTimeRequests)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OverTimeR__Compa__1B9317B3");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OverTimeRequests)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OverTimeR__Emplo__1C873BEC");

                entity.HasOne(d => d.OverTime)
                    .WithMany(p => p.OverTimeRequests)
                    .HasForeignKey(d => d.OverTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OverTimeR__OverT__1D7B6025");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OverTimeRequests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OverTimeR__UserI__1E6F845E");
            });

            modelBuilder.Entity<PaidTimeOff>(entity =>
            {
                entity.ToTable("PaidTimeOff");

                entity.Property(e => e.EmployeeName).HasMaxLength(20);

                entity.Property(e => e.LeaveAmount).HasMaxLength(20);

                entity.Property(e => e.LeavePeriod).HasColumnType("date");

                entity.Property(e => e.LeaveType).HasMaxLength(20);

                entity.Property(e => e.Note).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PaidTimeOffs)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaidTimeO__Compa__625A9A57");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PaidTimeOffs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaidTimeO__Emplo__6166761E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaidTimeOffs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaidTimeO__UserI__634EBE90");
            });

            modelBuilder.Entity<PayGrade>(entity =>
            {
                entity.ToTable("PayGrade");

                entity.Property(e => e.MaxSalary).HasMaxLength(255);

                entity.Property(e => e.MinSalary).HasMaxLength(255);

                entity.Property(e => e.PayGradeName).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PayGrades)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PayGrade__Compan__4316F928");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                entity.Property(e => e.PaymentMethodName).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PaymentMethods)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaymentMe__Compa__719CDDE7");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PaymentMethods)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaymentMe__Emplo__70A8B9AE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentMethods)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaymentMe__UserI__72910220");
            });

            modelBuilder.Entity<Payroll>(entity =>
            {
                entity.ToTable("Payroll");

                entity.Property(e => e.BasicSalary).HasMaxLength(20);

                entity.Property(e => e.Deduction).HasMaxLength(20);

                entity.Property(e => e.Deductions).HasMaxLength(20);

                entity.Property(e => e.Earnings).HasMaxLength(20);

                entity.Property(e => e.FestivalAdvance).HasMaxLength(20);

                entity.Property(e => e.HousingLoan).HasMaxLength(20);

                entity.Property(e => e.LeaveDays).HasMaxLength(20);

                entity.Property(e => e.LeaveStatus).HasMaxLength(20);

                entity.Property(e => e.LossOfPay).HasMaxLength(20);

                entity.Property(e => e.Month).HasMaxLength(20);

                entity.Property(e => e.NetPay).HasMaxLength(20);

                entity.Property(e => e.OtherDeductions).HasMaxLength(20);

                entity.Property(e => e.OtherLoan).HasMaxLength(20);

                entity.Property(e => e.OtherPay).HasMaxLength(20);

                entity.Property(e => e.Pay).HasMaxLength(20);

                entity.Property(e => e.ProfessionalFees).HasMaxLength(20);

                entity.Property(e => e.SalaryPerDay).HasMaxLength(20);

                entity.Property(e => e.Tds)
                    .HasMaxLength(20)
                    .HasColumnName("TDS");

                entity.Property(e => e.TotalAbsent).HasMaxLength(20);

                entity.Property(e => e.TotalEarnings).HasMaxLength(20);

                entity.Property(e => e.TotalPresent).HasMaxLength(20);

                entity.Property(e => e.VehicleLoan).HasMaxLength(20);

                entity.Property(e => e.Year).HasMaxLength(20);

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.Payrolls)
                    .HasForeignKey(d => d.AttendanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payroll__Attenda__41EDCAC5");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Payrolls)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payroll__Company__3F115E1A");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Payrolls)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payroll__Employe__3E1D39E1");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Payrolls)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payroll__LoanId__42E1EEFE");

                entity.HasOne(d => d.Salary)
                    .WithMany(p => p.Payrolls)
                    .HasForeignKey(d => d.SalaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payroll__SalaryI__40F9A68C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payrolls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payroll__UserId__40058253");
            });

            modelBuilder.Entity<PersonalDocument>(entity =>
            {
                entity.ToTable("PersonalDocument");

                entity.Property(e => e.Details).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.ValidUntil).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PersonalDocuments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonalD__Compa__17F790F9");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PersonalDocuments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonalD__Emplo__17036CC0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PersonalDocuments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonalD__UserI__18EBB532");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Client).HasMaxLength(255);

                entity.Property(e => e.Details).HasMaxLength(255);

                entity.Property(e => e.ProjectName).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Project__Company__5441852A");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("Salary");

                entity.Property(e => e.Amount).HasMaxLength(255);

                entity.Property(e => e.Details).HasMaxLength(255);

                entity.Property(e => e.SalaryComponent).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salary__CompanyI__1CBC4616");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salary__Employee__1BC821DD");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salary__UserId__1DB06A4F");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.SkillName).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Skills__CompanyI__48CFD27E");
            });

            modelBuilder.Entity<Taxis>(entity =>
            {
                entity.HasKey(e => e.TaxesId)
                    .HasName("PK__Taxes__FC33F514B7167F8A");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaxName).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Taxes)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Taxes__CompanyId__3A4CA8FD");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Taxes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Taxes__EmployeeI__395884C4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Taxes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Taxes__UserId__3B40CD36");
            });

            modelBuilder.Entity<TrainingSession>(entity =>
            {
                entity.ToTable("TrainingSession");

                entity.Property(e => e.AssignmentDueDate).HasColumnType("date");

                entity.Property(e => e.AttendanceFeedback).HasMaxLength(20);

                entity.Property(e => e.AttendanceStatus).HasMaxLength(20);

                entity.Property(e => e.AttendanceType).HasMaxLength(20);

                entity.Property(e => e.Course).HasMaxLength(20);

                entity.Property(e => e.DeliveryLocation).HasMaxLength(20);

                entity.Property(e => e.DeliveryMethod).HasMaxLength(20);

                entity.Property(e => e.Details).HasMaxLength(20);

                entity.Property(e => e.ProofOfCompletion).HasMaxLength(20);

                entity.Property(e => e.ScheduledTime).HasColumnType("date");

                entity.Property(e => e.TrainingName).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TrainingSessions)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TrainingS__Compa__3493CFA7");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrainingSessions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TrainingS__Emplo__339FAB6E");

                entity.HasOne(d => d.TrainingSetup)
                    .WithMany(p => p.TrainingSessions)
                    .HasForeignKey(d => d.TrainingSetupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TrainingS__Train__367C1819");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TrainingSessions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TrainingS__UserI__3587F3E0");
            });

            modelBuilder.Entity<TrainingSetup>(entity =>
            {
                entity.ToTable("TrainingSetup");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Coordinator).HasMaxLength(20);

                entity.Property(e => e.Cost).HasMaxLength(20);

                entity.Property(e => e.Currency).HasMaxLength(20);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.PaymentType).HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.TraineeName).HasMaxLength(20);

                entity.Property(e => e.Trainer).HasMaxLength(20);

                entity.Property(e => e.TrainingDetails).HasMaxLength(20);

                entity.Property(e => e.TrainingName).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TrainingSetups)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TrainingS__Compa__2FCF1A8A");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrainingSetups)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TrainingS__Emplo__2EDAF651");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TrainingSetups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TrainingS__UserI__30C33EC3");
            });

            modelBuilder.Entity<Travel>(entity =>
            {
                entity.ToTable("Travel");

                entity.Property(e => e.Attachment).HasMaxLength(255);

                entity.Property(e => e.Currency).HasMaxLength(255);

                entity.Property(e => e.MeansofTransportation).HasMaxLength(255);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.PurposeofTravel).HasMaxLength(255);

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.Property(e => e.TotalFundingProposed).HasMaxLength(255);

                entity.Property(e => e.TravelDate).HasColumnType("date");

                entity.Property(e => e.TravelFrom).HasMaxLength(255);

                entity.Property(e => e.TravelTo).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Travels)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Travel__CompanyI__2B0A656D");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Travels)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Travel__Employee__2A164134");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Travels)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Travel__UserId__2BFE89A6");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Count).HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.TimeIn).HasColumnType("date");

                entity.Property(e => e.TimeOut).HasColumnType("date");

                entity.Property(e => e.Token).HasMaxLength(255);

                entity.Property(e => e.UserGender).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__CompanyId__398D8EEE");
            });

            modelBuilder.Entity<WorkWeek>(entity =>
            {
                entity.ToTable("WorkWeek");

                entity.Property(e => e.Country).HasMaxLength(20);

                entity.Property(e => e.Day).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.WorkWeeks)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkWeek__Compan__51300E55");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.WorkWeeks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkWeek__Employ__503BEA1C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkWeeks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkWeek__UserId__5224328E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
