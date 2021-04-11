using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmployeeLeaveService
    {
        Task<ICollection<EmployeeLeave>> GetEmployeeLeaveList();
        Task<EmployeeLeave> GetEmployeeLeave(int id);
        Task<EmployeeLeave> CreateNewEmployeeLeave(EmployeeLeave EmployeeLeave);

        Task<string> DeleteEmployeeLeave(int id);
        Task<string> UpdateEmployeeLeave(int id, EmployeeLeave EmployeeLeave);
    }

    public class EmployeeLeaveService : IEmployeeLeaveService
    {
        private readonly IEmployeeLeaveRepository _repository;

        public EmployeeLeaveService(IEmployeeLeaveRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeLeave> CreateNewEmployeeLeave(EmployeeLeave EmployeeLeave)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeLeave(EmployeeLeave);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeLeave(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeLeave(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeLeave> GetEmployeeLeave(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeLeave(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeLeave>> GetEmployeeLeaveList()
        {
            try
            {
                var res = await _repository.GetEmployeeLeaveList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeLeave(int id, EmployeeLeave EmployeeLeave)
        {
            try
            {
                var res = await _repository.UpdateEmployeeLeave(id, EmployeeLeave);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
