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
    public class EmployeeDependentController : ControllerBase
    {
        private readonly IEmployeeDependentService _service;
        public EmployeeDependentController(IEmployeeDependentService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeDependentList")]
        public async Task<IActionResult> GetEmployeeDependentList()
        {
            try
            {
                var response = await _service.GetEmployeeDependentList();
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
        [Route("GetEmployeeDependentById/{EmployeeDependentId}")]
        public async Task<IActionResult> EmployeeDependentDetails(int EmployeeDependentId)
        {
            try
            {
                var response = await _service.GetEmployeeDependent(EmployeeDependentId);
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
        [Route("PostEmployeeDependent")]
        public async Task<IActionResult> CreateEmployeeDependent(EmployeeDependent employeeDependent)
        {

            try
            {
                var response = await _service.CreateNewEmployeeDependent(employeeDependent);
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



        [HttpDelete("DeleteById/{EmployeeDependentId}")]
        public async Task<IActionResult> DeleteEmployeeDependent(int EmployeeDependentId)
        {

            try
            {
                var response = await _service.DeleteEmployeeDependent(EmployeeDependentId);
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
        [Route("PutEmployeeDependent/{EmployeeDependentId}")]
        public async Task<IActionResult> UpdateEmployeeDependent(int EmployeeDependentId, EmployeeDependent employeeDependent)
        {
            try
            {
                var res = await _service.UpdateEmployeeDependent(EmployeeDependentId, employeeDependent);
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
