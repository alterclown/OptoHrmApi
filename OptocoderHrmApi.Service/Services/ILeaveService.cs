using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface ILeaveService
    {
        Task<List<Leave>> GetLeaveList();
        Task<Leave> GetLeave(int id);
        Task<Leave> CreateNewLeave(Leave leave);
        Task<string> DeleteLeave(int id);
        Task<string> UpdateLeave(int id, Leave leave);
    }
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _repository;

        public LeaveService(ILeaveRepository repository)
        {
            _repository = repository;
        }
        public async Task<Leave> CreateNewLeave(Leave leave)
        {
            try
            {
                var res = await _repository.CreateNewLeave(leave);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLeave(int id)
        {
            try
            {
                var res = await _repository.DeleteLeave(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Leave> GetLeave(int id)
        {
            try
            {
                var res = await _repository.GetLeave(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Leave>> GetLeaveList()
        {
            try
            {
                var res = await _repository.GetLeaveList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLeave(int id, Leave leave)
        {
            try
            {
                var res = await _repository.UpdateLeave(id,leave);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
