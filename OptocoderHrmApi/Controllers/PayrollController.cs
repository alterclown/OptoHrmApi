using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _service;

        public PayrollController(IPayrollService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetPayrollList")]
        public async Task<IActionResult> GetPayrollList()
        {
            try
            {
                var response = await _service.GetPayrollList();
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
        [Route("GetPayrollById/{PayrollId}")]
        public async Task<IActionResult> PayrollDetails(int PayrollId)
        {
            try
            {
                var response = await _service.GetPayroll(PayrollId);
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
        [Route("PostPayroll")]
        public async Task<IActionResult> CreatePayroll(Payroll payroll)
        {

            try
            {
                var response = await _service.CreateNewPayroll(payroll);
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

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeletePayroll(int id)
        {

            try
            {
                var response = await _service.DeletePayroll(id);
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
        [Route("PutPayroll/{PayrollId}")]
        public async Task<IActionResult> UpdatePayroll(int PayrollId, Payroll payroll)
        {
            try
            {
                var res = await _service.UpdatePayroll(PayrollId, payroll);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
