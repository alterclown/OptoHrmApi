using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IOverTimeRequestService
    {
        Task<ICollection<OverTimeRequest>> GetOverTimeRequestList();
        Task<OverTimeRequest> GetOverTimeRequest(int id);
        Task<OverTimeRequest> CreateNewOverTimeRequest(OverTimeRequest overTimeRequest);

        Task<string> DeleteOverTimeRequest(int id);
        Task<string> UpdateOverTimeRequest(int id, OverTimeRequest overTimeRequest);
    }

    public class OverTimeRequestService : IOverTimeRequestService
    {
        private readonly IOverTimeRequestRepository _repository;

        public OverTimeRequestService(IOverTimeRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task<OverTimeRequest> CreateNewOverTimeRequest(OverTimeRequest overTimeRequest)
        {
            try
            {
                var res = await _repository.CreateNewOverTimeRequests(overTimeRequest);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteOverTimeRequest(int id)
        {
            try
            {
                var res = await _repository.DeleteOverTimeRequests(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<OverTimeRequest> GetOverTimeRequest(int id)
        {
            try
            {
                var res = await _repository.GetOverTimeRequests(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<OverTimeRequest>> GetOverTimeRequestList()
        {
            try
            {
                var res = await _repository.GetOverTimeRequestsList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateOverTimeRequest(int id, OverTimeRequest overTimeRequest)
        {
            try
            {
                var res = await _repository.UpdateOverTimeRequests(id, overTimeRequest);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
