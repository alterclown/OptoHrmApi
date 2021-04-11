using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IOverTimeRepository
    {
        Task<ICollection<OverTime>> GetOverTimesList();
        Task<OverTime> GetOverTimes(int id);
        Task<OverTime> CreateNewOverTimes(OverTime overTimes);

        Task<string> DeleteOverTimes(int id);
        Task<string> UpdateOverTimes(int id, OverTime overTimes);
    }
    public class OverTimeRepository : IOverTimeRepository
    {
        private readonly DataContext _context;

        public OverTimeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<OverTime> CreateNewOverTimes(OverTime overTimes)
        {
            try
            {
                _context.OverTimes.Add(overTimes);
                await _context.SaveChangesAsync();
                return overTimes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteOverTimes(int id)
        {
            try
            {
                var response = await _context.OverTimes.FindAsync(id);
                _context.OverTimes.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<OverTime> GetOverTimes(int id)
        {
            try
            {
                var res = await _context.OverTimes.FirstOrDefaultAsync(m => m.OverTimeId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<OverTime>> GetOverTimesList()
        {
            try
            {
                var response = from c in _context.OverTimes
                               orderby c.OverTimeId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateOverTimes(int id, OverTime overTimes)
        {
            try
            {
                var res = await _context.OverTimes.FirstOrDefaultAsync(m => m.OverTimeId == id);
                res.Category = overTimes.Category;
                res.OverTimeName = overTimes.OverTimeName;
                res.StartTime = overTimes.StartTime;
                res.EndTime = overTimes.EndTime;
                res.Project = overTimes.Project;
                res.Notes = overTimes.Notes;
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
