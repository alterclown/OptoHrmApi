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
    public interface IEmployeeDeactivateRepository
    {
        Task<ICollection<EmployeeDeactivated>> GetEmployeeDeactivatedList();
        Task<EmployeeDeactivated> GetEmployeeDeactivated(int id);
        Task<EmployeeDeactivated> CreateNewEmployeeDeactivated(EmployeeDeactivated employeeDeactivated);

        Task<string> DeleteEmployeeDeactivated(int id);
        Task<string> UpdateEmployeeDeactivated(int id, EmployeeDeactivated employeeDeactivated);
    }

    public class EmployeeDeactivateRepository : IEmployeeDeactivateRepository
    {
        private readonly DataContext _context;

        public EmployeeDeactivateRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeDeactivated> CreateNewEmployeeDeactivated(EmployeeDeactivated employeeDeactivated)
        {
            try
            {
                _context.EmployeeDeactivateds.Add(employeeDeactivated);
                await _context.SaveChangesAsync();
                return employeeDeactivated;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeDeactivated(int id)
        {
            try
            {
                var response = await _context.EmployeeDeactivateds.FindAsync(id);
                _context.EmployeeDeactivateds.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeDeactivated> GetEmployeeDeactivated(int id)
        {
            try
            {
                var res = await _context.EmployeeDeactivateds.FirstOrDefaultAsync(m => m.EmployeeDeactivatedId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeDeactivated>> GetEmployeeDeactivatedList()
        {
            try
            {
                var response = from c in _context.EmployeeDeactivateds
                               orderby c.EmployeeDeactivatedId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeDeactivated(int id, EmployeeDeactivated employeeDeactivated)
        {
            try
            {
                var res = await _context.EmployeeDeactivateds.FirstOrDefaultAsync(m => m.EmployeeDeactivatedId == id);
                res.EmployeeNumber = employeeDeactivated.EmployeeNumber;
                res.FirstName = employeeDeactivated.FirstName;
                res.LastName = employeeDeactivated.LastName;
                res.Department = employeeDeactivated.Department;
                res.Supervisor = employeeDeactivated.Supervisor;
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
