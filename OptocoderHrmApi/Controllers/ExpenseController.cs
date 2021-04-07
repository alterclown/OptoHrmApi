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
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetExpenseList")]
        public async Task<IActionResult> GetExpenseList()
        {
            try
            {
                var response = await _service.GetExpenseList();
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
        [Route("GetExpenseById/{ExpenseId}")]
        public async Task<IActionResult> ExpenseDetails(int ExpenseId)
        {
            try
            {
                var response = await _service.GetExpense(ExpenseId);
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
        [Route("PostExpense")]
        public async Task<IActionResult> CreateExpense(Expense Expense)
        {

            try
            {
                var response = await _service.CreateNewExpense(Expense);
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



        [HttpDelete("DeleteById/{ExpenseId}")]
        public async Task<IActionResult> DeleteExpense(int ExpenseId)
        {

            try
            {
                var response = await _service.DeleteExpense(ExpenseId);
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
        [Route("PutExpense/{ExpenseId}")]
        public async Task<IActionResult> UpdateExpense(int ExpenseId, Expense Expense)
        {
            try
            {
                var res = await _service.UpdateExpense(ExpenseId, Expense);
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
