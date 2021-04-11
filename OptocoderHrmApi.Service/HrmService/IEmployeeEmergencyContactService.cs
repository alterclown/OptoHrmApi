using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmployeeEmergencyContactService
    {
        Task<ICollection<EmployeeEmergencyContact>> GetEmployeeEmergencyContactList();
        Task<EmployeeEmergencyContact> GetEmployeeEmergencyContact(int id);
        Task<EmployeeEmergencyContact> CreateNewEmployeeEmergencyContact(EmployeeEmergencyContact employeeEmergencyContact);

        Task<string> DeleteEmployeeEmergencyContact(int id);
        Task<string> UpdateEmployeeEmergencyContact(int id, EmployeeEmergencyContact employeeEmergencyContact);
    }

    public class EmployeeEmergencyContactService : IEmployeeEmergencyContactService
    {
        private readonly IEmployeeEmergencyContactRepository _repository;

        public EmployeeEmergencyContactService(IEmployeeEmergencyContactRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeEmergencyContact> CreateNewEmployeeEmergencyContact(EmployeeEmergencyContact employeeEmergencyContact)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeEmergencyContact(employeeEmergencyContact);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeEmergencyContact(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeEmergencyContact(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeEmergencyContact> GetEmployeeEmergencyContact(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeEmergencyContact(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeEmergencyContact>> GetEmployeeEmergencyContactList()
        {
            try
            {
                var res = await _repository.GetEmployeeEmergencyContactList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeEmergencyContact(int id, EmployeeEmergencyContact employeeEmergencyContact)
        {
            try
            {
                var res = await _repository.UpdateEmployeeEmergencyContact(id, employeeEmergencyContact);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
