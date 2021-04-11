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
    public interface IOverTimeRequestRepository
    {
        Task<ICollection<OverTimeRequest>> GetOverTimeRequestsList();
        Task<OverTimeRequest> GetOverTimeRequests(int id);
        Task<OverTimeRequest> CreateNewOverTimeRequests(OverTimeRequest overTimeRequests);

        Task<string> DeleteOverTimeRequests(int id);
        Task<string> UpdateOverTimeRequests(int id, OverTimeRequest overTimeRequests);
    }

    public class OverTimeRequestRepository : IOverTimeRequestRepository
    {
        private readonly DataContext _context;

        public OverTimeRequestRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<OverTimeRequest> CreateNewOverTimeRequests(OverTimeRequest overTimeRequests)
        {
            try
            {
                _context.OverTimeRequests.Add(overTimeRequests);
                await _context.SaveChangesAsync();
                return overTimeRequests;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteOverTimeRequests(int id)
        {
            try
            {
                var response = await _context.OverTimeRequests.FindAsync(id);
                _context.OverTimeRequests.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<OverTimeRequest> GetOverTimeRequests(int id)
        {
            try
            {
                var res = await _context.OverTimeRequests.FirstOrDefaultAsync(m => m.OverTimeRequestId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<OverTimeRequest>> GetOverTimeRequestsList()
        {
            try
            {
                var response = from c in _context.OverTimeRequests
                               orderby c.OverTimeRequestId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateOverTimeRequests(int id, OverTimeRequest overTimeRequests)
        {
            try
            {
                var res = await _context.OverTimeRequests.FirstOrDefaultAsync(m => m.OverTimeRequestId == id);
                res.EmployeeName = overTimeRequests.EmployeeName;
                res.Category = overTimeRequests.Category;
                res.StartTime = overTimeRequests.StartTime;
                res.EndTime = overTimeRequests.EndTime;
                res.Project = overTimeRequests.Project;
                res.Status = overTimeRequests.Status;
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
