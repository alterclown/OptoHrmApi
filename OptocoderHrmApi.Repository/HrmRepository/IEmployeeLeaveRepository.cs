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
    public interface IEmployeeLeaveRepository
    {
        Task<ICollection<EmployeeLeave>> GetEmployeeLeaveList();
        Task<EmployeeLeave> GetEmployeeLeave(int id);
        Task<EmployeeLeave> CreateNewEmployeeLeave(EmployeeLeave employeeLeave);

        Task<string> DeleteEmployeeLeave(int id);
        Task<string> UpdateEmployeeLeave(int id, EmployeeLeave employeeLeave);
    }

    public class EmployeeLeaveRepository : IEmployeeLeaveRepository
    {
        private readonly DataContext _context;

        public EmployeeLeaveRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeLeave> CreateNewEmployeeLeave(EmployeeLeave employeeLeave)
        {
            try
            {
                _context.EmployeeLeaves.Add(employeeLeave);
                await _context.SaveChangesAsync();
                return employeeLeave;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeLeave(int id)
        {
            try
            {
                var response = await _context.EmployeeLeaves.FindAsync(id);
                _context.EmployeeLeaves.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeLeave> GetEmployeeLeave(int id)
        {
            try
            {
                var res = await _context.EmployeeLeaves.FirstOrDefaultAsync(m => m.EmployeeLeaveId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeLeave>> GetEmployeeLeaveList()
        {
            try
            {
                var response = from c in _context.EmployeeLeaves
                               orderby c.EmployeeLeaveId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeLeave(int id, EmployeeLeave employeeLeave)
        {
            try
            {
                var res = await _context.EmployeeLeaves.FirstOrDefaultAsync(m => m.EmployeeLeaveId == id);
                res.EmployeeName = employeeLeave.EmployeeName;
                res.LeaveType = employeeLeave.LeaveType;
                res.LeaveStartDate = employeeLeave.LeaveStartDate;
                res.Reason = employeeLeave.Reason;
                res.Attachment = employeeLeave.Attachment;
                res.Status = employeeLeave.Status;
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
