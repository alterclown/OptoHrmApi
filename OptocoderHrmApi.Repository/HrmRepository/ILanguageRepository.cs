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
    public interface ILanguageRepository
    {
        Task<ICollection<Language>> GetLanguagesList();
        Task<Language> GetLanguages(int id);
        Task<Language> CreateNewLanguages(Language language);

        Task<string> DeleteLanguages(int id);
        Task<string> UpdateLanguages(int id, Language language);
    }

    public class LanguageRepository : ILanguageRepository
    {
        private readonly DataContext _context;

        public LanguageRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Language> CreateNewLanguages(Language language)
        {
            try
            {
                _context.Languages.Add(language);
                await _context.SaveChangesAsync();
                return language;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLanguages(int id)
        {
            try
            {
                var response = await _context.Languages.FindAsync(id);
                _context.Languages.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Language> GetLanguages(int id)
        {
            try
            {
                var res = await _context.Languages.FirstOrDefaultAsync(m => m.LanguageId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Language>> GetLanguagesList()
        {
            try
            {
                var response = from c in _context.Languages
                               orderby c.LanguageId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLanguages(int id, Language language)
        {
            try
            {
                var res = await _context.Languages.FirstOrDefaultAsync(m => m.LanguageId == id);
                res.LanguageName = language.LanguageName;
                res.Description = language.Description;
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
