using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface ICertificationService
    {
        Task<ICollection<Certification>> GetCertificationList();
        Task<Certification> GetCertification(int id);
        Task<Certification> CreateNewCertification(Certification certification);

        Task<string> DeleteCertification(int id);
        Task<string> UpdateCertification(int id, Certification certification);
    }

    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _repository;

        public CertificationService(ICertificationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Certification> CreateNewCertification(Certification certification)
        {
            try
            {
                var res = await _repository.CreateNewCertification(certification);
                return res;
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
                var res = await _repository.DeleteCertification(id);
                return res;
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
                var res = await _repository.GetCertification(id);
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
                var res = await _repository.GetCertificationList();
                return res;
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
                var res = await _repository.UpdateCertification(id,certification);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
