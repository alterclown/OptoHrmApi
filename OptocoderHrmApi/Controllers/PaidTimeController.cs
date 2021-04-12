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
    public class PaidTimeController : ControllerBase
    {
        private readonly IPaidTimeService _service;
        public PaidTimeController(IPaidTimeService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetPaidTimeList")]
        public async Task<IActionResult> GetPaidTimeList()
        {
            try
            {
                var response = await _service.GetPaidTimeList();
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
        [Route("GetPaidTimeById/{PaidTimeId}")]
        public async Task<IActionResult> PaidTimeDetails(int PaidTimeId)
        {
            try
            {
                var response = await _service.GetPaidTime(PaidTimeId);
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
        [Route("PostPaidTime")]
        public async Task<IActionResult> CreatePaidTime(PaidTimeOff paidTime)
        {

            try
            {
                var response = await _service.CreateNewPaidTime(paidTime);
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



        [HttpDelete("DeleteById/{PaidTimeId}")]
        public async Task<IActionResult> DeletePaidTime(int PaidTimeId)
        {

            try
            {
                var response = await _service.DeletePaidTime(PaidTimeId);
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
        [Route("PutPaidTime/{PaidTimeId}")]
        public async Task<IActionResult> UpdatePaidTime(int PaidTimeId, PaidTimeOff paidTime)
        {
            try
            {
                var res = await _service.UpdatePaidTime(PaidTimeId, paidTime);
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
