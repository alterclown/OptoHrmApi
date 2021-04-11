using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IOverTimeService
    {
        Task<ICollection<OverTime>> GetOverTimeList();
        Task<OverTime> GetOverTime(int id);
        Task<OverTime> CreateNewOverTime(OverTime overTime);

        Task<string> DeleteOverTime(int id);
        Task<string> UpdateOverTime(int id, OverTime overTime);
    }

    public class OverTimeService : IOverTimeService
    {
        private readonly IOverTimeRepository _repository;

        public OverTimeService(IOverTimeRepository repository)
        {
            _repository = repository;
        }
        public async Task<OverTime> CreateNewOverTime(OverTime overTime)
        {
            try
            {
                var res = await _repository.CreateNewOverTimes(overTime);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteOverTime(int id)
        {
            try
            {
                var res = await _repository.DeleteOverTimes(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<OverTime> GetOverTime(int id)
        {
            try
            {
                var res = await _repository.GetOverTimes(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<OverTime>> GetOverTimeList()
        {
            try
            {
                var res = await _repository.GetOverTimesList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateOverTime(int id, OverTime overTime)
        {
            try
            {
                var res = await _repository.UpdateOverTimes(id, overTime);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
