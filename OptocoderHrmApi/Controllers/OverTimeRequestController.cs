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
    public class OverTimeRequestController : ControllerBase
    {
        private readonly IOverTimeRequestService _service;
        public OverTimeRequestController(IOverTimeRequestService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetOverTimeRequestList")]
        public async Task<IActionResult> GetOverTimeRequestList()
        {
            try
            {
                var response = await _service.GetOverTimeRequestList();
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
        [Route("GetOverTimeRequestById/{OverTimeRequestId}")]
        public async Task<IActionResult> OverTimeRequestDetails(int OverTimeRequestId)
        {
            try
            {
                var response = await _service.GetOverTimeRequest(OverTimeRequestId);
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
        [Route("PostOverTimeRequest")]
        public async Task<IActionResult> CreateOverTimeRequest(OverTimeRequest overTimeRequest)
        {

            try
            {
                var response = await _service.CreateNewOverTimeRequest(overTimeRequest);
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



        [HttpDelete("DeleteById/{OverTimeRequestId}")]
        public async Task<IActionResult> DeleteOverTimeRequest(int OverTimeRequestId)
        {

            try
            {
                var response = await _service.DeleteOverTimeRequest(OverTimeRequestId);
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
        [Route("PutOverTimeRequest/{OverTimeRequestId}")]
        public async Task<IActionResult> UpdateOverTimeRequest(int OverTimeRequestId, OverTimeRequest overTimeRequest)
        {
            try
            {
                var res = await _service.UpdateOverTimeRequest(OverTimeRequestId, overTimeRequest);
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
