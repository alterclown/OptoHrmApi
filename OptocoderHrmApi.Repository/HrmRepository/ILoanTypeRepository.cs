using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface ILoanTypeRepository
    {
        Task<ICollection<LoanType>> GetLoanTypesList();
        Task<LoanType> GetLoanTypes(int id);
        Task<LoanType> CreateNewLoanTypes(LoanType LoanTypes);

        Task<string> DeleteLoanTypes(int id);
        Task<string> UpdateLoanTypes(int id, LoanType LoanTypes);
    }

    public class LoanTypeRepository : ILoanTypeRepository
    {
        private readonly DataContext _context;

        public LoanTypeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<LoanType> CreateNewLoanTypes(LoanType LoanTypes)
        {
            try
            {
                _context.LoanTypes.Add(LoanTypes);
                await _context.SaveChangesAsync();
                return LoanTypes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteLoanTypes(int id)
        {
            try
            {
                var response = await _context.LoanTypes.FindAsync(id);
                _context.LoanTypes.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LoanType> GetLoanTypes(int id)
        {
            try
            {
                var res = await _context.LoanTypes.FirstOrDefaultAsync(m => m.LoanTypeId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<LoanType>> GetLoanTypesList()
        {
            try
            {
                var response = from c in _context.LoanTypes
                               orderby c.LoanTypeId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateLoanTypes(int id, LoanType LoanTypes)
        {
            try
            {
                var res = await _context.LoanTypes.FirstOrDefaultAsync(m => m.LoanTypeId == id);
                res.Name = LoanTypes.Name;
                res.Details = LoanTypes.Details;
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
