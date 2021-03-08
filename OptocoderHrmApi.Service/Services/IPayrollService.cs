using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface IPayrollService
    {
        Task<List<Payroll>> GetPayrollList();
        Task<Payroll> GetPayroll(int id);
        Task<Payroll> CreateNewPayroll(Payroll payroll);
        Task<string> DeletePayroll(int id);
        Task<string> UpdatePayroll(int id, Payroll payroll);
    }
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepository _repository;

        public PayrollService(IPayrollRepository repository)
        {
            _repository = repository;
        }
        public async Task<Payroll> CreateNewPayroll(Payroll payroll)
        {
            try
            {
                var res = await _repository.CreateNewPayroll(payroll);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePayroll(int id)
        {
            try
            {
                var res = await _repository.DeletePayroll(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Payroll> GetPayroll(int id)
        {
            try
            {
                var res = await _repository.GetPayroll(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Payroll>> GetPayrollList()
        {
            try
            {
                var res = await _repository.GetPayrollList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdatePayroll(int id, Payroll payroll)
        {
            try
            {
                var res = await _repository.UpdatePayroll(id,payroll);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
