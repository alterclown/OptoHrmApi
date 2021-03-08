using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartmentList();
        Task<Department> GetDepartment(int id);
        Task<Department> CreateNewDepartment(Department department);
        Task<string> DeleteDepartment(int id);
        Task<string> UpdateDepartment(int id, Department department);
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Department> CreateNewDepartment(Department department)
        {
            try
            {
                var res = await _repository.CreateNewDepartment(department);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteDepartment(int id)
        {
            try
            {
                var res = await _repository.DeleteDepartment(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Department> GetDepartment(int id)
        {
            try
            {
                var res = await _repository.GetDepartment(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Department>> GetDepartmentList()
        {
            try
            {
                var res = await _repository.GetDepartmentList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateDepartment(int id, Department department)
        {
            try
            {
                var res = await _repository.UpdateDepartment(id,department);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

