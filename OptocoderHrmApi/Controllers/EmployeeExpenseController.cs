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
    public class EmployeeExpenseController : ControllerBase
    {
        private readonly IEmployeeExpenseService _service;
        public EmployeeExpenseController(IEmployeeExpenseService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeExpenseList")]
        public async Task<IActionResult> GetEmployeeExpenseList()
        {
            try
            {
                var response = await _service.GetEmployeeExpenseList();
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
        [Route("GetEmployeeExpenseById/{EmployeeExpenseId}")]
        public async Task<IActionResult> EmployeeExpenseDetails(int EmployeeExpenseId)
        {
            try
            {
                var response = await _service.GetEmployeeExpense(EmployeeExpenseId);
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
        [Route("PostEmployeeExpense")]
        public async Task<IActionResult> CreateEmployeeExpense(EmployeeExpense employeeExpense)
        {

            try
            {
                var response = await _service.CreateNewEmployeeExpense(employeeExpense);
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



        [HttpDelete("DeleteById/{EmployeeExpenseId}")]
        public async Task<IActionResult> DeleteEmployeeExpense(int EmployeeExpenseId)
        {

            try
            {
                var response = await _service.DeleteEmployeeExpense(EmployeeExpenseId);
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
        [Route("PutEmployeeExpense/{EmployeeExpenseId}")]
        public async Task<IActionResult> UpdateEmployeeExpense(int EmployeeExpenseId, EmployeeExpense employeeExpense)
        {
            try
            {
                var res = await _service.UpdateEmployeeExpense(EmployeeExpenseId, employeeExpense);
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
