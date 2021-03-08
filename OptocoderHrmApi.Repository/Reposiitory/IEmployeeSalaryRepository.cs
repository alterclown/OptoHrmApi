using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface IEmployeeSalaryRepository
    {
        Task<List<EmployeeSalary>> GetEmployeeSalaryList();
        Task<EmployeeSalary> GetEmployeeSalary(int id);
        Task<EmployeeSalary> CreateNewEmployeeSalary(EmployeeSalary salary);
        Task<string> DeleteEmployeeSalary(int id);
        Task<string> UpdateEmployeeSalary(int id, EmployeeSalary salary);
    }

    public class EmployeeSalaryRepository : IEmployeeSalaryRepository
    {
        private readonly DataContext _context;

        public EmployeeSalaryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeSalary> CreateNewEmployeeSalary(EmployeeSalary salary)
        {
            try
            {
                _context.EmployeeSalaries.Add(salary);
                await _context.SaveChangesAsync();
                return salary;
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
                var response = await _context.EmployeeSalaries.FindAsync(id);
                _context.EmployeeSalaries.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.EmployeeSalaries.FirstOrDefaultAsync(m => m.SalaryId == id);
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
                var response = from c in _context.EmployeeSalaries
                               orderby c.SalaryId descending
                               select c;
                return await response.ToListAsync();
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
                var response = await _context.EmployeeSalaries.FirstOrDefaultAsync(m => m.SalaryId == id);
                response.EmployeeId = salary.EmployeeId;
                response.SalaryAmount = salary.SalaryAmount;
                response.Tax = salary.Tax;
                response.Status = salary.Status;
                response.CompanyId = salary.CompanyId;
                response.UserId = salary.UserId;
                _context.EmployeeSalaries.Update(response);
                await _context.SaveChangesAsync();
                return "Updated SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
