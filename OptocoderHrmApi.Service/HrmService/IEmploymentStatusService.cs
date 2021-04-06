using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmploymentStatusService
    {
        Task<ICollection<EmploymentStatus>> GetEmploymentStatusList();
        Task<EmploymentStatus> GetEmploymentStatus(int id);
        Task<EmploymentStatus> CreateNewEmploymentStatus(EmploymentStatus employmentStatus);

        Task<string> DeleteEmploymentStatus(int id);
        Task<string> UpdateEmploymentStatus(int id, EmploymentStatus employmentStatus);
    }

    public class EmploymentStatusService : IEmploymentStatusService
    {
        private readonly IEmploymentStatusRepository _repository;

        public EmploymentStatusService(IEmploymentStatusRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmploymentStatus> CreateNewEmploymentStatus(EmploymentStatus employmentStatus)
        {
            try
            {
                var res = await _repository.CreateNewEmploymentStatus(employmentStatus);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmploymentStatus(int id)
        {
            try
            {
                var res = await _repository.DeleteEmploymentStatus(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmploymentStatus> GetEmploymentStatus(int id)
        {
            try
            {
                var res = await _repository.GetEmploymentStatus(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmploymentStatus>> GetEmploymentStatusList()
        {
            try
            {
                var res = await _repository.GetEmploymentStatusList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmploymentStatus(int id, EmploymentStatus employmentStatus)
        {
            try
            {
                var res = await _repository.UpdateEmploymentStatus(id,employmentStatus);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
