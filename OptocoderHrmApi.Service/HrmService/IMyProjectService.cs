using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IMyProjectService
    {
        Task<ICollection<MyProject>> GetMyProjectList();
        Task<MyProject> GetMyProject(int id);
        Task<MyProject> CreateNewMyProject(MyProject myProject);

        Task<string> DeleteMyProject(int id);
        Task<string> UpdateMyProject(int id, MyProject myProject);
    }

    public class MyProjectService : IMyProjectService
    {
        private readonly IMyProjectRepository _repository;

        public MyProjectService(IMyProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<MyProject> CreateNewMyProject(MyProject MyProject)
        {
            try
            {
                var res = await _repository.CreateNewMyProjects(MyProject);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteMyProject(int id)
        {
            try
            {
                var res = await _repository.DeleteMyProjects(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<MyProject> GetMyProject(int id)
        {
            try
            {
                var res = await _repository.GetMyProjects(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<MyProject>> GetMyProjectList()
        {
            try
            {
                var res = await _repository.GetMyProjectsList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateMyProject(int id, MyProject MyProject)
        {
            try
            {
                var res = await _repository.UpdateMyProjects(id, MyProject);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
