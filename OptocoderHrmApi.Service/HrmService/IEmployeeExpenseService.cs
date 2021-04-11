using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmployeeExpenseService
    {
        Task<ICollection<EmployeeExpense>> GetEmployeeExpenseList();
        Task<EmployeeExpense> GetEmployeeExpense(int id);
        Task<EmployeeExpense> CreateNewEmployeeExpense(EmployeeExpense employeeExpense);

        Task<string> DeleteEmployeeExpense(int id);
        Task<string> UpdateEmployeeExpense(int id, EmployeeExpense employeeExpense);
    }

    public class EmployeeExpenseService : IEmployeeExpenseService
    {
        private readonly IEmployeeExpenseRepository _repository;

        public EmployeeExpenseService(IEmployeeExpenseRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeExpense> CreateNewEmployeeExpense(EmployeeExpense employeeExpense)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeExpense(employeeExpense);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeExpense(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeExpense(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeExpense> GetEmployeeExpense(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeExpense(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeExpense>> GetEmployeeExpenseList()
        {
            try
            {
                var res = await _repository.GetEmployeeExpenseList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeExpense(int id, EmployeeExpense employeeExpense)
        {
            try
            {
                var res = await _repository.UpdateEmployeeExpense(id, employeeExpense);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
