using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
     public interface IEmployeeCertificationService
    {
        Task<ICollection<EmployeeCertification>> GetEmployeeCertificationList();
        Task<EmployeeCertification> GetEmployeeCertification(int id);
        Task<EmployeeCertification> CreateNewEmployeeCertification(EmployeeCertification employeeCertification);

        Task<string> DeleteEmployeeCertification(int id);
        Task<string> UpdateEmployeeCertification(int id, EmployeeCertification employeeCertification);
    }

    public class EmployeeCertificationService : IEmployeeCertificationService
    {
        private readonly IEmployeeCertificationRepository _repository;

        public EmployeeCertificationService(IEmployeeCertificationRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeCertification> CreateNewEmployeeCertification(EmployeeCertification employeeCertification)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeCertification(employeeCertification);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeCertification(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeCertification(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeCertification> GetEmployeeCertification(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeCertification(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeCertification>> GetEmployeeCertificationList()
        {
            try
            {
                var res = await _repository.GetEmployeeCertificationList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeCertification(int id, EmployeeCertification employeeCertification)
        {
            try
            {
                var res = await _repository.UpdateEmployeeCertification(id, employeeCertification);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
