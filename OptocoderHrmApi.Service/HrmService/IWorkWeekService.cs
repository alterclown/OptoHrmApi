using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IWorkWeekService
    {
        Task<ICollection<WorkWeek>> GetWorkWeekList();
        Task<WorkWeek> GetWorkWeek(int id);
        Task<WorkWeek> CreateNewWorkWeek(WorkWeek WorkWeek);

        Task<string> DeleteWorkWeek(int id);
        Task<string> UpdateWorkWeek(int id, WorkWeek WorkWeek);
    }

    public class WorkWeekService : IWorkWeekService
    {
        private readonly IWorkWeekRepository _repository;

        public WorkWeekService(IWorkWeekRepository repository)
        {
            _repository = repository;
        }
        public async Task<WorkWeek> CreateNewWorkWeek(WorkWeek WorkWeek)
        {
            try
            {
                var res = await _repository.CreateNewWorkWeek(WorkWeek);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteWorkWeek(int id)
        {
            try
            {
                var res = await _repository.DeleteWorkWeek(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<WorkWeek> GetWorkWeek(int id)
        {
            try
            {
                var res = await _repository.GetWorkWeek(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<WorkWeek>> GetWorkWeekList()
        {
            try
            {
                var res = await _repository.GetWorkWeekList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateWorkWeek(int id, WorkWeek WorkWeek)
        {
            try
            {
                var res = await _repository.UpdateWorkWeek(id, WorkWeek);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
