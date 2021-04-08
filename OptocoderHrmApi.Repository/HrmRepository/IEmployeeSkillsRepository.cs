using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IEmployeeSkillsRepository
    {
        Task<ICollection<EmployeeSkill>> GetEmployeeSkillsList();
        Task<EmployeeSkill> GetEmployeeSkills(int id);
        Task<EmployeeSkill> CreateNewEmployeeSkills(EmployeeSkill employeeSkill);

        Task<string> DeleteEmployeeSkills(int id);
        Task<string> UpdateEmployeeSkills(int id, EmployeeSkill employeeSkill);
    }

    public class EmployeeSkillsRepository : IEmployeeSkillsRepository
    {
        private readonly DataContext _context;

        public EmployeeSkillsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeSkill> CreateNewEmployeeSkills(EmployeeSkill employeeSkill)
        {
            try
            {
                _context.EmployeeSkills.Add(employeeSkill);
                await _context.SaveChangesAsync();
                return employeeSkill;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeSkills(int id)
        {
            try
            {
                var response = await _context.EmployeeSkills.FindAsync(id);
                _context.EmployeeSkills.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeSkill> GetEmployeeSkills(int id)
        {
            try
            {
                var res = await _context.EmployeeSkills.FirstOrDefaultAsync(m => m.EmployeeSkillsId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeSkill>> GetEmployeeSkillsList()
        {
            try
            {
                var response = from c in _context.EmployeeSkills
                               orderby c.EmployeeSkillsId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeSkills(int id, EmployeeSkill employeeSkill)
        {
            try
            {
                var res = await _context.EmployeeSkills.FirstOrDefaultAsync(m => m.EmployeeSkillsId == id);
                res.EmployeeName = employeeSkill.EmployeeName;
                res.EmployeeSkill1 = employeeSkill.EmployeeSkill1;
                res.Details = employeeSkill.Details;
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
