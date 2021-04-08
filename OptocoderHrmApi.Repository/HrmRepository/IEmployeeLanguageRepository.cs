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
    public interface IEmployeeLanguageRepository
    {
        Task<ICollection<EmployeeLanguage>> GetEmployeeLanguageList();
        Task<EmployeeLanguage> GetEmployeeLanguage(int id);
        Task<EmployeeLanguage> CreateNewEmployeeLanguage(EmployeeLanguage employeeLanguage);

        Task<string> DeleteEmployeeLanguage(int id);
        Task<string> UpdateEmployeeLanguage(int id, EmployeeLanguage employeeLanguage);
    }

    public class EmployeeLanguageRepository : IEmployeeLanguageRepository
    {
        private readonly DataContext _context;

        public EmployeeLanguageRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeLanguage> CreateNewEmployeeLanguage(EmployeeLanguage employeeLanguage)
        {
            try
            {
                _context.EmployeeLanguages.Add(employeeLanguage);
                await _context.SaveChangesAsync();
                return employeeLanguage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeLanguage(int id)
        {
            try
            {
                var response = await _context.EmployeeLanguages.FindAsync(id);
                _context.EmployeeLanguages.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeLanguage> GetEmployeeLanguage(int id)
        {
            try
            {
                var res = await _context.EmployeeLanguages.FirstOrDefaultAsync(m => m.EmployeeLanguageId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeLanguage>> GetEmployeeLanguageList()
        {
            try
            {
                var response = from c in _context.EmployeeLanguages
                               orderby c.EmployeeLanguageId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeLanguage(int id, EmployeeLanguage employeeLanguage)
        {
            try
            {
                var res = await _context.EmployeeLanguages.FirstOrDefaultAsync(m => m.EmployeeLanguageId == id);
                res.EmployeeName = employeeLanguage.EmployeeName;
                res.Language = employeeLanguage.Language;
                res.Reading = employeeLanguage.Reading;
                res.Speaking = employeeLanguage.Speaking;
                res.Writing = employeeLanguage.Writing;
                res.Listening = employeeLanguage.Listening;
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
