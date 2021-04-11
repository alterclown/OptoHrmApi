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
    public interface ILeavePeriodRepository
    {
        Task<ICollection<LeavePeriod>> GetLeavePeriodsList();
        Task<LeavePeriod> GetLeavePeriods(int id);
        Task<LeavePeriod> CreateNewLeavePeriods(LeavePeriod leavePeriod);

        Task<string> DeleteLeavePeriods(int id);
        Task<string> UpdateLeavePeriods(int id, LeavePeriod leavePeriod);
    }

    public class LeavePeriodRepository : ILeavePeriodRepository
    {
        private readonly DataContext _context;

        public LeavePeriodRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<LeavePeriod> CreateNewLeavePeriods(LeavePeriod leavePeriod)
        {
            try
            {
                _context.LeavePeriods.Add(leavePeriod);
                await _context.SaveChangesAsync();
                return leavePeriod;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLeavePeriods(int id)
        {
            try
            {
                var response = await _context.LeavePeriods.FindAsync(id);
                _context.LeavePeriods.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LeavePeriod> GetLeavePeriods(int id)
        {
            try
            {
                var res = await _context.LeavePeriods.FirstOrDefaultAsync(m => m.LeavePeriodId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<LeavePeriod>> GetLeavePeriodsList()
        {
            try
            {
                var response = from c in _context.LeavePeriods
                               orderby c.LeavePeriodId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLeavePeriods(int id, LeavePeriod leavePeriod)
        {
            try
            {
                var res = await _context.LeavePeriods.FirstOrDefaultAsync(m => m.LeavePeriodId == id);
                res.LeavePeriodName = leavePeriod.LeavePeriodName;
                res.PeriodStartDate = leavePeriod.PeriodStartDate;
                res.PeriodEndDate = leavePeriod.PeriodEndDate;
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
