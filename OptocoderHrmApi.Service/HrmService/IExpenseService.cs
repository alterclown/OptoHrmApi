using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IExpenseService
    {
        Task<ICollection<Expense>> GetExpenseList();
        Task<Expense> GetExpense(int id);
        Task<Expense> CreateNewExpense(Expense expense);

        Task<string> DeleteExpense(int id);
        Task<string> UpdateExpense(int id, Expense expense);
    }

    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;

        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }
        public async Task<Expense> CreateNewExpense(Expense expense)
        {
            try
            {
                var res = await _repository.CreateNewExpense(expense);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteExpense(int id)
        {
            try
            {
                var res = await _repository.DeleteExpense(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Expense> GetExpense(int id)
        {
            try
            {
                var res = await _repository.GetExpense(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Expense>> GetExpenseList()
        {
            try
            {
                var res = await _repository.GetExpenseList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateExpense(int id, Expense expense)
        {
            try
            {
                var res = await _repository.UpdateExpense(id,expense);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
