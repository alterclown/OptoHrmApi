using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IHolidayService
    {
        Task<ICollection<Holiday>> GetHolidayList();
        Task<Holiday> GetHoliday(int id);
        Task<Holiday> CreateNewHoliday(Holiday holiday);

        Task<string> DeleteHoliday(int id);
        Task<string> UpdateHoliday(int id, Holiday holiday);
    }

    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _repository;

        public HolidayService(IHolidayRepository repository)
        {
            _repository = repository;
        }
        public async Task<Holiday> CreateNewHoliday(Holiday holiday)
        {
            try
            {
                var res = await _repository.CreateNewHolidays(holiday);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteHoliday(int id)
        {
            try
            {
                var res = await _repository.DeleteHolidays(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Holiday> GetHoliday(int id)
        {
            try
            {
                var res = await _repository.GetHolidays(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Holiday>> GetHolidayList()
        {
            try
            {
                var res = await _repository.GetHolidaysList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateHoliday(int id, Holiday holiday)
        {
            try
            {
                var res = await _repository.UpdateHolidays(id, holiday);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
