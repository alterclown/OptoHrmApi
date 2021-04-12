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
    public class EmployeeDeactivateController : ControllerBase
    {
        private readonly IEmployeeDeactivateService _service;
        public EmployeeDeactivateController(IEmployeeDeactivateService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeDeactivateList")]
        public async Task<IActionResult> GetEmployeeDeactivateList()
        {
            try
            {
                var response = await _service.GetEmployeeDeactivateList();
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
        [Route("GetEmployeeDeactivateById/{EmployeeDeactivateId}")]
        public async Task<IActionResult> EmployeeDeactivateDetails(int EmployeeDeactivateId)
        {
            try
            {
                var response = await _service.GetEmployeeDeactivate(EmployeeDeactivateId);
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
        [Route("PostEmployeeDeactivate")]
        public async Task<IActionResult> CreateEmployeeDeactivate(EmployeeDeactivated employeeDeactivate)
        {

            try
            {
                var response = await _service.CreateNewEmployeeDeactivate(employeeDeactivate);
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



        [HttpDelete("DeleteById/{EmployeeDeactivateId}")]
        public async Task<IActionResult> DeleteEmployeeDeactivate(int EmployeeDeactivateId)
        {

            try
            {
                var response = await _service.DeleteEmployeeDeactivate(EmployeeDeactivateId);
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
        [Route("PutEmployeeDeactivate/{EmployeeDeactivateId}")]
        public async Task<IActionResult> UpdateEmployeeDeactivate(int EmployeeDeactivateId, EmployeeDeactivated employeeDeactivate)
        {
            try
            {
                var res = await _service.UpdateEmployeeDeactivate(EmployeeDeactivateId, employeeDeactivate);
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
