using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Service.HrmService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _service;
        public PaymentMethodController(IPaymentMethodService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetPaymentMethodList")]
        public async Task<IActionResult> GetPaymentMethodList()
        {
            try
            {
                var response = await _service.GetPaymentMethodList();
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Company/Details/5
        [HttpGet]
        [Route("GetPaymentMethodById/{PaymentMethodId}")]
        public async Task<IActionResult> PaymentMethodDetails(int PaymentMethodId)
        {
            try
            {
                var response = await _service.GetPaymentMethod(PaymentMethodId);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("PostPaymentMethod")]
        public async Task<IActionResult> CreatePaymentMethod(PaymentMethod paymentMethod)
        {

            try
            {
                var response = await _service.CreateNewPaymentMethod(paymentMethod);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [HttpDelete("DeleteById/{PaymentMethodId}")]
        public async Task<IActionResult> DeletePaymentMethod(int PaymentMethodId)
        {

            try
            {
                var response = await _service.DeletePaymentMethod(PaymentMethodId);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPut]
        [Route("PutPaymentMethod/{PaymentMethodId}")]
        public async Task<IActionResult> UpdatePaymentMethod(int PaymentMethodId, PaymentMethod paymentMethod)
        {
            try
            {
                var res = await _service.UpdatePaymentMethod(PaymentMethodId, paymentMethod);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
