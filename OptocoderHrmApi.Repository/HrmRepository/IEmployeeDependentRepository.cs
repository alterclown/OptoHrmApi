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
    public interface IEmployeeDependentRepository
    {
        Task<ICollection<EmployeeDependent>> GetEmployeeDependentList();
        Task<EmployeeDependent> GetEmployeeDependent(int id);
        Task<EmployeeDependent> CreateNewEmployeeDependent(EmployeeDependent employeeDependent);

        Task<string> DeleteEmployeeDependent(int id);
        Task<string> UpdateEmployeeDependent(int id, EmployeeDependent employeeDependent);
    }

    public class EmployeeDependentRepository : IEmployeeDependentRepository
    {
        private readonly DataContext _context;

        public EmployeeDependentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeDependent> CreateNewEmployeeDependent(EmployeeDependent employeeDependent)
        {
            try
            {
                _context.EmployeeDependents.Add(employeeDependent);
                await _context.SaveChangesAsync();
                return employeeDependent;
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
                var response = await _context.EmployeeDependents.FindAsync(id);
                _context.EmployeeDependents.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.EmployeeDependents.FirstOrDefaultAsync(m => m.EmployeeDependentId == id);
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
                var response = from c in _context.EmployeeDependents
                               orderby c.EmployeeDependentId descending
                               select c;
                return await response.ToListAsync();
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
                var res = await _context.EmployeeDependents.FirstOrDefaultAsync(m => m.EmployeeDependentId == id);
                res.EmployeeName = employeeDependent.EmployeeName;
                res.Name = employeeDependent.Name;
                res.Relationship = employeeDependent.Relationship;
                res.DateofBirth = employeeDependent.DateofBirth;
                res.IdNumber = employeeDependent.IdNumber;
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
