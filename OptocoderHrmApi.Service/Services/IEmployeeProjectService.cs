using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface IEmployeeProjectService
    {
        Task<List<EmployeeProject>> GetEmployeeProjectList();
        Task<EmployeeProject> GetEmployeeProject(int id);
        Task<EmployeeProject> CreateNewEmployeeProject(EmployeeProject project);
        Task<string> DeleteEmployeeProject(int id);
        Task<string> UpdateEmployeeProject(int id, EmployeeProject project);
    }

    public class EmployeeProjectService : IEmployeeProjectService
    {
        private readonly IEmployeeProjectRepository _repository;

        public EmployeeProjectService(IEmployeeProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeProject> CreateNewEmployeeProject(EmployeeProject project)
        {
            try
            {
                var res = await _repository.CreateNewEmployeeProject(project);
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

        public async Task<List<EmployeeProject>> GetEmployeeProjectList()
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

        public async Task<string> UpdateEmployeeProject(int id, EmployeeProject project)
        {
            try
            {
                var res = await _repository.UpdateEmployeeProject(id,project);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
