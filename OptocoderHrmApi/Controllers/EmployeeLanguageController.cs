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
    public class EmployeeLanguageController : ControllerBase
    {
        private readonly IEmployeeLanguageService _service;
        public EmployeeLanguageController(IEmployeeLanguageService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeLanguageList")]
        public async Task<IActionResult> GetEmployeeLanguageList()
        {
            try
            {
                var response = await _service.GetEmployeeLanguageList();
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
        [Route("GetEmployeeLanguageById/{EmployeeLanguageId}")]
        public async Task<IActionResult> EmployeeLanguageDetails(int EmployeeLanguageId)
        {
            try
            {
                var response = await _service.GetEmployeeLanguage(EmployeeLanguageId);
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
        [Route("PostEmployeeLanguage")]
        public async Task<IActionResult> CreateEmployeeLanguage(EmployeeLanguage employeeLanguage)
        {

            try
            {
                var response = await _service.CreateNewEmployeeLanguage(employeeLanguage);
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



        [HttpDelete("DeleteById/{EmployeeLanguageId}")]
        public async Task<IActionResult> DeleteEmployeeLanguage(int EmployeeLanguageId)
        {

            try
            {
                var response = await _service.DeleteEmployeeLanguage(EmployeeLanguageId);
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
        [Route("PutEmployeeLanguage/{EmployeeLanguageId}")]
        public async Task<IActionResult> UpdateEmployeeLanguage(int EmployeeLanguageId, EmployeeLanguage employeeLanguage)
        {
            try
            {
                var res = await _service.UpdateEmployeeLanguage(EmployeeLanguageId, employeeLanguage);
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
