using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEducationService
    {
        Task<ICollection<Education>> GetEducationList();
        Task<Education> GetEducation(int id);
        Task<Education> CreateNewEducation(Education education);

        Task<string> DeleteEducation(int id);
        Task<string> UpdateEducation(int id, Education education);
    }

    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _repository;

        public EducationService(IEducationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Education> CreateNewEducation(Education education)
        {
            try
            {
                var res = await _repository.CreateNewEducation(education);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEducation(int id)
        {
            try
            {
                var res = await _repository.DeleteEducation(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Education> GetEducation(int id)
        {
            try
            {
                var res = await _repository.GetEducation(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Education>> GetEducationList()
        {
            try
            {
                var res = await _repository.GetEducationList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEducation(int id, Education education)
        {
            try
            {
                var res = await _repository.UpdateEducation(id,education);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
