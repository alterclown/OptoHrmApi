﻿using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IAttendanceService
    {
        Task<ICollection<Attendance>> GetAttendanceList();
        Task<Attendance> GetAttendance(int id);
        Task<Attendance> CreateNewAttendance(Attendance attendance);

        Task<string> DeleteAttendance(int id);
        Task<string> UpdateAttendance(int id, Attendance attendance);
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

        public async Task<ICollection<Attendance>> GetAttendanceList()
        {
            try
            {
                var res = await _repository.GetAttendanceList();
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