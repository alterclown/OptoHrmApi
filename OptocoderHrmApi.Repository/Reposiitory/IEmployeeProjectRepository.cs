using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface IEmployeeProjectRepository
    {
        Task<List<EmployeeProject>> GetEmployeeProjectList();
        Task<EmployeeProject> GetEmployeeProject(int id);
        Task<EmployeeProject> CreateNewEmployeeProject(EmployeeProject project);
        Task<string> DeleteEmployeeProject(int id);
        Task<string> UpdateEmployeeProject(int id, EmployeeProject project);
    }

    public class EmployeeProjectRepository : IEmployeeProjectRepository
    {
        private readonly DataContext _context;

        public EmployeeProjectRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeProject> CreateNewEmployeeProject(EmployeeProject project)
        {
            try
            {
                _context.EmployeeProjects.Add(project);
                await _context.SaveChangesAsync();
                return project;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeProject(int id)
        {
            try
            {
                var response = await _context.EmployeeProjects.FindAsync(id);
                _context.EmployeeProjects.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeProject> GetEmployeeProject(int id)
        {
            try
            {
                var res = await _context.EmployeeProjects.FirstOrDefaultAsync(m => m.ProjectHandleId == id);
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<EmployeeProject>> GetEmployeeProjectList()
        {
            try
            {
                var response = from c in _context.EmployeeProjects
                               orderby c.ProjectHandleId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeProject(int id, EmployeeProject project)
        {
            try
            {
                var response = await _context.EmployeeProjects.FirstOrDefaultAsync(m => m.ProjectHandleId == id);
                response.EmployeeId = project.EmployeeId;
                response.ProjectName = project.ProjectName;
                response.DateStarted = project.DateStarted;
                response.DateEnded = project.DateEnded;
                response.Status = project.Status;
                response.CompanyId = project.CompanyId;
                response.UserId = project.UserId;
                _context.EmployeeProjects.Update(response);
                await _context.SaveChangesAsync();
                return "Updated SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
