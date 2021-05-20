using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.Paging;
using OptocoderHrmApi.Data.ViewModels;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IAttendanceRepository
    {
        Task<ICollection<Attendance>> GetAttendanceList(Paging paging);
        Task<Attendance> GetAttendance(int id);
        Task<int> GetAttendanceCount();
        Task<Attendance> CreateNewAttendance(Attendance attendance);

        Task<string> DeleteAttendance(int id);
        Task<string> UpdateAttendance(int id, Attendance attendance);
        Task<ICollection<Attendance>> SortAttendance(string sortOrder);
        Task<IEnumerable<Attendance>> GetAttendanceListByAttendanceNote();
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

        public async Task<int> GetAttendanceCount()
        {
            try
            {
                var res = await _context.Attendances.CountAsync();
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
                var validFilter = new Paging(paging.PageNumber, paging.PageSize);
                var pagedData = await _context.Attendances
                   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                   .Take(validFilter.PageSize)
                   .ToListAsync();
                return pagedData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Attendance>> GetAttendanceListByAttendanceNote()
        {
            try
            {
                var attendanceList = await _context.Attendances.ToListAsync();
                var result =  _context.Attendances.Select(test=> new Attendance() {
                    AttendanceId = test.AttendanceId,
                    Note = test.Note
                });
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Attendance>> SortAttendance(string sortOrder)
        {
            try
            {
                var res = from s in _context.Attendances
                               select s;
                switch (sortOrder)
                {
                    case "name_desc":
                        res = res.OrderByDescending(s => s.AttendanceId);
                        break;
                    case "Date":
                        res = res.OrderBy(s => s.Note);
                        break;
                    case "date_desc":
                        res = res.OrderByDescending(s => s.TimeOut);
                        break;
                    default:
                        res = res.OrderBy(s => s.AttendanceId);
                        break;
                }
                return await res.AsNoTracking().ToListAsync();
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
