using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface ISkillsService
    {
        Task<ICollection<Skill>> GetSkillsList();
        Task<Skill> GetSkills(int id);
        Task<Skill> CreateNewSkills(Skill skills);

        Task<string> DeleteSkills(int id);
        Task<string> UpdateSkills(int id, Skill skills);
    }

    public class SkillsService : ISkillsService
    {
        private readonly ISkillsRepository _repository;

        public SkillsService(ISkillsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Skill> CreateNewSkills(Skill skills)
        {
            try
            {
                var res = await _repository.CreateNewSkill(skills);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteSkills(int id)
        {
            try
            {
                var res = await _repository.DeleteSkill(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Skill> GetSkills(int id)
        {
            try
            {
                var res = await _repository.GetSkill(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Skill>> GetSkillsList()
        {
            try
            {
                var res = await _repository.GetSkillList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateSkills(int id, Skill skills)
        {
            try
            {
                var res = await _repository.UpdateSkill(id, skills);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
