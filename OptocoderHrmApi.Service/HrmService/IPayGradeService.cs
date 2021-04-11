using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IPayGradeService
    {
        Task<ICollection<PayGrade>> GetPayGradeList();
        Task<PayGrade> GetPayGrade(int id);
        Task<PayGrade> CreateNewPayGrade(PayGrade payGrade);

        Task<string> DeletePayGrade(int id);
        Task<string> UpdatePayGrade(int id, PayGrade payGrade);
    }

    public class PayGradeService : IPayGradeService
    {
        private readonly IPayGradeRepository _repository;

        public PayGradeService(IPayGradeRepository repository)
        {
            _repository = repository;
        }
        public async Task<PayGrade> CreateNewPayGrade(PayGrade payGrade)
        {
            try
            {
                var res = await _repository.CreateNewPayGrade(payGrade);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePayGrade(int id)
        {
            try
            {
                var res = await _repository.DeletePayGrade(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PayGrade> GetPayGrade(int id)
        {
            try
            {
                var res = await _repository.GetPayGrade(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<PayGrade>> GetPayGradeList()
        {
            try
            {
                var res = await _repository.GetPayGradeList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdatePayGrade(int id, PayGrade payGrade)
        {
            try
            {
                var res = await _repository.UpdatePayGrade(id, payGrade);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
