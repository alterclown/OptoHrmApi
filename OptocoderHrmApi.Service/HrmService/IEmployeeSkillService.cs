using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmployeeSkillService
    {
        Task<ICollection<EmployeeSkill>> GetEmployeeSkillList();
        Task<EmployeeSkill> GetEmployeeSkill(int id);
        Task<EmployeeSkill> CreateNewEmployeeSkill(EmployeeSkill employeeSkill);

        Task<string> DeleteEmployeeSkill(int id);
        Task<string> UpdateEmployeeSkill(int id, EmployeeSkill employeeSkill);
    }

    public class EmployeeSkillService : IEmployeeSkillService
    {
        private readonly IEmployeeSkillsRepository _repository;

        public EmployeeSkillService(IEmployeeSkillsRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeSkill> CreateNewEmployeeSkill(EmployeeSkill employeeSkill)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeSkills(employeeSkill);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeSkill(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeSkills(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeSkill> GetEmployeeSkill(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeSkills(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeSkill>> GetEmployeeSkillList()
        {
            try
            {
                var res = await _repository.GetEmployeeSkillsList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeSkill(int id, EmployeeSkill employeeSkill)
        {
            try
            {
                var res = await _repository.UpdateEmployeeSkills(id, employeeSkill);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
