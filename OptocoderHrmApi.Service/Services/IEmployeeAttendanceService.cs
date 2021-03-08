using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface IEmployeeAttendanceService
    {
        Task<List<EmployeeAttendance>> GetEmployeeAttendanceList();
        Task<EmployeeAttendance> GetEmployeeAttendance(int id);
        Task<EmployeeAttendance> CreateNewEmployeeAttendance(EmployeeAttendance attendance);
        Task<string> DeleteEmployeeAttendance(int id);
        Task<string> UpdateEmployeeAttendance(int id, EmployeeAttendance attendance);
    }

    public class EmployeeAttendanceService : IEmployeeAttendanceService
    {
        private readonly IEmployeeAttendanceRepository _repository;

        public EmployeeAttendanceService(IEmployeeAttendanceRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeAttendance> CreateNewEmployeeAttendance(EmployeeAttendance attendance)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeAttendance(attendance);
                return res;
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
                var res = await _repository.DeleteEmployeeAttendance(id);
                return res;
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
                var res = await _repository.GetEmployeeAttendance(id);
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
                var res = await _repository.GetEmployeeAttendanceList();
                return res;
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
                var res = await _repository.UpdateEmployeeAttendance(id,attendance);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
