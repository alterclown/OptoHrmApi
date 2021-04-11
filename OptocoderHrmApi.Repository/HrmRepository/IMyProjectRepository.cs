using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IMyProjectRepository
    {
        Task<ICollection<MyProject>> GetMyProjectsList();
        Task<MyProject> GetMyProjects(int id);
        Task<MyProject> CreateNewMyProjects(MyProject myProjects);

        Task<string> DeleteMyProjects(int id);
        Task<string> UpdateMyProjects(int id, MyProject myProjects);
    }

    public class MyProjectRepository : IMyProjectRepository
    {
        private readonly DataContext _context;

        public MyProjectRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<MyProject> CreateNewMyProjects(MyProject myProjects)
        {
            try
            {
                _context.MyProjects.Add(myProjects);
                await _context.SaveChangesAsync();
                return myProjects;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteMyProjects(int id)
        {
            try
            {
                var response = await _context.MyProjects.FindAsync(id);
                _context.MyProjects.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<MyProject> GetMyProjects(int id)
        {
            try
            {
                var res = await _context.MyProjects.FirstOrDefaultAsync(m => m.MyProjectId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<MyProject>> GetMyProjectsList()
        {
            try
            {
                var response = from c in _context.MyProjects
                               orderby c.MyProjectId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateMyProjects(int id, MyProject myProjects)
        {
            try
            {
                var res = await _context.MyProjects.FirstOrDefaultAsync(m => m.MyProjectId == id);
                res.MyProjectName = myProjects.MyProjectName;
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
