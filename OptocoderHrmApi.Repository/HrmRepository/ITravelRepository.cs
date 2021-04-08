using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface ITravelRepository
    {
        Task<ICollection<Travel>> GetTravelList();
        Task<Travel> GetTravel(int id);
        Task<Travel> CreateNewTravel(Travel travel);

        Task<string> DeleteTravel(int id);
        Task<string> UpdateTravel(int id, Travel travel);
    }
    public class TravelRepository : ITravelRepository
    {
        private readonly DataContext _context;

        public TravelRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Travel> CreateNewTravel(Travel travel)
        {
            try
            {
                _context.Travels.Add(travel);
                await _context.SaveChangesAsync();
                return travel;
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
                var response = await _context.Travels.FindAsync(id);
                _context.Travels.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.Travels.FirstOrDefaultAsync(m => m.TravelId == id);
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
                var response = from c in _context.Travels
                               orderby c.TravelId descending
                               select c;
                return await response.ToListAsync();
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
                var res = await _context.Travels.FirstOrDefaultAsync(m => m.TravelId == id);
                res.MeansofTransportation = travel.MeansofTransportation;
                res.PurposeofTravel = travel.PurposeofTravel;
                res.TravelFrom = travel.TravelFrom;
                res.TravelTo = travel.TravelTo;
                res.TravelDate = travel.TravelDate;
                res.ReturnDate = travel.ReturnDate;
                res.Notes = travel.Notes;
                res.Currency = travel.Currency;
                res.TotalFundingProposed = travel.TotalFundingProposed;
                res.Attachment = travel.Attachment;
                _context.Update(res);
                await _context.SaveChangesAsync();
                return "Updated Record";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
