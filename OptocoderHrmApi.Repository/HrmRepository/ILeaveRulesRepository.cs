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
    public interface ILeaveRulesRepository
    {
        Task<ICollection<LeaveRule>> GetLeaveRulesList();
        Task<LeaveRule> GetLeaveRules(int id);
        Task<LeaveRule> CreateNewLeaveRules(LeaveRule leaveRules);

        Task<string> DeleteLeaveRules(int id);
        Task<string> UpdateLeaveRules(int id, LeaveRule leaveRules);
    }

    public class LeaveRulesRepository : ILeaveRulesRepository
    {
        private readonly DataContext _context;

        public LeaveRulesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<LeaveRule> CreateNewLeaveRules(LeaveRule leaveRules)
        {
            try
            {
                _context.LeaveRules.Add(leaveRules);
                await _context.SaveChangesAsync();
                return leaveRules;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLeaveRules(int id)
        {
            try
            {
                var response = await _context.LeaveRules.FindAsync(id);
                _context.LeaveRules.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LeaveRule> GetLeaveRules(int id)
        {
            try
            {
                var res = await _context.LeaveRules.FirstOrDefaultAsync(m => m.LeaveRulesId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<LeaveRule>> GetLeaveRulesList()
        {
            try
            {
                var response = from c in _context.LeaveRules
                               orderby c.LeaveRulesId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLeaveRules(int id, LeaveRule leaveRules)
        {
            try
            {
                var res = await _context.LeaveRules.FirstOrDefaultAsync(m => m.LeaveRulesId == id);
                res.LeaveGroup = leaveRules.LeaveGroup;
                res.JobTitle = leaveRules.JobTitle;
                res.EmploymentStatus = leaveRules.EmploymentStatus;
                res.EmployeeName = leaveRules.EmployeeName;
                res.Experience = leaveRules.Experience;
                res.LeavePerYear = leaveRules.LeavePerYear;
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
