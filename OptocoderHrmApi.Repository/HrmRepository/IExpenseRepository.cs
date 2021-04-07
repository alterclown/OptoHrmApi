using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IExpenseRepository
    {
        Task<ICollection<Expense>> GetExpenseList();
        Task<Expense> GetExpense(int id);
        Task<Expense> CreateNewExpense(Expense expense);

        Task<string> DeleteExpense(int id);
        Task<string> UpdateExpense(int id, Expense expense);
    }

    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext _context;

        public ExpenseRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Expense> CreateNewExpense(Expense expense)
        {
            try
            {
                _context.Expenses.Add(expense);
                await _context.SaveChangesAsync();
                return expense;
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
                var response = await _context.Expenses.FindAsync(id);
                _context.Expenses.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.Expenses.FirstOrDefaultAsync(m => m.ExpenseId == id);
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
                var response = from c in _context.Expenses
                               orderby c.ExpenseId descending
                               select c;
                return await response.ToListAsync();
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
                var res = await _context.Expenses.FirstOrDefaultAsync(m => m.ExpenseId == id);
                res.ExpenseName = expense.ExpenseName;
                _context.Update(res);
                await _context.SaveChangesAsync();
                return "Updated Record";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
