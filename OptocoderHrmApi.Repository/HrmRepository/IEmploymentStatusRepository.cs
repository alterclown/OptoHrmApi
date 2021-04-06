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
    public interface IEmploymentStatusRepository
    {
        Task<ICollection<EmploymentStatus>> GetEmploymentStatusList();
        Task<EmploymentStatus> GetEmploymentStatus(int id);
        Task<EmploymentStatus> CreateNewEmploymentStatus(EmploymentStatus employmentStatus);

        Task<string> DeleteEmploymentStatus(int id);
        Task<string> UpdateEmploymentStatus(int id, EmploymentStatus employmentStatus);
    }

    public class EmploymentStatusRepository : IEmploymentStatusRepository
    {
        private readonly DataContext _context;

        public EmploymentStatusRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmploymentStatus> CreateNewEmploymentStatus(EmploymentStatus employmentStatus)
        {
            try
            {
                _context.EmploymentStatuses.Add(employmentStatus);
                await _context.SaveChangesAsync();
                return employmentStatus;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmploymentStatus(int id)
        {
            try
            {
                var response = await _context.EmploymentStatuses.FindAsync(id);
                _context.EmploymentStatuses.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmploymentStatus> GetEmploymentStatus(int id)
        {
            try
            {
                var res = await _context.EmploymentStatuses.FirstOrDefaultAsync(m => m.EmploymentStatusId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmploymentStatus>> GetEmploymentStatusList()
        {
            try
            {
                var response = from c in _context.EmploymentStatuses
                               orderby c.EmploymentStatusId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmploymentStatus(int id, EmploymentStatus employmentStatus)
        {
            try
            {
                var res = await _context.EmploymentStatuses.FirstOrDefaultAsync(m => m.EmploymentStatusId == id);
                res.EmploymentStatusName = employmentStatus.EmploymentStatusName;
                res.Description = employmentStatus.Description;
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
