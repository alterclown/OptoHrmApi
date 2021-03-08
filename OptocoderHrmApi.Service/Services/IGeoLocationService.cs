using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
   public interface IGeoLocationService
    {
        Task<List<GeoLocation>> GetGeoLocationList();
        Task<GeoLocation> GetGeoLocation(int id);
        Task<GeoLocation> CreateNewGeoLocation(GeoLocation location);
        Task<string> DeleteGeoLocation(int id);
        Task<string> UpdateGeoLocation(int id, GeoLocation location);
    }
    public class GeoLocationService : IGeoLocationService
    {
        private readonly IGeoLocationRepository _repository;
        public async Task<GeoLocation> CreateNewGeoLocation(GeoLocation location)
        {
            try
            {
                var res = await _repository.CreateNewGeoLocation(location);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteGeoLocation(int id)
        {
            try
            {
                var res = await _repository.DeleteGeoLocation(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<GeoLocation> GetGeoLocation(int id)
        {
            try
            {
                var res = await _repository.GetGeoLocation(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<GeoLocation>> GetGeoLocationList()
        {
            try
            {
                var res = await _repository.GetGeoLocationList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateGeoLocation(int id, GeoLocation location)
        {
            try
            {
                var res = await _repository.UpdateGeoLocation(id, location);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
