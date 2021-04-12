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
    public class MonitorAttendanceController : ControllerBase
    {
        private readonly IMonitorAttendanceService _service;
        public MonitorAttendanceController(IMonitorAttendanceService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetMonitorAttendanceList")]
        public async Task<IActionResult> GetMonitorAttendanceList()
        {
            try
            {
                var response = await _service.GetMonitorAttendanceList();
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
        [Route("GetMonitorAttendanceById/{MonitorAttendanceId}")]
        public async Task<IActionResult> MonitorAttendanceDetails(int MonitorAttendanceId)
        {
            try
            {
                var response = await _service.GetMonitorAttendance(MonitorAttendanceId);
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
        [Route("PostMonitorAttendance")]
        public async Task<IActionResult> CreateMonitorAttendance(MonitorAttendance monitorAttendance)
        {

            try
            {
                var response = await _service.CreateNewMonitorAttendance(monitorAttendance);
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



        [HttpDelete("DeleteById/{MonitorAttendanceId}")]
        public async Task<IActionResult> DeleteMonitorAttendance(int MonitorAttendanceId)
        {

            try
            {
                var response = await _service.DeleteMonitorAttendance(MonitorAttendanceId);
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
        [Route("PutMonitorAttendance/{MonitorAttendanceId}")]
        public async Task<IActionResult> UpdateMonitorAttendance(int MonitorAttendanceId, MonitorAttendance monitorAttendance)
        {
            try
            {
                var res = await _service.UpdateMonitorAttendance(MonitorAttendanceId, monitorAttendance);
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
