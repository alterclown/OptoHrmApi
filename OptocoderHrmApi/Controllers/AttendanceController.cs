using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Service.Services;
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
        private readonly IEmployeeAttendanceService _service;

        public AttendanceController(IEmployeeAttendanceService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAttendanceList")]
        public async Task<IActionResult> GetEmployeeAttendanceList()
        {
            try
            {
                var response = await _service.GetEmployeeAttendanceList();
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
        [Route("GetAttendanceById/{EmployeeAttendanceId}")]
        public async Task<IActionResult> EmployeeAttendanceDetails(int EmployeeAttendanceId)
        {
            try
            {
                var response = await _service.GetEmployeeAttendance(EmployeeAttendanceId);
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
        public async Task<IActionResult> EmployeeAttendance(EmployeeAttendance attendance)
        {

            try
            {
                var response = await _service.CreateNewEmployeeAttendance(attendance);
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
        public async Task<IActionResult> DeleteEmployeeAttendance(int id)
        {

            try
            {
                var response = await _service.DeleteEmployeeAttendance(id);
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
        [Route("PutAttendance/{EmployeeAttendanceId}")]
        public async Task<IActionResult> UpdateEmployeeAttendance(int EmployeeAttendanceId, EmployeeAttendance attendance)
        {
            try
            {
                var res = await _service.UpdateEmployeeAttendance(EmployeeAttendanceId, attendance);
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
