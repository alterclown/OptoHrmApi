using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface IGeoLocationRepository
    {
        Task<List<GeoLocation>> GetGeoLocationList();
        Task<GeoLocation> GetGeoLocation(int id);
        Task<GeoLocation> CreateNewGeoLocation(GeoLocation location);
        Task<string> DeleteGeoLocation(int id);
        Task<string> UpdateGeoLocation(int id, GeoLocation location);
    }
    public class GeoLocationRepository : IGeoLocationRepository
    {
        private readonly DataContext _context;

        public GeoLocationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<GeoLocation> CreateNewGeoLocation(GeoLocation location)
        {
            try
            {
                _context.GeoLocations.Add(location);
                await _context.SaveChangesAsync();
                return location;
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
                var response = await _context.GeoLocations.FindAsync(id);
                _context.GeoLocations.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.GeoLocations.FirstOrDefaultAsync(m => m.GeoLocationId == id);
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
                var response = from c in _context.GeoLocations
                               orderby c.GeoLocationId descending
                               select c;
                return await response.ToListAsync();
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
                var response = await _context.GeoLocations.FirstOrDefaultAsync(m => m.GeoLocationId == id);
                _context.GeoLocations.Update(response);
                await _context.SaveChangesAsync();
                return "Updated SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
