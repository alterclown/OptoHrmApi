using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IEmployeeExpenseRepository
    {
        Task<ICollection<EmployeeExpense>> GetEmployeeExpenseList();
        Task<EmployeeExpense> GetEmployeeExpense(int id);
        Task<EmployeeExpense> CreateNewEmployeeExpense(EmployeeExpense employeeExpense);

        Task<string> DeleteEmployeeExpense(int id);
        Task<string> UpdateEmployeeExpense(int id, EmployeeExpense employeeExpense);
    }

    public class EmployeeExpenseRepository : IEmployeeExpenseRepository
    {
        private readonly DataContext _context;

        public EmployeeExpenseRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeExpense> CreateNewEmployeeExpense(EmployeeExpense employeeExpense)
        {
            try
            {
                _context.EmployeeExpenses.Add(employeeExpense);
                await _context.SaveChangesAsync();
                return employeeExpense;
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
                var response = await _context.EmployeeExpenses.FindAsync(id);
                _context.EmployeeExpenses.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.EmployeeExpenses.FirstOrDefaultAsync(m => m.ExpenseId == id);
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
                var response = from c in _context.EmployeeExpenses
                               orderby c.ExpenseId descending
                               select c;
                return await response.ToListAsync();
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
                var res = await _context.EmployeeExpenses.FirstOrDefaultAsync(m => m.ExpenseId == id);
                res.EmployeeName = employeeExpense.EmployeeName;
                res.Date = employeeExpense.Date;
                res.PaymentMethod = employeeExpense.PaymentMethod;
                res.TransactionNo = employeeExpense.TransactionNo;
                res.Payee = employeeExpense.Payee;
                res.Category = employeeExpense.Category;
                res.Amount = employeeExpense.Amount;
                res.Currency = employeeExpense.Currency;
                res.Status = employeeExpense.Status;
                res.Notes = employeeExpense.Notes;
                res.Attachment = employeeExpense.Attachment;
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
