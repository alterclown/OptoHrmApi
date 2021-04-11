using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmployeeLanguageService
    {
        Task<ICollection<EmployeeLanguage>> GetEmployeeLanguageList();
        Task<EmployeeLanguage> GetEmployeeLanguage(int id);
        Task<EmployeeLanguage> CreateNewEmployeeLanguage(EmployeeLanguage employeeLanguage);

        Task<string> DeleteEmployeeLanguage(int id);
        Task<string> UpdateEmployeeLanguage(int id, EmployeeLanguage employeeLanguage);
    }

    public class EmployeeLanguageService : IEmployeeLanguageService
    {
        private readonly IEmployeeLanguageRepository _repository;

        public EmployeeLanguageService(IEmployeeLanguageRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeLanguage> CreateNewEmployeeLanguage(EmployeeLanguage employeeLanguage)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeLanguage(employeeLanguage);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeLanguage(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeLanguage(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeLanguage> GetEmployeeLanguage(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeLanguage(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeLanguage>> GetEmployeeLanguageList()
        {
            try
            {
                var res = await _repository.GetEmployeeLanguageList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeLanguage(int id, EmployeeLanguage employeeLanguage)
        {
            try
            {
                var res = await _repository.UpdateEmployeeLanguage(id, employeeLanguage);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
