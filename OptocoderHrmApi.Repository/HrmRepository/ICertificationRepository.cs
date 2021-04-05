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
    public interface ICertificationRepository
    {
        Task<ICollection<Certification>> GetCertificationList();
        Task<Certification> GetCertification(int id);
        Task<Certification> CreateNewCertification(Certification certification);

        Task<string> DeleteCertification(int id);
        Task<string> UpdateCertification(int id, Certification certification);
    }

    public class CertificationRepository : ICertificationRepository
    {
        private readonly DataContext _context;

        public CertificationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Certification> CreateNewCertification(Certification certification)
        {
            try
            {
                _context.Certifications.Add(certification);
                await _context.SaveChangesAsync();
                return certification;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteCertification(int id)
        {
            try
            {
                var response = await _context.Certifications.FindAsync(id);
                _context.Certifications.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Certification> GetCertification(int id)
        {
            try
            {
                var res = await _context.Certifications.FirstOrDefaultAsync(m => m.CertificationId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Certification>> GetCertificationList()
        {
            try
            {
                var response = from c in _context.Certifications
                               orderby c.CertificationId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateCertification(int id, Certification certification)
        {
            try
            {
                var res = await _context.Certifications.FirstOrDefaultAsync(m => m.CertificationId == id);
                res.CertificationName = certification.CertificationName;
                res.Description = certification.Description;
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
