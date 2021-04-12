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
    public class OverTimeController : ControllerBase
    {
        private readonly IOverTimeService _service;
        public OverTimeController(IOverTimeService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetOverTimeList")]
        public async Task<IActionResult> GetOverTimeList()
        {
            try
            {
                var response = await _service.GetOverTimeList();
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
        [Route("GetOverTimeById/{OverTimeId}")]
        public async Task<IActionResult> OverTimeDetails(int OverTimeId)
        {
            try
            {
                var response = await _service.GetOverTime(OverTimeId);
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
        [Route("PostOverTime")]
        public async Task<IActionResult> CreateOverTime(OverTime overTime)
        {

            try
            {
                var response = await _service.CreateNewOverTime(overTime);
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



        [HttpDelete("DeleteById/{OverTimeId}")]
        public async Task<IActionResult> DeleteOverTime(int OverTimeId)
        {

            try
            {
                var response = await _service.DeleteOverTime(OverTimeId);
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
        [Route("PutOverTime/{OverTimeId}")]
        public async Task<IActionResult> UpdateOverTime(int OverTimeId, OverTime overTime)
        {
            try
            {
                var res = await _service.UpdateOverTime(OverTimeId, overTime);
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
