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
    public interface IMonitorAttendanceRepository
    {
        Task<ICollection<MonitorAttendance>> GetMonitorAttendancesList();
        Task<MonitorAttendance> GetMonitorAttendances(int id);
        Task<MonitorAttendance> CreateNewMonitorAttendances(MonitorAttendance monitorAttendances);

        Task<string> DeleteMonitorAttendances(int id);
        Task<string> UpdateMonitorAttendances(int id, MonitorAttendance monitorAttendances);
    }

    public class MonitorAttendanceRepository : IMonitorAttendanceRepository
    {
        private readonly DataContext _context;

        public MonitorAttendanceRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<MonitorAttendance> CreateNewMonitorAttendances(MonitorAttendance monitorAttendances)
        {
            try
            {
                _context.MonitorAttendances.Add(monitorAttendances);
                await _context.SaveChangesAsync();
                return monitorAttendances;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteMonitorAttendances(int id)
        {
            try
            {
                var response = await _context.MonitorAttendances.FindAsync(id);
                _context.MonitorAttendances.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<MonitorAttendance> GetMonitorAttendances(int id)
        {
            try
            {
                var res = await _context.MonitorAttendances.FirstOrDefaultAsync(m => m.MonitorAttendanceId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<MonitorAttendance>> GetMonitorAttendancesList()
        {
            try
            {
                var response = from c in _context.MonitorAttendances
                               orderby c.MonitorAttendanceId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateMonitorAttendances(int id, MonitorAttendance monitorAttendances)
        {
            try
            {
                var res = await _context.MonitorAttendances.FirstOrDefaultAsync(m => m.MonitorAttendanceId == id);
                res.EmployeeName = monitorAttendances.EmployeeName;
                res.TimeIn = monitorAttendances.TimeIn;
                res.TimeOut = monitorAttendances.TimeOut;
                res.Note = monitorAttendances.Note;
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
