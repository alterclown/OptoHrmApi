using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Data.Paging;
using OptocoderHrmApi.Data.ViewModels;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IAttendanceService
    {
        Task<ICollection<Attendance>> GetAttendanceList(Paging paging);
        Task<Attendance> GetAttendance(int id);
        Task<Attendance> CreateNewAttendance(Attendance attendance);
        Task<int> GetAttendanceCount();
        Task<string> DeleteAttendance(int id);
        Task<string> UpdateAttendance(int id, Attendance attendance);
        Task<ICollection<Attendance>> SortAttendance(string sortOrder);
        Task<IEnumerable<Attendance>> GetAttendanceListByAttendanceNote();
    }

    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repository;

        public AttendanceService(IAttendanceRepository repository)
        {
            _repository = repository;
        }
        public async Task<Attendance> CreateNewAttendance(Attendance attendance)
        {
            try
            {
                var res = await _repository.CreateNewAttendance(attendance);
                return res;
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
                var res = await _repository.DeleteAttendance(id);
                return res;
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
                var res = await _repository.GetAttendance(id);
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
                var res = await _repository.GetAttendanceCount();
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
                var res = await _repository.GetAttendanceList(paging);
                return res;
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
                var res = await _repository.GetAttendanceListByAttendanceNote();
                return res;
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
                var res = await _repository.SortAttendance(sortOrder);
                return res;
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
                var res = await _repository.UpdateAttendance(id, attendance);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
