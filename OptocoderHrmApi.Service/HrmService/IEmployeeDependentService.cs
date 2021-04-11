using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
   public interface IEmployeeDependentService
    {
        Task<ICollection<EmployeeDependent>> GetEmployeeDependentList();
        Task<EmployeeDependent> GetEmployeeDependent(int id);
        Task<EmployeeDependent> CreateNewEmployeeDependent(EmployeeDependent employeeDependent);

        Task<string> DeleteEmployeeDependent(int id);
        Task<string> UpdateEmployeeDependent(int id, EmployeeDependent employeeDependent);
    }

    public class EmployeeDependentService : IEmployeeDependentService
    {
        private readonly IEmployeeDependentRepository _repository;

        public EmployeeDependentService(IEmployeeDependentRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeDependent> CreateNewEmployeeDependent(EmployeeDependent employeeDependent)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeDependent(employeeDependent);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeDependent(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeDependent(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeDependent> GetEmployeeDependent(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeDependent(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeDependent>> GetEmployeeDependentList()
        {
            try
            {
                var res = await _repository.GetEmployeeDependentList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeDependent(int id, EmployeeDependent employeeDependent)
        {
            try
            {
                var res = await _repository.UpdateEmployeeDependent(id, employeeDependent);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
