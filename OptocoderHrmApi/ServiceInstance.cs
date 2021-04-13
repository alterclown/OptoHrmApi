using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Repository.HrmRepository;
using OptocoderHrmApi.Service.HrmService;
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICertificationService, CertificationService>();
            services.AddScoped<ICertificationRepository, CertificationRepository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IEmploymentStatusService, EmploymentStatusService>();
            services.AddScoped<IEmploymentStatusRepository, EmploymentStatusRepository>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IEmployeeArchiveService, EmployeeArchiveService>();
            services.AddScoped<IEmployeeArchiveRepository, EmployeeArchiveRepository>();
            services.AddScoped<IEmployeeCertificationService, EmployeeCertificationService>();
            services.AddScoped<IEmployeeCertificationRepository, EmployeeCertificationRepository>();
            services.AddScoped<IEmployeeDeactivateService, EmployeeDeactivateService>();
            services.AddScoped<IEmployeeDeactivateRepository, EmployeeDeactivateRepository>();
            services.AddScoped<IEmployeeDependentService, EmployeeDependentService>();
            services.AddScoped<IEmployeeDependentRepository, EmployeeDependentRepository>();
            services.AddScoped<IEmployeeEducationService, EmployeeEducationService>();
            services.AddScoped<IEmployeeEducationRepository, EmployeeEducationRepository>();
            services.AddScoped<IEmployeeEmergencyContactService, EmployeeEmergencyContactService>();
            services.AddScoped<IEmployeeEmergencyContactRepository, EmployeeEmergencyContactRepository>();
            services.AddScoped<IEmployeeExpenseService, EmployeeExpenseService>();
            services.AddScoped<IEmployeeExpenseRepository, EmployeeExpenseRepository>();
            services.AddScoped<IEmployeeLanguageService, EmployeeLanguageService>();
            services.AddScoped<IEmployeeLanguageRepository, EmployeeLanguageRepository>();
            services.AddScoped<IEmployeeLeaveService, EmployeeLeaveService>();
            services.AddScoped<IEmployeeLeaveRepository, EmployeeLeaveRepository>();
            services.AddScoped<IEmployeePayrollService, EmployeePayrollService>();
            services.AddScoped<IEmployeePayrollRepository, EmployeePayrollRepository>();
            services.AddScoped<IEmployeeProjectService, EmployeeProjectService>();
            services.AddScoped<IEmployeeProjectRepository, EmployeeProjectRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeSkillService, EmployeeSkillService>();
            services.AddScoped<IEmployeeSkillsRepository, EmployeeSkillsRepository>();
            services.AddScoped<IHolidayService, HolidayService>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<IJobTitleService, JobTitleService>();
            services.AddScoped<IJobTitleRepository, JobTitleRepository>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILeavePeriodService, LeavePeriodService>();
            services.AddScoped<ILeavePeriodRepository, LeavePeriodRepository>();
            services.AddScoped<ILeaveRulesService, LeaveRulesService>();
            services.AddScoped<ILeaveRulesRepository, LeaveRulesRepository>();
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILoanTypeService, LoanTypeService>();
            services.AddScoped<ILoanTypeRepository, LoanTypeRepository>();
            services.AddScoped<IMonitorAttendanceService, MonitorAttendanceService>();
            services.AddScoped<IMonitorAttendanceRepository, MonitorAttendanceRepository>();
            services.AddScoped<IMyProjectService, MyProjectService>();
            services.AddScoped<IMyProjectRepository, MyProjectRepository>();
            services.AddScoped<IOverTimeRequestService, OverTimeRequestService>();
            services.AddScoped<IOverTimeRequestRepository, OverTimeRequestRepository>();
            services.AddScoped<IOverTimeService, OverTimeService>();
            services.AddScoped<IOverTimeRepository, OverTimeRepository>();
            services.AddScoped<IPaidTimeService, PaidTimeService>();
            services.AddScoped<IPaidTimeRepository, PaidTimeRepository>();
            services.AddScoped<IPayGradeService, PayGradeService>();
            services.AddScoped<IPayGradeRepository, PayGradeRepository>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IPersonalDocumentService, PersonalDocumentService>();
            services.AddScoped<IPersonalDocumentRepository, PersonalDocumentRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<ISkillsRepository, SkillsRepository>();
            services.AddScoped<ITrainingSessionService, TrainingSessionService>();
            services.AddScoped<ITrainingSessionRepository, TrainingSessionRepository>();
            services.AddScoped<ITrainingSetupService, TrainingSetupService>();
            services.AddScoped<ITrainingSetupRepository, TrainingSetupRepository>();
            services.AddScoped<ITravelService, TravelService>();
            services.AddScoped<ITravelRepository, TravelRepository>();
            services.AddScoped<IWorkWeekService, WorkWeekService>();
            services.AddScoped<IWorkWeekRepository, WorkWeekRepository>();
        }
    }

}
