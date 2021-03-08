using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface ILoanService
    {
        Task<List<Loan>> GetLoanList();
        Task<Loan> GetLoan(int id);
        Task<Loan> CreateNewLoan(Loan loan);
        Task<string> DeleteLoan(int id);
        Task<string> UpdateLoan(int id, Loan loan);
    }
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repository;

        public LoanService(ILoanRepository repository)
        {
            _repository = repository;
        }
        public async Task<Loan> CreateNewLoan(Loan loan)
        {
            try
            {
                var res = await _repository.CreateNewLoan(loan);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLoan(int id)
        {
            try
            {
                var res = await _repository.DeleteLoan(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Loan> GetLoan(int id)
        {
            try
            {
                var res = await _repository.GetLoan(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Loan>> GetLoanList()
        {
            try
            {
                var res = await _repository.GetLoanList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLoan(int id, Loan loan)
        {
            try
            {
                var res = await _repository.UpdateLoan(id,loan);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
