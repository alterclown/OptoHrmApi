using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using OptocoderHrmApi.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetEmployeeList();
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

        public async Task<ICollection<Employee>> GetEmployeeList()
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
                var res = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
                res.EmployeeNumber = employee.EmployeeNumber;
                res.FirstName = employee.FirstName;
                res.MiddleName = employee.MiddleName;
                res.LastName = employee.LastName;
                res.Nationality = employee.Nationality;
                res.DateofBirth = employee.DateofBirth;
                res.Gender = employee.Gender;
                res.MaritalStatus = employee.MaritalStatus;
                res.Ethnicity = employee.Ethnicity;
                res.ImmigrationStatus = employee.ImmigrationStatus;
                res.SsnNric = employee.SsnNric;
                res.Nic = employee.Nic;
                res.OtherId = employee.OtherId;
                res.DrivingLicenseNo = employee.DrivingLicenseNo;
                res.EmploymentStatus = employee.EmploymentStatus;
                res.Department = employee.Department;
                res.JobTitle = employee.JobTitle;
                res.PayGrade = employee.PayGrade;
                res.JoinedDate = employee.JoinedDate;
                res.ConfirmationDate = employee.ConfirmationDate;
                res.TerminationDate = employee.TerminationDate;
                res.WorkStationId = employee.WorkStationId;
                res.AddressLine1 = employee.AddressLine1;
                res.AddressLine2 = employee.AddressLine2;
                res.City = employee.City;
                res.Country = employee.Country;
                res.Province = employee.Province;
                res.PostalZipCode = employee.PostalZipCode;
                res.HomePhone = employee.HomePhone;
                res.MobilePhone = employee.MobilePhone;
                res.WorkPhone = employee.WorkPhone;
                res.WorkEmail = employee.WorkEmail;
                res.PrivateEmail = employee.PrivateEmail;
                res.Supervisor = employee.Supervisor;
                res.IndirectSupervisors = employee.IndirectSupervisors;
                res.FirstLevelApprover = employee.FirstLevelApprover;
                res.SecondLevelApprover = employee.SecondLevelApprover;
                res.ThirdLevelApprover = employee.ThirdLevelApprover;
                res.Notes = employee.Notes;
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
