using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Data.Paging;
using OptocoderHrmApi.Service.HrmService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;
        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetAttendanceList")]
        public async Task<IActionResult> GetAttendanceList([FromQuery] Paging paging)
        {
            try
            {
                var response = await _service.GetAttendanceList(paging);
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
        [Route("GetAttendanceById/{AttendanceId}")]
        public async Task<IActionResult> AttendanceDetails(int AttendanceId)
        {
            try
            {
                var response = await _service.GetAttendance(AttendanceId);
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
        [Route("PostAttendance")]
        public async Task<IActionResult> CreateAttendance(Attendance attendance)
        {

            try
            {
                var response = await _service.CreateNewAttendance(attendance);
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



        [HttpDelete("DeleteById/{AttendanceId}")]
        public async Task<IActionResult> DeleteAttendance(int AttendanceId)
        {

            try
            {
                var response = await _service.DeleteAttendance(AttendanceId);
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
        [Route("PutAttendance/{AttendanceId}")]
        public async Task<IActionResult> UpdateAttendance(int AttendanceId, Attendance attendance)
        {
            try
            {
                var res = await _service.UpdateAttendance(AttendanceId, attendance);
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
