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

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
        public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual DbSet<GeoLocation> GeoLocations { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Payroll> Payrolls { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Taxis> Taxes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<training> training { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OptoHrm;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.LicenseKey).HasMaxLength(255);

                entity.Property(e => e.LicenseKeyExpireDate).HasColumnType("date");

                entity.Property(e => e.LicenseKeyStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentName).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Compa__5DCAEF64");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Departmen__Emplo__5CD6CB2B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__UserI__5EBF139D");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Address).HasMaxLength(20);

                entity.Property(e => e.Age).HasMaxLength(20);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.LeaveDate).HasColumnType("date");

                entity.Property(e => e.Sex).HasMaxLength(20);

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

            modelBuilder.Entity<EmployeeAttendance>(entity =>
            {
                entity.ToTable("EmployeeAttendance");

                entity.Property(e => e.Count).HasMaxLength(20);

                entity.Property(e => e.Remarks).HasMaxLength(20);

                entity.Property(e => e.TimeIn).HasColumnType("date");

                entity.Property(e => e.TimeOut).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeAttendances)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__Compa__412EB0B6");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAttendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeA__Emplo__403A8C7D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeAttendances)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__UserI__4222D4EF");
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.HasKey(e => e.ProjectHandleId)
                    .HasName("PK__Employee__5CAF74E87302434B");

                entity.ToTable("EmployeeProject");

                entity.Property(e => e.DateEnded).HasColumnType("date");

                entity.Property(e => e.DateStarted).HasColumnType("date");

                entity.Property(e => e.ProjectName).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__Compa__45F365D3");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeP__Emplo__44FF419A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__UserI__46E78A0C");
            });

            modelBuilder.Entity<EmployeeSalary>(entity =>
            {
                entity.HasKey(e => e.SalaryId)
                    .HasName("PK__Employee__4BE204573DDD83D4");

                entity.ToTable("EmployeeSalary");

                entity.Property(e => e.SalaryAmount).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.Tax).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployeeSalaries)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__Compa__4AB81AF0");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSalaries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeS__Emplo__49C3F6B7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeSalaries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__UserI__4BAC3F29");
            });

            modelBuilder.Entity<GeoLocation>(entity =>
            {
                entity.HasKey(e => e.GeoLocationId)
                    .HasName("PK__GeoLocat__81B966A3C915DE71");

                entity.Property(e => e.Asn).HasMaxLength(20);

                entity.Property(e => e.CallingCode).HasMaxLength(20);

                entity.Property(e => e.Capital).HasMaxLength(20);

                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.ContinentCode).HasMaxLength(20);

                entity.Property(e => e.ContinentName).HasMaxLength(20);

                entity.Property(e => e.CountryCode).HasMaxLength(20);

                entity.Property(e => e.CountryFlag).HasMaxLength(20);

                entity.Property(e => e.CountryFlagEmoji).HasMaxLength(20);

                entity.Property(e => e.CountryFlagEmojiUnicode).HasMaxLength(20);

                entity.Property(e => e.CountryName).HasMaxLength(20);

                entity.Property(e => e.CrawlerName).HasMaxLength(20);

                entity.Property(e => e.CrawlerType).HasMaxLength(20);

                entity.Property(e => e.CurrentTime).HasColumnType("date");

                entity.Property(e => e.GeonameId).HasMaxLength(20);

                entity.Property(e => e.GmtOffset).HasMaxLength(20);

                entity.Property(e => e.HostName).HasMaxLength(20);

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Ip).HasMaxLength(20);

                entity.Property(e => e.Isp).HasMaxLength(20);

                entity.Property(e => e.Latitude).HasMaxLength(20);

                entity.Property(e => e.Longitude).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Native).HasMaxLength(20);

                entity.Property(e => e.Plural).HasMaxLength(20);

                entity.Property(e => e.ProxyType).HasMaxLength(20);

                entity.Property(e => e.RegionCode).HasMaxLength(20);

                entity.Property(e => e.RegionName).HasMaxLength(20);

                entity.Property(e => e.Symbol).HasMaxLength(20);

                entity.Property(e => e.SymbolNative).HasMaxLength(20);

                entity.Property(e => e.ThreatLevel).HasMaxLength(20);

                entity.Property(e => e.ThreatTypes).HasMaxLength(20);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.Zip).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.GeoLocations)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GeoLocati__Compa__70DDC3D8");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.GeoLocations)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__GeoLocati__Emplo__6FE99F9F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GeoLocations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GeoLocati__UserI__71D1E811");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.ToTable("Leave");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Month).HasMaxLength(20);

                entity.Property(e => e.NoOfDays).HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leave__CompanyId__4F7CD00D");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Leave__EmployeeI__4E88ABD4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leave__UserId__5070F446");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loan");

                entity.Property(e => e.DateOfApplication).HasColumnType("date");

                entity.Property(e => e.EndDateOfRecovery).HasColumnType("date");

                entity.Property(e => e.InterestAmount).HasMaxLength(20);

                entity.Property(e => e.InterestRate).HasMaxLength(20);

                entity.Property(e => e.NoOfDays).HasMaxLength(20);

                entity.Property(e => e.NoOfInstRecovery).HasMaxLength(20);

                entity.Property(e => e.ProposedAmount).HasMaxLength(20);

                entity.Property(e => e.StartDateOfRecovery).HasColumnType("date");

                entity.Property(e => e.TypeOfLoan).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loan__CompanyId__6754599E");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Loan__EmployeeId__66603565");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loan__UserId__68487DD7");
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

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Payrolls)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payroll__Company__5441852A");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Payrolls)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Payroll__Employe__534D60F1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payrolls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payroll__UserId__5535A963");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionName).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Positions__Compa__628FA481");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Positions__Emplo__619B8048");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Positions__UserI__6383C8BA");
            });

            modelBuilder.Entity<Taxis>(entity =>
            {
                entity.HasKey(e => e.TaxesId)
                    .HasName("PK__Taxes__FC33F514E48578A6");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaxName).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Taxes)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Taxes__CompanyId__59063A47");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Taxes)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Taxes__EmployeeI__5812160E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Taxes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Taxes__UserId__59FA5E80");
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

            modelBuilder.Entity<training>(entity =>
            {
                entity.ToTable("Training");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ProjectName).HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.Trainee).HasMaxLength(20);

                entity.Property(e => e.TrainingLocation).HasMaxLength(20);

                entity.Property(e => e.TrainingProvider).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.training)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Training__Compan__6C190EBB");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.training)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Training__Employ__6B24EA82");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.training)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Training__UserId__6D0D32F4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
