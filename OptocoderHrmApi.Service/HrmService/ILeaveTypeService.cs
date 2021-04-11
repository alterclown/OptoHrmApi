using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface ILeaveTypeService
    {
        Task<ICollection<LeaveType>> GetLeaveTypeList();
        Task<LeaveType> GetLeaveType(int id);
        Task<LeaveType> CreateNewLeaveType(LeaveType leaveType);

        Task<string> DeleteLeaveType(int id);
        Task<string> UpdateLeaveType(int id, LeaveType leaveType);
    }

    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ILeaveTypeRepository _repository;

        public LeaveTypeService(ILeaveTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<LeaveType> CreateNewLeaveType(LeaveType leaveType)
        {
            try
            {
                var res = await _repository.CreateNewLeaveTypes(leaveType);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLeaveType(int id)
        {
            try
            {
                var res = await _repository.DeleteLeaveTypes(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LeaveType> GetLeaveType(int id)
        {
            try
            {
                var res = await _repository.GetLeaveTypes(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<LeaveType>> GetLeaveTypeList()
        {
            try
            {
                var res = await _repository.GetLeaveTypesList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLeaveType(int id, LeaveType leaveType)
        {
            try
            {
                var res = await _repository.UpdateLeaveTypes(id, leaveType);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
