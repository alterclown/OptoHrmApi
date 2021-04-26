using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.Paging;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IAttendanceRepository
    {
        Task<ICollection<Attendance>> GetAttendanceList(Paging paging);
        Task<Attendance> GetAttendance(int id);
        Task<Attendance> CreateNewAttendance(Attendance attendance);

        Task<string> DeleteAttendance(int id);
        Task<string> UpdateAttendance(int id, Attendance attendance);
    }

    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly DataContext _context;

        public AttendanceRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Attendance> CreateNewAttendance(Attendance attendance)
        {
            try
            {
                _context.Attendances.Add(attendance);
                await _context.SaveChangesAsync();
                return attendance;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteAttendance(int id)
        {
            try
            {
                var response = await _context.Attendances.FindAsync(id);
                _context.Attendances.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Attendance> GetAttendance(int id)
        {
            try
            {
                var res = await _context.Attendances.FirstOrDefaultAsync(m => m.AttendanceId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Attendance>> GetAttendanceList(Paging paging)
        {
            try
            {
                int CurrentPage = paging.pageNumber;
                int PageSize = paging.pageSize;
                var items = await _context.Attendances.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToListAsync();
                return items;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateAttendance(int id, Attendance attendance)
        {
            try
            {
                var res = await _context.Attendances.FirstOrDefaultAsync(m => m.AttendanceId == id);
                res.TimeIn = attendance.TimeIn;
                res.TimeOut = attendance.TimeOut;
                res.Note = attendance.Note;
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
