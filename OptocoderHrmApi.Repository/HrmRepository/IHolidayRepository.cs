using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IHolidayRepository
    {
        Task<ICollection<Holiday>> GetHolidaysList();
        Task<Holiday> GetHolidays(int id);
        Task<Holiday> CreateNewHolidays(Holiday holiday);

        Task<string> DeleteHolidays(int id);
        Task<string> UpdateHolidays(int id, Holiday holiday);
    }

    public class HolidayRepository : IHolidayRepository
    {
        private readonly DataContext _context;

        public HolidayRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Holiday> CreateNewHolidays(Holiday holiday)
        {
            try
            {
                _context.Holidays.Add(holiday);
                await _context.SaveChangesAsync();
                return holiday;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteHolidays(int id)
        {
            try
            {
                var response = await _context.Holidays.FindAsync(id);
                _context.Holidays.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Holiday> GetHolidays(int id)
        {
            try
            {
                var res = await _context.Holidays.FirstOrDefaultAsync(m => m.HolidaysId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Holiday>> GetHolidaysList()
        {
            try
            {
                var response = from c in _context.Holidays
                               orderby c.HolidaysId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateHolidays(int id, Holiday holiday)
        {
            try
            {
                var res = await _context.Holidays.FirstOrDefaultAsync(m => m.HolidaysId == id);
                res.Name = holiday.Name;
                res.Date = holiday.Date;
                res.Status = holiday.Status;
                res.Country = holiday.Country;
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
