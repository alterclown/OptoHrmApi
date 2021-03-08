using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Data.DbContexts;

namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeeList();
        Task<Employee> GetEmployee(int id);
        Task<Employee> CreateNewEmployee(Employee employee);
        Task<string> DeleteEmployee(int id);
        Task<string> UpdateEmployee(int id, Employee employee);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Employee> CreateNewEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
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
                var response = await _context.Employees.FindAsync(id);
                _context.Employees.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
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
                var response = from c in _context.Employees
                               orderby c.EmployeeId descending
                               select c;
                return await response.ToListAsync();
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
                var response = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
                response.FirstName = employee.FirstName;
                response.LastName = employee.LastName;
                response.BirthDate = employee.BirthDate;
                response.Age = employee.Age;
                response.Sex = employee.Sex;
                response.Address = employee.Address;
                response.JoinDate = employee.JoinDate;
                response.LeaveDate = employee.LeaveDate;
                response.UserId = employee.UserId;
                response.CompanyId = employee.CompanyId;
                _context.Employees.Update(response);
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
