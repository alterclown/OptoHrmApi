using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{

    public interface IJobTitleService
    {
        Task<ICollection<JobTitle>> GetJobTitleList();
        Task<JobTitle> GetJobTitle(int id);
        Task<JobTitle> CreateNewJobTitle(JobTitle jobTitle);

        Task<string> DeleteJobTitle(int id);
        Task<string> UpdateJobTitle(int id, JobTitle jobTitle);
    }

    public class JobTitleService : IJobTitleService
    {
        private readonly IJobTitleRepository _repository;

        public JobTitleService(IJobTitleRepository repository)
        {
            _repository = repository;
        }
        public async Task<JobTitle> CreateNewJobTitle(JobTitle jobTitle)
        {
            try
            {
                var res = await _repository.CreateNewJobTitles(jobTitle);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteJobTitle(int id)
        {
            try
            {
                var res = await _repository.DeleteJobTitles(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<JobTitle> GetJobTitle(int id)
        {
            try
            {
                var res = await _repository.GetJobTitles(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<JobTitle>> GetJobTitleList()
        {
            try
            {
                var res = await _repository.GetJobTitlesList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateJobTitle(int id, JobTitle jobTitle)
        {
            try
            {
                var res = await _repository.UpdateJobTitles(id, jobTitle);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
