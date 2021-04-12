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
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypeService _service;
        public LeaveTypeController(ILeaveTypeService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetLeaveTypeList")]
        public async Task<IActionResult> GetLeaveTypeList()
        {
            try
            {
                var response = await _service.GetLeaveTypeList();
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
        [Route("GetLeaveTypeById/{LeaveTypeId}")]
        public async Task<IActionResult> LeaveTypeDetails(int LeaveTypeId)
        {
            try
            {
                var response = await _service.GetLeaveType(LeaveTypeId);
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
        [Route("PostLeaveType")]
        public async Task<IActionResult> CreateLeaveType(LeaveType leaveType)
        {

            try
            {
                var response = await _service.CreateNewLeaveType(leaveType);
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



        [HttpDelete("DeleteById/{LeaveTypeId}")]
        public async Task<IActionResult> DeleteLeaveType(int LeaveTypeId)
        {

            try
            {
                var response = await _service.DeleteLeaveType(LeaveTypeId);
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
        [Route("PutLeaveType/{LeaveTypeId}")]
        public async Task<IActionResult> UpdateLeaveType(int LeaveTypeId, LeaveType leaveType)
        {
            try
            {
                var res = await _service.UpdateLeaveType(LeaveTypeId, leaveType);
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
