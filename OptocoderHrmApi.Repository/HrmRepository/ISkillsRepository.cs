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
    public interface ISkillsRepository
    {
        Task<ICollection<Skill>> GetSkillList();
        Task<Skill> GetSkill(int id);
        Task<Skill> CreateNewSkill(Skill skill);

        Task<string> DeleteSkill(int id);
        Task<string> UpdateSkill(int id, Skill skill);
    }

    public class SkillsRepository : ISkillsRepository
    {
        private readonly DataContext _context;

        public SkillsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Skill> CreateNewSkill(Skill skill)
        {
            try
            {
                _context.Skills.Add(skill);
                await _context.SaveChangesAsync();
                return skill;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteSkill(int id)
        {
            try
            {
                var response = await _context.Skills.FindAsync(id);
                _context.Skills.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Skill> GetSkill(int id)
        {
            try
            {
                var res = await _context.Skills.FirstOrDefaultAsync(m => m.SkillId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Skill>> GetSkillList()
        {
            try
            {
                var response = from c in _context.Skills
                               orderby c.SkillId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateSkill(int id, Skill skill)
        {
            try
            {
                var res = await _context.Skills.FirstOrDefaultAsync(m => m.SkillId == id);
                res.SkillName = skill.SkillName;
                res.Description = skill.Description;
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
