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
    public class LoanTypeController : ControllerBase
    {
        private readonly ILoanTypeService _service;
        public LoanTypeController(ILoanTypeService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetLoanTypeList")]
        public async Task<IActionResult> GetLoanTypeList()
        {
            try
            {
                var response = await _service.GetLoanTypeList();
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
        [Route("GetLoanTypeById/{LoanTypeId}")]
        public async Task<IActionResult> LoanTypeDetails(int LoanTypeId)
        {
            try
            {
                var response = await _service.GetLoanType(LoanTypeId);
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
        [Route("PostLoanType")]
        public async Task<IActionResult> CreateLoanType(LoanType loanType)
        {

            try
            {
                var response = await _service.CreateNewLoanType(loanType);
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



        [HttpDelete("DeleteById/{LoanTypeId}")]
        public async Task<IActionResult> DeleteLoanType(int LoanTypeId)
        {

            try
            {
                var response = await _service.DeleteLoanType(LoanTypeId);
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
        [Route("PutLoanType/{LoanTypeId}")]
        public async Task<IActionResult> UpdateLoanType(int LoanTypeId, LoanType loanType)
        {
            try
            {
                var res = await _service.UpdateLoanType(LoanTypeId, loanType);
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
