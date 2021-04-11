using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IMonitorAttendanceService
    {
        Task<ICollection<MonitorAttendance>> GetMonitorAttendanceList();
        Task<MonitorAttendance> GetMonitorAttendance(int id);
        Task<MonitorAttendance> CreateNewMonitorAttendance(MonitorAttendance monitorAttendance);

        Task<string> DeleteMonitorAttendance(int id);
        Task<string> UpdateMonitorAttendance(int id, MonitorAttendance monitorAttendance);
    }

    public class MonitorAttendanceService : IMonitorAttendanceService
    {
        private readonly IMonitorAttendanceRepository _repository;

        public MonitorAttendanceService(IMonitorAttendanceRepository repository)
        {
            _repository = repository;
        }
        public async Task<MonitorAttendance> CreateNewMonitorAttendance(MonitorAttendance monitorAttendance)
        {
            try
            {
                var res = await _repository.CreateNewMonitorAttendances(monitorAttendance);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteMonitorAttendance(int id)
        {
            try
            {
                var res = await _repository.DeleteMonitorAttendances(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<MonitorAttendance> GetMonitorAttendance(int id)
        {
            try
            {
                var res = await _repository.GetMonitorAttendances(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<MonitorAttendance>> GetMonitorAttendanceList()
        {
            try
            {
                var res = await _repository.GetMonitorAttendancesList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateMonitorAttendance(int id, MonitorAttendance monitorAttendance)
        {
            try
            {
                var res = await _repository.UpdateMonitorAttendances(id, monitorAttendance);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
