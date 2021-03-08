using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeeList();
        Task<Employee> GetEmployee(int id);
        Task<Employee> CreateNewEmployee(Employee employee);
        Task<string> DeleteEmployee(int id);
        Task<string> UpdateEmployee(int id, Employee employee);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Employee> CreateNewEmployee(Employee employee)
        {
            try
            {
                var res = await _repository.CreateNewEmployee(employee);
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployee(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployee(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                var res = await _repository.GetEmployee(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            try
            {
                var res = await _repository.GetEmployeeList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var res = await _repository.UpdateEmployee(id,employee);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
