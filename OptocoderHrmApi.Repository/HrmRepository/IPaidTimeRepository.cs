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
    public interface IPaidTimeRepository
    {
        Task<ICollection<PaidTimeOff>> GetPaidTimesList();
        Task<PaidTimeOff> GetPaidTimes(int id);
        Task<PaidTimeOff> CreateNewPaidTimes(PaidTimeOff paidTimes);

        Task<string> DeletePaidTimes(int id);
        Task<string> UpdatePaidTimes(int id, PaidTimeOff paidTimes);
    }

    public class PaidTimeRepository : IPaidTimeRepository
    {
        private readonly DataContext _context;

        public PaidTimeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<PaidTimeOff> CreateNewPaidTimes(PaidTimeOff paidTimes)
        {
            try
            {
                _context.PaidTimeOffs.Add(paidTimes);
                await _context.SaveChangesAsync();
                return paidTimes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePaidTimes(int id)
        {
            try
            {
                var response = await _context.PaidTimeOffs.FindAsync(id);
                _context.PaidTimeOffs.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PaidTimeOff> GetPaidTimes(int id)
        {
            try
            {
                var res = await _context.PaidTimeOffs.FirstOrDefaultAsync(m => m.PaidTimeOffId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<PaidTimeOff>> GetPaidTimesList()
        {
            try
            {
                var response = from c in _context.PaidTimeOffs
                               orderby c.PaidTimeOffId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdatePaidTimes(int id, PaidTimeOff paidTimes)
        {
            try
            {
                var res = await _context.PaidTimeOffs.FirstOrDefaultAsync(m => m.PaidTimeOffId == id);
                res.LeaveType = paidTimes.LeaveType;
                res.EmployeeName = paidTimes.EmployeeName;
                res.LeavePeriod = paidTimes.LeavePeriod;
                res.LeaveAmount = paidTimes.LeaveAmount;
                res.Note = paidTimes.Note;
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
