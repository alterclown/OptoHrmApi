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
    public interface IEmployeeProjectRepository
    {
        Task<ICollection<EmployeeProject>> GetEmployeeProjectList();
        Task<EmployeeProject> GetEmployeeProject(int id);
        Task<EmployeeProject> CreateNewEmployeeProject(EmployeeProject employeeProject);

        Task<string> DeleteEmployeeProject(int id);
        Task<string> UpdateEmployeeProject(int id, EmployeeProject employeeProject);
    }

    public class EmployeeProjectRepository : IEmployeeProjectRepository
    {
        private readonly DataContext _context;

        public EmployeeProjectRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeProject> CreateNewEmployeeProject(EmployeeProject employeeProject)
        {
            try
            {
                _context.EmployeeProjects.Add(employeeProject);
                await _context.SaveChangesAsync();
                return employeeProject;
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
                var res = await _context.EmployeeProjects.FirstOrDefaultAsync(m => m.EmployeeProjectId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeProject>> GetEmployeeProjectList()
        {
            try
            {
                var response = from c in _context.EmployeeProjects
                               orderby c.EmployeeProjectId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeProject(int id, EmployeeProject employeeProject)
        {
            try
            {
                var res = await _context.EmployeeProjects.FirstOrDefaultAsync(m => m.EmployeeProjectId == id);
                res.EmployeeProjectName = employeeProject.EmployeeProjectName;
                res.EmployeeName = employeeProject.EmployeeName;
                res.Details = employeeProject.Details;
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
