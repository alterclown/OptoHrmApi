using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface ILeaveRulesService
    {
        Task<ICollection<LeaveRule>> GetLeaveRulesList();
        Task<LeaveRule> GetLeaveRules(int id);
        Task<LeaveRule> CreateNewLeaveRules(LeaveRule leaveRules);

        Task<string> DeleteLeaveRules(int id);
        Task<string> UpdateLeaveRules(int id, LeaveRule leaveRules);
    }

    public class LeaveRulesService : ILeaveRulesService
    {
        private readonly ILeaveRulesRepository _repository;

        public LeaveRulesService(ILeaveRulesRepository repository)
        {
            _repository = repository;
        }
        public async Task<LeaveRule> CreateNewLeaveRules(LeaveRule leaveRules)
        {
            try
            {
                var res = await _repository.CreateNewLeaveRules(leaveRules);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLeaveRules(int id)
        {
            try
            {
                var res = await _repository.DeleteLeaveRules(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LeaveRule> GetLeaveRules(int id)
        {
            try
            {
                var res = await _repository.GetLeaveRules(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<LeaveRule>> GetLeaveRulesList()
        {
            try
            {
                var res = await _repository.GetLeaveRulesList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLeaveRules(int id, LeaveRule leaveRules)
        {
            try
            {
                var res = await _repository.UpdateLeaveRules(id, leaveRules);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
