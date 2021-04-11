using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IEmployeeProjectService
    {
        Task<ICollection<EmployeeProject>> GetEmployeeProjectList();
        Task<EmployeeProject> GetEmployeeProject(int id);
        Task<EmployeeProject> CreateNewEmployeeProject(EmployeeProject employeeProject);

        Task<string> DeleteEmployeeProject(int id);
        Task<string> UpdateEmployeeProject(int id, EmployeeProject employeeProject);
    }

    public class EmployeeProjectService : IEmployeeProjectService
    {
        private readonly IEmployeeProjectRepository _repository;

        public EmployeeProjectService(IEmployeeProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeProject> CreateNewEmployeeProject(EmployeeProject employeeProject)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeProject(employeeProject);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeProject(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployeeProject(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeProject> GetEmployeeProject(int id)
        {
            try
            {
                var res = await _repository.GetEmployeeProject(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeProject>> GetEmployeeProjectList()
        {
            try
            {
                var res = await _repository.GetEmployeeProjectList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeProject(int id, EmployeeProject employeeProject)
        {
            try
            {
                var res = await _repository.UpdateEmployeeProject(id, employeeProject);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
