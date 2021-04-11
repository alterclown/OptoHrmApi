using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface ILoanTypeService
    {
        Task<ICollection<LoanType>> GetLoanTypeList();
        Task<LoanType> GetLoanType(int id);
        Task<LoanType> CreateNewLoanType(LoanType loanType);

        Task<string> DeleteLoanType(int id);
        Task<string> UpdateLoanType(int id, LoanType loanType);
    }

    public class LoanTypeService : ILoanTypeService
    {
        private readonly ILoanTypeRepository _repository;

        public LoanTypeService(ILoanTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<LoanType> CreateNewLoanType(LoanType loanType)
        {
            try
            {
                var res = await _repository.CreateNewLoanTypes(loanType);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLoanType(int id)
        {
            try
            {
                var res = await _repository.DeleteLoanTypes(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LoanType> GetLoanType(int id)
        {
            try
            {
                var res = await _repository.GetLoanTypes(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<LoanType>> GetLoanTypeList()
        {
            try
            {
                var res = await _repository.GetLoanTypesList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLoanType(int id, LoanType loanType)
        {
            try
            {
                var res = await _repository.UpdateLoanTypes(id, loanType);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
