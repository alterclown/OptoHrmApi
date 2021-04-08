using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OptocoderHrmApi.Data.Entities;
using System.Threading.Tasks;
using OptocoderHrmApi.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IJobTitleRepository
    {
        Task<ICollection<JobTitle>> GetJobTitlesList();
        Task<JobTitle> GetJobTitles(int id);
        Task<JobTitle> CreateNewJobTitles(JobTitle jobTitle);

        Task<string> DeleteJobTitles(int id);
        Task<string> UpdateJobTitles(int id, JobTitle jobTitle);
    }

    public class JobTitleRepository : IJobTitleRepository
    {
        private readonly DataContext _context;

        public JobTitleRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<JobTitle> CreateNewJobTitles(JobTitle jobTitle)
        {
            try
            {
                _context.JobTitles.Add(jobTitle);
                await _context.SaveChangesAsync();
                return jobTitle;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteJobTitles(int id)
        {
            try
            {
                var response = await _context.JobTitles.FindAsync(id);
                _context.JobTitles.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<JobTitle> GetJobTitles(int id)
        {
            try
            {
                var res = await _context.JobTitles.FirstOrDefaultAsync(m => m.JobTitleId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<JobTitle>> GetJobTitlesList()
        {
            try
            {
                var response = from c in _context.JobTitles
                               orderby c.JobTitleId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateJobTitles(int id, JobTitle jobTitle)
        {
            try
            {
                var res = await _context.JobTitles.FirstOrDefaultAsync(m => m.JobTitleId == id);
                res.JobTitleCode = jobTitle.JobTitleCode;
                res.JobTitle1 = jobTitle.JobTitle1;
                res.Description = jobTitle.Description;
                res.Specification = jobTitle.Specification;
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
