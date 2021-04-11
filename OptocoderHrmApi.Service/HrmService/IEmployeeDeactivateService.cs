using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmployeeDeactivateService
    {
        Task<ICollection<EmployeeDeactivated>> GetEmployeeDeactivateList();
        Task<EmployeeDeactivated> GetEmployeeDeactivate(int id);
        Task<EmployeeDeactivated> CreateNewEmployeeDeactivate(EmployeeDeactivated employeeDeactivate);

        Task<string> DeleteEmployeeDeactivate(int id);
        Task<string> UpdateEmployeeDeactivate(int id, EmployeeDeactivated employeeDeactivate);
    }

    public class EmployeeDeactivateService : IEmployeeDeactivateService
    {
        private readonly IEmployeeDeactivateRepository _repository;

        public EmployeeDeactivateService(IEmployeeDeactivateRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeDeactivated> CreateNewEmployeeDeactivate(EmployeeDeactivated employeeDeactivate)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeDeactivated(employeeDeactivate);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeDeactivate(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeDeactivated(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeDeactivated> GetEmployeeDeactivate(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeDeactivated(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeDeactivated>> GetEmployeeDeactivateList()
        {
            try
            {
                var res = await _repository.GetEmployeeDeactivatedList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeDeactivate(int id, EmployeeDeactivated employeeDeactivate)
        {
            try
            {
                var res = await _repository.UpdateEmployeeDeactivated(id, employeeDeactivate);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
