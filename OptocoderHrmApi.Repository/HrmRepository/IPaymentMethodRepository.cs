using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IPaymentMethodRepository
    {
        Task<ICollection<PaymentMethod>> GetPaymentMethodList();
        Task<PaymentMethod> GetPaymentMethod(int id);
        Task<PaymentMethod> CreateNewPaymentMethod(PaymentMethod paymentMethod);

        Task<string> DeletePaymentMethod(int id);
        Task<string> UpdatePaymentMethod(int id, PaymentMethod paymentMethod);
    }

    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly DataContext _context;

        public PaymentMethodRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<PaymentMethod> CreateNewPaymentMethod(PaymentMethod paymentMethod)
        {
            try
            {
                _context.PaymentMethods.Add(paymentMethod);
                await _context.SaveChangesAsync();
                return paymentMethod;
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
                var response = await _context.PaymentMethods.FindAsync(id);
                _context.PaymentMethods.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.PaymentMethods.FirstOrDefaultAsync(m => m.PaymentMethodId == id);
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
                var response = from c in _context.PaymentMethods
                               orderby c.PaymentMethodId descending
                               select c;
                return await response.ToListAsync();
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
                var res = await _context.PaymentMethods.FirstOrDefaultAsync(m => m.PaymentMethodId == id);
                res.PaymentMethodName = paymentMethod.PaymentMethodName;
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
