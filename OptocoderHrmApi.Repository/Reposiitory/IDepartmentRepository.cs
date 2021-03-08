using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentList();
        Task<Department> GetDepartment(int id);
        Task<Department> CreateNewDepartment(Department department);
        Task<string> DeleteDepartment(int id);
        Task<string> UpdateDepartment(int id , Department department);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;

        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Department> CreateNewDepartment(Department department)
        {
            try
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return department;
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
                var response = await _context.Departments.FindAsync(id);
                _context.Departments.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";

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
                var res = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentId == id);
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
                var response = from c in _context.Departments
                               orderby c.DepartmentId descending
                               select c;
                return await response.ToListAsync();
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
                var response = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentId == id);
                response.EmployeeId = department.EmployeeId;
                response.DepartmentName = department.DepartmentName;
                response.UserId = department.UserId;
                response.CompanyId = department.CompanyId;
                _context.Departments.Update(response);
                await _context.SaveChangesAsync();
                return "Updated SuccessFully";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
