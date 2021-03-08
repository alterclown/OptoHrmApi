using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface ILeaveRepository
    {
        Task<List<Leave>> GetLeaveList();
        Task<Leave> GetLeave(int id);
        Task<Leave> CreateNewLeave(Leave leave);
        Task<string> DeleteLeave(int id);
        Task<string> UpdateLeave(int id, Leave leave);
    }

    public class LeaveRepository : ILeaveRepository
    {
        private readonly DataContext _context;

        public LeaveRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Leave> CreateNewLeave(Leave leave)
        {
            try
            {
                _context.Leaves.Add(leave);
                await _context.SaveChangesAsync();
                return leave;

            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLeave(int id)
        {
            try
            {
                var res = await _context.Leaves.FindAsync(id);
                _context.Leaves.Remove(res);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Leave> GetLeave(int id)
        {
            try
            {
                var res = await _context.Leaves.FirstOrDefaultAsync(x => x.LeaveId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Leave>> GetLeaveList()
        {
            try
            {
                var res = from c in _context.Leaves
                          orderby c.LeaveId ascending
                          select c;

                var items = _context.Leaves.Skip((2 - 1) * 10).Take(10).ToListAsync();



                return await items;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLeave(int id, Leave leave)
        {
            try
            {
                var response = await _context.Leaves.FirstOrDefaultAsync(m => m.LeaveId == id);
                response.EmployeeId = leave.EmployeeId;
                response.Month = leave.Month;
                response.StartDate = leave.StartDate;
                response.EndDate = leave.EndDate;
                response.NoOfDays = leave.NoOfDays;
                response.LeavePeriod = leave.LeavePeriod;
                response.CompanyId = leave.CompanyId;
                response.UserId = leave.UserId;
                _context.Leaves.Update(response);
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
