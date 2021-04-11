using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using OptocoderHrmApi.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IWorkWeekRepository
    {
        Task<ICollection<WorkWeek>> GetWorkWeekList();
        Task<WorkWeek> GetWorkWeek(int id);
        Task<WorkWeek> CreateNewWorkWeek(WorkWeek workWeek);

        Task<string> DeleteWorkWeek(int id);
        Task<string> UpdateWorkWeek(int id, WorkWeek workWeek);
    }

    public class WorkWeekRepository : IWorkWeekRepository
    {
        private readonly DataContext _context;

        public WorkWeekRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<WorkWeek> CreateNewWorkWeek(WorkWeek workWeek)
        {
            try
            {
                _context.WorkWeeks.Add(workWeek);
                await _context.SaveChangesAsync();
                return workWeek;
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
                var response = await _context.WorkWeeks.FindAsync(id);
                _context.WorkWeeks.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.WorkWeeks.FirstOrDefaultAsync(m => m.WorkWeekId == id);
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
                var response = from c in _context.WorkWeeks
                               orderby c.WorkWeekId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateWorkWeek(int id, WorkWeek workWeek)
        {
            try
            {
                var res = await _context.WorkWeeks.FirstOrDefaultAsync(m => m.WorkWeekId == id);
                res.Day = workWeek.Day;
                res.Status = workWeek.Status;
                res.Country = workWeek.Country;
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
