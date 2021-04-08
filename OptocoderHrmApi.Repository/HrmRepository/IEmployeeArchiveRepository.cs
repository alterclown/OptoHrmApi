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
    public interface IEmployeeArchiveRepository
    {
        Task<ICollection<EmployeeArchived>> GetEmployeeArchiveList();
        Task<EmployeeArchived> GetEmployeeArchive(int id);
        Task<EmployeeArchived> CreateNewEmployeeArchive(EmployeeArchived employeeArchive);

        Task<string> DeleteEmployeeArchive(int id);
        Task<string> UpdateEmployeeArchive(int id, EmployeeArchived employeeArchive);
    }

    public class EmployeeArchiveRepository : IEmployeeArchiveRepository
    {
        private readonly DataContext _context;

        public EmployeeArchiveRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeArchived> CreateNewEmployeeArchive(EmployeeArchived employeeArchive)
        {
            try
            {
                _context.EmployeeArchiveds.Add(employeeArchive);
                await _context.SaveChangesAsync();
                return employeeArchive;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeArchive(int id)
        {
            try
            {
                var response = await _context.EmployeeArchiveds.FindAsync(id);
                _context.EmployeeArchiveds.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeArchived> GetEmployeeArchive(int id)
        {
            try
            {
                var res = await _context.EmployeeArchiveds.FirstOrDefaultAsync(m => m.EmployeeArchivedId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeArchived>> GetEmployeeArchiveList()
        {
            try
            {
                var response = from c in _context.EmployeeArchiveds
                               orderby c.EmployeeArchivedId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeArchive(int id, EmployeeArchived employeeArchive)
        {
            try
            {
                var res = await _context.EmployeeArchiveds.FirstOrDefaultAsync(m => m.EmployeeArchivedId == id);
                res.EmployeeNumber = employeeArchive.EmployeeNumber;
                res.FirstName = employeeArchive.FirstName;
                res.LastName = employeeArchive.LastName;
                res.Department = employeeArchive.Department;
                res.Supervisor = employeeArchive.Supervisor;
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
