using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Data.Paging;
using OptocoderHrmApi.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _service;

        public LeaveController(ILeaveService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetLeaveList")]
        public async Task<IActionResult> GetLeaveList([FromQuery]Paging paging)
        {
            try
            {
                var response = await _service.GetLeaveList(paging);
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
        [Route("GetLeaveById/{LeaveId}")]
        public async Task<IActionResult> LeaveDetails(int LeaveId)
        {
            try
            {
                var response = await _service.GetLeave(LeaveId);
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
        [Route("PostLeave")]
        public async Task<IActionResult> CreateNewLeave(Leave leave)
        {

            try
            {
                var response = await _service.CreateNewLeave(leave);
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
        public async Task<IActionResult> DeleteLeave(int id)
        {

            try
            {
                var response = await _service.DeleteLeave(id);
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
        [Route("PutLeave/{LeaveId}")]
        public async Task<IActionResult> UpdateLeave(int LeaveId, Leave leave)
        {
            try
            {
                var res = await _service.UpdateLeave(LeaveId, leave);
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
