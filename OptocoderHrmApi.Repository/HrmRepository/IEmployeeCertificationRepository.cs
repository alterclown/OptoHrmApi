using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IEmployeeCertificationRepository
    {
        Task<ICollection<EmployeeCertification>> GetEmployeeCertificationList();
        Task<EmployeeCertification> GetEmployeeCertification(int id);
        Task<EmployeeCertification> CreateNewEmployeeCertification(EmployeeCertification employeeCertification);

        Task<string> DeleteEmployeeCertification(int id);
        Task<string> UpdateEmployeeCertification(int id, EmployeeCertification employeeCertification);
    }

    public class EmployeeCertificationRepository : IEmployeeCertificationRepository
    {
        private readonly DataContext _context;

        public EmployeeCertificationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeCertification> CreateNewEmployeeCertification(EmployeeCertification employeeCertification)
        {
            try
            {
                _context.EmployeeCertifications.Add(employeeCertification);
                await _context.SaveChangesAsync();
                return employeeCertification;
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
                var response = await _context.EmployeeCertifications.FindAsync(id);
                _context.EmployeeCertifications.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.EmployeeCertifications.FirstOrDefaultAsync(m => m.EmployeeCertificationId == id);
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
                var response = from c in _context.EmployeeCertifications
                               orderby c.EmployeeCertificationId descending
                               select c;
                return await response.ToListAsync();
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
                var res = await _context.EmployeeCertifications.FirstOrDefaultAsync(m => m.EmployeeCertificationId == id);
                res.EmployeeName = employeeCertification.EmployeeName;
                res.Certification = employeeCertification.Certification;
                res.Institute = employeeCertification.Institute;
                res.GrantedOn = employeeCertification.GrantedOn;
                res.ValidThru = employeeCertification.ValidThru;
                _context.Update(res);
                await _context.SaveChangesAsync();
                return "Updated Record";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
