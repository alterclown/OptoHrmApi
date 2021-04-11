using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IProjectService
    {
        Task<ICollection<Project>> GetProjectList();
        Task<Project> GetProject(int id);
        Task<Project> CreateNewProject(Project project);

        Task<string> DeleteProject(int id);
        Task<string> UpdateProject(int id, Project project);
    }

    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<Project> CreateNewProject(Project project)
        {
            try
            {
                var res = await _repository.CreateNewProject(project);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteProject(int id)
        {
            try
            {
                var res = await _repository.DeleteProject(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Project> GetProject(int id)
        {
            try
            {
                var res = await _repository.GetProject(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Project>> GetProjectList()
        {
            try
            {
                var res = await _repository.GetProjectList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateProject(int id, Project project)
        {
            try
            {
                var res = await _repository.UpdateProject(id, project);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
