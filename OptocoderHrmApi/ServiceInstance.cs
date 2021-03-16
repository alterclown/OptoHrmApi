using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Repository.Reposiitory;
using OptocoderHrmApi.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptocoderHrmApi
{
    public static class ServiceInstance
    {
        public static void RegisterOptocoderServiceInstance(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(nameof(DataContext));
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeAttendanceService, EmployeeAttendanceService>();
            services.AddScoped<IEmployeeAttendanceRepository, EmployeeAttendanceRepository>();
            services.AddScoped<IEmployeeProjectService, EmployeeProjectService>();
            services.AddScoped<IEmployeeProjectRepository, EmployeeProjectRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeSalaryService, EmployeeSalaryService>();
            services.AddScoped<IEmployeeSalaryRepository, EmployeeSalaryRepository>();
            services.AddScoped<IGeoLocationService, GeoLocationService>();
            services.AddScoped<IGeoLocationRepository, GeoLocationRepository>();
            services.AddScoped<ILeaveService, LeaveService>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IPayrollService, PayrollService>();
            services.AddScoped<IPayrollRepository, PayrollRepository>();
            services.AddScoped<IDesignationService, DesignationService>();
            services.AddScoped<IDesgnationRepository, DesinationRepository>();
            services.AddScoped<ITaxService, TaxService>();
            services.AddScoped<ITaxRepository, TaxRepository>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }

}
