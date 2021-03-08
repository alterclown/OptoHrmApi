using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface IEmployeeSalaryService
    {
        Task<List<EmployeeSalary>> GetEmployeeSalaryList();
        Task<EmployeeSalary> GetEmployeeSalary(int id);
        Task<EmployeeSalary> CreateNewEmployeeSalary(EmployeeSalary salary);
        Task<string> DeleteEmployeeSalary(int id);
        Task<string> UpdateEmployeeSalary(int id, EmployeeSalary salary);
    }

    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly IEmployeeSalaryRepository _repository;

        public EmployeeSalaryService(IEmployeeSalaryRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeSalary> CreateNewEmployeeSalary(EmployeeSalary salary)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeSalary(salary);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeSalary(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeSalary(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeSalary> GetEmployeeSalary(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeSalary(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<EmployeeSalary>> GetEmployeeSalaryList()
        {
            try
            {
                var res = await _repository.GetEmployeeSalaryList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeSalary(int id, EmployeeSalary salary)
        {
            try
            {
                var res = await _repository.UpdateEmployeeSalary(id,salary);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
