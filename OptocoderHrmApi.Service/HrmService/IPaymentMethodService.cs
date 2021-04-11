using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IPaymentMethodService
    {
        Task<ICollection<PaymentMethod>> GetPaymentMethodList();
        Task<PaymentMethod> GetPaymentMethod(int id);
        Task<PaymentMethod> CreateNewPaymentMethod(PaymentMethod paymentMethod);

        Task<string> DeletePaymentMethod(int id);
        Task<string> UpdatePaymentMethod(int id, PaymentMethod paymentMethod);
    }

    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _repository;

        public PaymentMethodService(IPaymentMethodRepository repository)
        {
            _repository = repository;
        }
        public async Task<PaymentMethod> CreateNewPaymentMethod(PaymentMethod paymentMethod)
        {
            try
            {
                var res = await _repository.CreateNewPaymentMethod(paymentMethod);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePaymentMethod(int id)
        {
            try
            {
                var res = await _repository.DeletePaymentMethod(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PaymentMethod> GetPaymentMethod(int id)
        {
            try
            {
                var res = await _repository.GetPaymentMethod(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<PaymentMethod>> GetPaymentMethodList()
        {
            try
            {
                var res = await _repository.GetPaymentMethodList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdatePaymentMethod(int id, PaymentMethod paymentMethod)
        {
            try
            {
                var res = await _repository.UpdatePaymentMethod(id, paymentMethod);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
