using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface ICompanyRepository
    {
        Task<ICollection<Company>> GetCompanyList();
        Task<Company> GetCompany(int id);
        Task<Company> CreateNewCompany(Company company);

        Task<string> DeleteCompany(int id);
        Task<string> UpdateCompany(int id, Company company);
    }

    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Company> CreateNewCompany(Company company)
        {
            try
            {
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
                return company;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<string> DeleteCompany(int id)
        {
            try
            {
                var response = await _context.Companies.FindAsync(id);
                _context.Companies.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Company> GetCompany(int id)
        {
            try
            {
                var res = await _context.Companies.FirstOrDefaultAsync(m => m.CompanyId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Company>> GetCompanyList()
        {
            try
            {
                var response = from c in _context.Companies
                               orderby c.CompanyId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateCompany(int id, Company company)
        {
            try
            {
                var res = await _context.Companies.FirstOrDefaultAsync(m => m.CompanyId == id);
                res.CompanyName = company.CompanyName;
                res.CompanyDetails = company.CompanyDetails;
                res.CompanyAddress = company.CompanyAddress;
                res.CompanyType = company.CompanyType;
                res.CompanyCountry = company.CompanyCountry;
                res.CompanyTimeZone = company.CompanyTimeZone;
                res.LicenseKey = company.LicenseKey;
                res.LicenseKeyStartDate = company.LicenseKeyStartDate;
                res.LicenseKeyExpireDate = company.LicenseKeyExpireDate;
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
