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
    public class EmployeeLeaveController : ControllerBase
    {
        private readonly IEmployeeLeaveService _service;
        public EmployeeLeaveController(IEmployeeLeaveService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeLeaveList")]
        public async Task<IActionResult> GetEmployeeLeaveList()
        {
            try
            {
                var response = await _service.GetEmployeeLeaveList();
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
        [Route("GetEmployeeLeaveById/{EmployeeLeaveId}")]
        public async Task<IActionResult> EmployeeLeaveDetails(int EmployeeLeaveId)
        {
            try
            {
                var response = await _service.GetEmployeeLeave(EmployeeLeaveId);
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
        [Route("PostEmployeeLeave")]
        public async Task<IActionResult> CreateEmployeeLeave(EmployeeLeave employeeLeave)
        {

            try
            {
                var response = await _service.CreateNewEmployeeLeave(employeeLeave);
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



        [HttpDelete("DeleteById/{EmployeeLeaveId}")]
        public async Task<IActionResult> DeleteEmployeeLeave(int EmployeeLeaveId)
        {

            try
            {
                var response = await _service.DeleteEmployeeLeave(EmployeeLeaveId);
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
        [Route("PutEmployeeLeave/{EmployeeLeaveId}")]
        public async Task<IActionResult> UpdateEmployeeLeave(int EmployeeLeaveId, EmployeeLeave employeeLeave)
        {
            try
            {
                var res = await _service.UpdateEmployeeLeave(EmployeeLeaveId, employeeLeave);
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
