using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmployeeEducationService
    {
        Task<ICollection<EmployeeEducation>> GetEmployeeEducationList();
        Task<EmployeeEducation> GetEmployeeEducation(int id);
        Task<EmployeeEducation> CreateNewEmployeeEducation(EmployeeEducation employeeEducation);

        Task<string> DeleteEmployeeEducation(int id);
        Task<string> UpdateEmployeeEducation(int id, EmployeeEducation employeeEducation);
    }

    public class EmployeeEducationService : IEmployeeEducationService
    {
        private readonly IEmployeeEducationRepository _repository;

        public EmployeeEducationService(IEmployeeEducationRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeEducation> CreateNewEmployeeEducation(EmployeeEducation employeeEducation)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeEducation(employeeEducation);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeEducation(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeEducation(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeEducation> GetEmployeeEducation(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeEducation(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeEducation>> GetEmployeeEducationList()
        {
            try
            {
                var res = await _repository.GetEmployeeEducationList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeEducation(int id, EmployeeEducation employeeEducation)
        {
            try
            {
                var res = await _repository.UpdateEmployeeEducation(id, employeeEducation);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
