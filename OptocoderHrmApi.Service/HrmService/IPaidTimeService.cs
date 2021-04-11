using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IPaidTimeService
    {
        Task<ICollection<PaidTimeOff>> GetPaidTimeList();
        Task<PaidTimeOff> GetPaidTime(int id);
        Task<PaidTimeOff> CreateNewPaidTime(PaidTimeOff paidTime);

        Task<string> DeletePaidTime(int id);
        Task<string> UpdatePaidTime(int id, PaidTimeOff paidTime);
    }

    public class PaidTimeService : IPaidTimeService
    {
        private readonly IPaidTimeRepository _repository;

        public PaidTimeService(IPaidTimeRepository repository)
        {
            _repository = repository;
        }
        public async Task<PaidTimeOff> CreateNewPaidTime(PaidTimeOff paidTime)
        {
            try
            {
                var res = await _repository.CreateNewPaidTimes(paidTime);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePaidTime(int id)
        {
            try
            {
                var res = await _repository.DeletePaidTimes(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PaidTimeOff> GetPaidTime(int id)
        {
            try
            {
                var res = await _repository.GetPaidTimes(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<PaidTimeOff>> GetPaidTimeList()
        {
            try
            {
                var res = await _repository.GetPaidTimesList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdatePaidTime(int id, PaidTimeOff paidTime)
        {
            try
            {
                var res = await _repository.UpdatePaidTimes(id, paidTime);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
