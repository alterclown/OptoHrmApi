using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IPersonalDocumentService
    {
        Task<ICollection<PersonalDocument>> GetPersonalDocumentList();
        Task<PersonalDocument> GetPersonalDocument(int id);
        Task<PersonalDocument> CreateNewPersonalDocument(PersonalDocument personalDocument);

        Task<string> DeletePersonalDocument(int id);
        Task<string> UpdatePersonalDocument(int id, PersonalDocument personalDocument);
    }

    public class PersonalDocumentService : IPersonalDocumentService
    {
        private readonly IPersonalDocumentRepository _repository;

        public PersonalDocumentService(IPersonalDocumentRepository repository)
        {
            _repository = repository;
        }
        public async Task<PersonalDocument> CreateNewPersonalDocument(PersonalDocument personalDocument)
        {
            try
            {
                var res = await _repository.CreateNewPersonalDocument(personalDocument);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePersonalDocument(int id)
        {
            try
            {
                var res = await _repository.DeletePersonalDocument(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PersonalDocument> GetPersonalDocument(int id)
        {
            try
            {
                var res = await _repository.GetPersonalDocument(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<PersonalDocument>> GetPersonalDocumentList()
        {
            try
            {
                var res = await _repository.GetPersonalDocumentList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdatePersonalDocument(int id, PersonalDocument personalDocument)
        {
            try
            {
                var res = await _repository.UpdatePersonalDocument(id, personalDocument);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
