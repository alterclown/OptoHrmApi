using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmployeePayrollService
    {
        Task<ICollection<Payroll>> GetEmployeePayrollList();
        Task<Payroll> GetEmployeePayroll(int id);
        Task<Payroll> CreateNewEmployeePayroll(Payroll employeePayroll);

        Task<string> DeleteEmployeePayroll(int id);
        Task<string> UpdateEmployeePayroll(int id, Payroll employeePayroll);
    }

    public class EmployeePayrollService : IEmployeePayrollService
    {
        private readonly IEmployeePayrollRepository _repository;

        public EmployeePayrollService(IEmployeePayrollRepository repository)
        {
            _repository = repository;
        }
        public async Task<Payroll> CreateNewEmployeePayroll(Payroll employeePayroll)
        {
            try
            {
                var res = await _repository.CreateNewPayroll(employeePayroll);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeePayroll(int id)
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

        public async Task<Payroll> GetEmployeePayroll(int id)
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

        public async Task<ICollection<Payroll>> GetEmployeePayrollList()
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

        public async Task<string> UpdateEmployeePayroll(int id, Payroll employeePayroll)
        {
            try
            {
                var res = await _repository.UpdatePayroll(id, employeePayroll);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
