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
    public interface ILeaveTypeRepository
    {
        Task<ICollection<LeaveType>> GetLeaveTypesList();
        Task<LeaveType> GetLeaveTypes(int id);
        Task<LeaveType> CreateNewLeaveTypes(LeaveType leaveTypes);

        Task<string> DeleteLeaveTypes(int id);
        Task<string> UpdateLeaveTypes(int id, LeaveType leaveTypes);
    }

    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly DataContext _context;

        public LeaveTypeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<LeaveType> CreateNewLeaveTypes(LeaveType leaveTypes)
        {
            try
            {
                _context.LeaveTypes.Add(leaveTypes);
                await _context.SaveChangesAsync();
                return leaveTypes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLeaveTypes(int id)
        {
            try
            {
                var response = await _context.LeaveTypes.FindAsync(id);
                _context.LeaveTypes.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LeaveType> GetLeaveTypes(int id)
        {
            try
            {
                var res = await _context.LeaveTypes.FirstOrDefaultAsync(m => m.LeaveTypeId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<LeaveType>> GetLeaveTypesList()
        {
            try
            {
                var response = from c in _context.LeaveTypes
                               orderby c.LeaveTypeId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLeaveTypes(int id, LeaveType leaveTypes)
        {
            try
            {
                var res = await _context.LeaveTypes.FirstOrDefaultAsync(m => m.LeaveTypeId == id);
                res.LeaveName = leaveTypes.LeaveName;
                res.LeaveEnabled = leaveTypes.LeaveEnabled;
                res.LeaveForward = leaveTypes.LeaveForward;
                res.LeavePerYear = leaveTypes.LeavePerYear;
                res.LeaveGroup = leaveTypes.LeaveGroup;
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
