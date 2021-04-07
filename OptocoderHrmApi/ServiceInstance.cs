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
        }
    }

}
