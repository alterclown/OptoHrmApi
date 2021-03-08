using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface ITaxRepository
    {
        Task<List<Taxis>> GetTaxList();
        Task<Taxis> GetTax(int id);
        Task<Taxis> CreateNewTax(Taxis taxis);
        Task<string> DeleteTax(int id);
        Task<string> UpdateTax(int id, Taxis taxis);
    }

    public class TaxRepository : ITaxRepository
    {
        private readonly DataContext _context;

        public TaxRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Taxis> CreateNewTax(Taxis taxis)
        {
            try
            {
                _context.Taxes.Add(taxis);
                await _context.SaveChangesAsync();
                return taxis;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteTax(int id)
        {
            try
            {
                var res = await _context.Taxes.FindAsync(id);
                _context.Taxes.Remove(res);
                await _context.SaveChangesAsync();
                return "Deleted Successfully";
            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }

        public async Task<Taxis> GetTax(int id)
        {
            try
            {
                var res = await _context.Taxes.FirstOrDefaultAsync(x=> x.TaxesId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Taxis>> GetTaxList()
        {
            try
            {
                var res = from c in _context.Taxes
                          orderby c.TaxesId descending
                          select c;
                return await res.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateTax(int id, Taxis taxis)
        {
            try
            {
                var response = await _context.Taxes.FirstOrDefaultAsync(m => m.TaxesId == id);
                response.EmployeeId = taxis.EmployeeId;
                response.TaxName = taxis.TaxName;
                response.TaxValue = taxis.TaxValue;
                response.Status = taxis.Status;
                response.CompanyId = taxis.CompanyId;
                response.UserId = taxis.UserId;
                _context.Taxes.Update(response);
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
