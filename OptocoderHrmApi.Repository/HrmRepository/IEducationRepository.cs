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
    public interface IEducationRepository
    {
        Task<ICollection<Education>> GetEducationList();
        Task<Education> GetEducation(int id);
        Task<Education> CreateNewEducation(Education education);

        Task<string> DeleteEducation(int id);
        Task<string> UpdateEducation(int id, Education education);
    }

    public class EducationRepository : IEducationRepository
    {
        private readonly DataContext _context;

        public EducationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Education> CreateNewEducation(Education education)
        {
            try
            {
                _context.Educations.Add(education);
                await _context.SaveChangesAsync();
                return education;
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
                var response = await _context.Educations.FindAsync(id);
                _context.Educations.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.Educations.FirstOrDefaultAsync(m => m.EducationId == id);
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
                var response = from c in _context.Educations
                               orderby c.EducationId descending
                               select c;
                return await response.ToListAsync();
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
                var res = await _context.Educations.FirstOrDefaultAsync(m => m.EducationId == id);
                res.EducationName = education.EducationName;
                res.Description = education.Description;
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
