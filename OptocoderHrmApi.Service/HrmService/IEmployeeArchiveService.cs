using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmployeeArchiveService
    {
        Task<ICollection<EmployeeArchived>> GetEmployeeArchiveList();
        Task<EmployeeArchived> GetEmployeeArchive(int id);
        Task<EmployeeArchived> CreateNewEmployeeArchive(EmployeeArchived employeeArchive);

        Task<string> DeleteEmployeeArchive(int id);
        Task<string> UpdateEmployeeArchive(int id, EmployeeArchived employeeArchive);
    }

    public class EmployeeArchiveService : IEmployeeArchiveService
    {
        private readonly IEmployeeArchiveRepository _repository;

        public EmployeeArchiveService(IEmployeeArchiveRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeArchived> CreateNewEmployeeArchive(EmployeeArchived employeeArchive)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeArchive(employeeArchive);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeArchive(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeArchive(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeArchived> GetEmployeeArchive(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeArchive(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeArchived>> GetEmployeeArchiveList()
        {
            try
            {
                var res = await _repository.GetEmployeeArchiveList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeArchive(int id, EmployeeArchived employeeArchive)
        {
            try
            {
                var res = await _repository.UpdateEmployeeArchive(id, employeeArchive);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
