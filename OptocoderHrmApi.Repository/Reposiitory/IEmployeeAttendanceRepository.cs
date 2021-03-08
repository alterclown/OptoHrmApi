using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface IEmployeeAttendanceRepository
    {
        Task<List<EmployeeAttendance>> GetEmployeeAttendanceList();
        Task<EmployeeAttendance> GetEmployeeAttendance(int id);
        Task<EmployeeAttendance> CreateNewEmployeeAttendance(EmployeeAttendance attendance);
        Task<string> DeleteEmployeeAttendance(int id);
        Task<string> UpdateEmployeeAttendance(int id, EmployeeAttendance attendance);
    }

    public class EmployeeAttendanceRepository : IEmployeeAttendanceRepository
    {
        private readonly DataContext _context;

        public EmployeeAttendanceRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeAttendance> CreateNewEmployeeAttendance(EmployeeAttendance attendance)
        {
            try
            {
                _context.EmployeeAttendances.Add(attendance);
                await _context.SaveChangesAsync();
                return attendance;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeAttendance(int id)
        {
            try
            {
                var response = await _context.EmployeeAttendances.FindAsync(id);
                _context.EmployeeAttendances.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeAttendance> GetEmployeeAttendance(int id)
        {
            try
            {
                var res = await _context.EmployeeAttendances.FirstOrDefaultAsync(m => m.EmployeeAttendanceId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<EmployeeAttendance>> GetEmployeeAttendanceList()
        {
            try
            {
                var response = from c in _context.EmployeeAttendances
                               orderby c.EmployeeAttendanceId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeAttendance(int id, EmployeeAttendance attendance)
        {
            try
            {
                var response = await _context.EmployeeAttendances.FirstOrDefaultAsync(m => m.EmployeeAttendanceId == id);
                response.EmployeeId = attendance.EmployeeId;
                response.TimeIn = attendance.TimeIn;
                response.TimeOut = attendance.TimeOut;
                response.Count = attendance.Count;
                response.Remarks = attendance.Remarks;
                response.CompanyId = attendance.CompanyId;
                response.UserId = attendance.UserId;
                _context.EmployeeAttendances.Update(response);
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
