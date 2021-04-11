using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface ILanguageService
    {
        Task<ICollection<Language>> GetLanguageList();
        Task<Language> GetLanguage(int id);
        Task<Language> CreateNewLanguage(Language language);

        Task<string> DeleteLanguage(int id);
        Task<string> UpdateLanguage(int id, Language language);
    }

    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _repository;

        public LanguageService(ILanguageRepository repository)
        {
            _repository = repository;
        }
        public async Task<Language> CreateNewLanguage(Language language)
        {
            try
            {
                var res = await _repository.CreateNewLanguages(language);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLanguage(int id)
        {
            try
            {
                var res = await _repository.DeleteLanguages(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Language> GetLanguage(int id)
        {
            try
            {
                var res = await _repository.GetLanguages(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Language>> GetLanguageList()
        {
            try
            {
                var res = await _repository.GetLanguagesList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLanguage(int id, Language language)
        {
            try
            {
                var res = await _repository.UpdateLanguages(id, language);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
