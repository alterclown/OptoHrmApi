using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface ILeavePeriodService
    {
        Task<ICollection<LeavePeriod>> GetLeavePeriodList();
        Task<LeavePeriod> GetLeavePeriod(int id);
        Task<LeavePeriod> CreateNewLeavePeriod(LeavePeriod leavePeriod);

        Task<string> DeleteLeavePeriod(int id);
        Task<string> UpdateLeavePeriod(int id, LeavePeriod leavePeriod);
    }

    public class LeavePeriodService : ILeavePeriodService
    {
        private readonly ILeavePeriodRepository _repository;

        public LeavePeriodService(ILeavePeriodRepository repository)
        {
            _repository = repository;
        }
        public async Task<LeavePeriod> CreateNewLeavePeriod(LeavePeriod leavePeriod)
        {
            try
            {
                var res = await _repository.CreateNewLeavePeriods(leavePeriod);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLeavePeriod(int id)
        {
            try
            {
                var res = await _repository.DeleteLeavePeriods(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LeavePeriod> GetLeavePeriod(int id)
        {
            try
            {
                var res = await _repository.GetLeavePeriods(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<LeavePeriod>> GetLeavePeriodList()
        {
            try
            {
                var res = await _repository.GetLeavePeriodsList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLeavePeriod(int id, LeavePeriod leavePeriod)
        {
            try
            {
                var res = await _repository.UpdateLeavePeriods(id, leavePeriod);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
