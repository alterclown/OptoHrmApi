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
    public class EmployeeEducationController : ControllerBase
    {
        private readonly IEmployeeEducationService _service;
        public EmployeeEducationController(IEmployeeEducationService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeEducationList")]
        public async Task<IActionResult> GetEmployeeEducationList()
        {
            try
            {
                var response = await _service.GetEmployeeEducationList();
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
        [Route("GetEmployeeEducationById/{EmployeeEducationId}")]
        public async Task<IActionResult> EmployeeEducationDetails(int EmployeeEducationId)
        {
            try
            {
                var response = await _service.GetEmployeeEducation(EmployeeEducationId);
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
        [Route("PostEmployeeEducation")]
        public async Task<IActionResult> CreateEmployeeEducation(EmployeeEducation employeeEducation)
        {

            try
            {
                var response = await _service.CreateNewEmployeeEducation(employeeEducation);
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



        [HttpDelete("DeleteById/{EmployeeEducationId}")]
        public async Task<IActionResult> DeleteEmployeeEducation(int EmployeeEducationId)
        {

            try
            {
                var response = await _service.DeleteEmployeeEducation(EmployeeEducationId);
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
        [Route("PutEmployeeEducation/{EmployeeEducationId}")]
        public async Task<IActionResult> UpdateEmployeeEducation(int EmployeeEducationId, EmployeeEducation employeeEducation)
        {
            try
            {
                var res = await _service.UpdateEmployeeEducation(EmployeeEducationId, employeeEducation);
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
