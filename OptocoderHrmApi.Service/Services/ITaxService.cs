using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface ITaxService
    {
        Task<List<Taxis>> GetTaxList();
        Task<Taxis> GetTax(int id);
        Task<Taxis> CreateNewTax(Taxis taxis);
        Task<string> DeleteTax(int id);
        Task<string> UpdateTax(int id, Taxis taxis);
    }

    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _repository;

        public TaxService(ITaxRepository repository)
        {
            _repository = repository;
        }
        public async Task<Taxis> CreateNewTax(Taxis taxis)
        {
            try
            {
                var res = await _repository.CreateNewTax(taxis);
                return res;
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
                var res = await _repository.DeleteTax(id);
                return res;
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
                var res = await _repository.GetTax(id);
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
                var res = await _repository.GetTaxList();
                return res;
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
                var res = await _repository.UpdateTax(id,taxis);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
