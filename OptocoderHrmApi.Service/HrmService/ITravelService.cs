using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface ITravelService
    {
        Task<ICollection<Travel>> GetTravelList();
        Task<Travel> GetTravel(int id);
        Task<Travel> CreateNewTravel(Travel travel);

        Task<string> DeleteTravel(int id);
        Task<string> UpdateTravel(int id, Travel travel);
    }

    public class TravelService : ITravelService
    {
        private readonly ITravelRepository _repository;

        public TravelService(ITravelRepository repository)
        {
            _repository = repository;
        }
        public async Task<Travel> CreateNewTravel(Travel travel)
        {
            try
            {
                var res = await _repository.CreateNewTravel(travel);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteTravel(int id)
        {
            try
            {
                var res = await _repository.DeleteTravel(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Travel> GetTravel(int id)
        {
            try
            {
                var res = await _repository.GetTravel(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Travel>> GetTravelList()
        {
            try
            {
                var res = await _repository.GetTravelList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateTravel(int id, Travel travel)
        {
            try
            {
                var res = await _repository.UpdateTravel(id, travel);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
