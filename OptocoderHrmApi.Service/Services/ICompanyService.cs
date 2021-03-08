using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface ICompanyService
    {
        Task<ICollection<Company>> GetCompanyList();
        Task<Company> GetCompany(int id);
        Task<Company> CreateNewCompany(Company company);

        Task<string> DeleteCompany(int id);
        Task<string> UpdateCompany(int id,Company company);
    }

    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Company> CreateNewCompany(Company company)
        {
            try
            {
                var res = await _repository.CreateNewCompany(company);
                return res;
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
                var res = await _repository.DeleteCompany(id);
                return res;
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
                var res = await _repository.GetCompany(id);
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
                var res = await _repository.GetCompanyList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateCompany(int id,Company company)
        {
            try
            {
                var res = await _repository.UpdateCompany(id, company);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
