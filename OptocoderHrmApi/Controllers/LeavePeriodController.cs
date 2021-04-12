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
    public class LeavePeriodController : ControllerBase
    {
        private readonly ILeavePeriodService _service;
        public LeavePeriodController(ILeavePeriodService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetLeavePeriodList")]
        public async Task<IActionResult> GetLeavePeriodList()
        {
            try
            {
                var response = await _service.GetLeavePeriodList();
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
        [Route("GetLeavePeriodById/{LeavePeriodId}")]
        public async Task<IActionResult> LeavePeriodDetails(int LeavePeriodId)
        {
            try
            {
                var response = await _service.GetLeavePeriod(LeavePeriodId);
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
        [Route("PostLeavePeriod")]
        public async Task<IActionResult> CreateLeavePeriod(LeavePeriod leavePeriod)
        {

            try
            {
                var response = await _service.CreateNewLeavePeriod(leavePeriod);
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



        [HttpDelete("DeleteById/{LeavePeriodId}")]
        public async Task<IActionResult> DeleteLeavePeriod(int LeavePeriodId)
        {

            try
            {
                var response = await _service.DeleteLeavePeriod(LeavePeriodId);
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
        [Route("PutLeavePeriod/{LeavePeriodId}")]
        public async Task<IActionResult> UpdateLeavePeriod(int LeavePeriodId, LeavePeriod leavePeriod)
        {
            try
            {
                var res = await _service.UpdateLeavePeriod(LeavePeriodId, leavePeriod);
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
