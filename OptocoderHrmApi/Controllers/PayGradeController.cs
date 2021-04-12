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
    public class PayGradeController : ControllerBase
    {
        private readonly IPayGradeService _service;
        public PayGradeController(IPayGradeService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetPayGradeList")]
        public async Task<IActionResult> GetPayGradeList()
        {
            try
            {
                var response = await _service.GetPayGradeList();
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
        [Route("GetPayGradeById/{PayGradeId}")]
        public async Task<IActionResult> PayGradeDetails(int PayGradeId)
        {
            try
            {
                var response = await _service.GetPayGrade(PayGradeId);
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
        [Route("PostPayGrade")]
        public async Task<IActionResult> CreatePayGrade(PayGrade payGrade)
        {

            try
            {
                var response = await _service.CreateNewPayGrade(payGrade);
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



        [HttpDelete("DeleteById/{PayGradeId}")]
        public async Task<IActionResult> DeletePayGrade(int PayGradeId)
        {

            try
            {
                var response = await _service.DeletePayGrade(PayGradeId);
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
        [Route("PutPayGrade/{PayGradeId}")]
        public async Task<IActionResult> UpdatePayGrade(int PayGradeId, PayGrade payGrade)
        {
            try
            {
                var res = await _service.UpdatePayGrade(PayGradeId, payGrade);
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
