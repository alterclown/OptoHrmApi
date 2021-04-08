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
    public interface IEmployeeEducationRepository
    {
        Task<ICollection<EmployeeEducation>> GetEmployeeEducationList();
        Task<EmployeeEducation> GetEmployeeEducation(int id);
        Task<EmployeeEducation> CreateNewEmployeeEducation(EmployeeEducation employeeEducation);

        Task<string> DeleteEmployeeEducation(int id);
        Task<string> UpdateEmployeeEducation(int id, EmployeeEducation employeeEducation);
    }

    public class EmployeeEducationRepository : IEmployeeEducationRepository
    {
        private readonly DataContext _context;

        public EmployeeEducationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeEducation> CreateNewEmployeeEducation(EmployeeEducation employeeEducation)
        {
            try
            {
                _context.EmployeeEducations.Add(employeeEducation);
                await _context.SaveChangesAsync();
                return employeeEducation;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeEducation(int id)
        {
            try
            {
                var response = await _context.EmployeeEducations.FindAsync(id);
                _context.EmployeeEducations.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeEducation> GetEmployeeEducation(int id)
        {
            try
            {
                var res = await _context.EmployeeEducations.FirstOrDefaultAsync(m => m.EmployeeEducationId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeEducation>> GetEmployeeEducationList()
        {
            try
            {
                var response = from c in _context.EmployeeEducations
                               orderby c.EmployeeEducationId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeEducation(int id, EmployeeEducation employeeEducation)
        {
            try
            {
                var res = await _context.EmployeeEducations.FirstOrDefaultAsync(m => m.EmployeeEducationId == id);
                res.EmployeeName = employeeEducation.EmployeeName;
                res.Institute = employeeEducation.Institute;
                res.StartDate = employeeEducation.StartDate;
                res.CompletedOn = employeeEducation.CompletedOn;
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
