using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetLoanList();
        Task<Loan> GetLoan(int id);
        Task<Loan> CreateNewLoan(Loan loan);
        Task<string> DeleteLoan(int id);
        Task<string> UpdateLoan(int id, Loan loan);
    }

    public class LoanRepository : ILoanRepository
    {
        private readonly DataContext _context;

        public LoanRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Loan> CreateNewLoan(Loan loan)
        {
            try
            {
                _context.Loans.Add(loan);
                await _context.SaveChangesAsync();
                return loan;
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
                var res = await _context.Loans.FindAsync(id);
                _context.Loans.Remove(res);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.Loans.FirstOrDefaultAsync(x=>x.LoanId == id);
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
                var res = from c in _context.Loans
                          orderby c.LoanId descending
                          select c;
                return await res.ToListAsync();
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
                var response = await _context.Loans.FirstOrDefaultAsync(m => m.LoanId == id);
                response.EmployeeId = loan.EmployeeId;
                response.TypeOfLoan = loan.TypeOfLoan;
                response.DateOfApplication = loan.DateOfApplication;
                response.ProposedAmount = loan.ProposedAmount;
                response.NoOfInstRecovery = loan.NoOfInstRecovery;
                response.StartDateOfRecovery = loan.StartDateOfRecovery;
                response.EndDateOfRecovery = loan.EndDateOfRecovery;
                response.NoOfDays = loan.NoOfDays;
                response.InterestRate = loan.InterestRate;
                response.InterestAmount = loan.InterestAmount;
                response.CompanyId = loan.CompanyId;
                response.UserId = loan.UserId;
                _context.Loans.Update(response);
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
