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
    public class EmployeePayrollController : ControllerBase
    {
        private readonly IEmployeePayrollService _service;
        public EmployeePayrollController(IEmployeePayrollService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeePayrollList")]
        public async Task<IActionResult> GetEmployeePayrollList()
        {
            try
            {
                var response = await _service.GetEmployeePayrollList();
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
        [Route("GetEmployeePayrollById/{EmployeePayrollId}")]
        public async Task<IActionResult> EmployeePayrollDetails(int EmployeePayrollId)
        {
            try
            {
                var response = await _service.GetEmployeePayroll(EmployeePayrollId);
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
        [Route("PostEmployeePayroll")]
        public async Task<IActionResult> CreateEmployeePayroll(Payroll employeePayroll)
        {

            try
            {
                var response = await _service.CreateNewEmployeePayroll(employeePayroll);
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



        [HttpDelete("DeleteById/{EmployeePayrollId}")]
        public async Task<IActionResult> DeleteEmployeePayroll(int EmployeePayrollId)
        {

            try
            {
                var response = await _service.DeleteEmployeePayroll(EmployeePayrollId);
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
        [Route("PutEmployeePayroll/{EmployeePayrollId}")]
        public async Task<IActionResult> UpdateEmployeePayroll(int EmployeePayrollId, Payroll employeePayroll)
        {
            try
            {
                var res = await _service.UpdateEmployeePayroll(EmployeePayrollId, employeePayroll);
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
