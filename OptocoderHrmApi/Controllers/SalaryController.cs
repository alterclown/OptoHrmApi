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
    public class SalaryController : ControllerBase
    {
        private readonly IEmployeeSalaryService _service;

        public SalaryController(IEmployeeSalaryService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetSalaryList")]
        public async Task<IActionResult> GetSalaryList()
        {
            try
            {
                var response = await _service.GetEmployeeSalaryList();
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

        // GET: Employee/Details/5
        [HttpGet]
        [Route("GetSalaryById/{SalaryId}")]
        public async Task<IActionResult> SalaryDetails(int SalaryId)
        {
            try
            {
                var response = await _service.GetEmployeeSalary(SalaryId);
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
        [Route("PostSalary")]
        public async Task<IActionResult> CreateSalary(EmployeeSalary salary)
        {

            try
            {
                var response = await _service.CreateNewEmployeeSalary(salary);
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
        public async Task<IActionResult> DeleteSalary(int id)
        {

            try
            {
                var response = await _service.DeleteEmployeeSalary(id);
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
        [Route("PutSalary/{SalaryId}")]
        public async Task<IActionResult> UpdateSalary(int SalaryId, EmployeeSalary salary)
        {
            try
            {
                var res = await _service.UpdateEmployeeSalary(SalaryId, salary);
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
