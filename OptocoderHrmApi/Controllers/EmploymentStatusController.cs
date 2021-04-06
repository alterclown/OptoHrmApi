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
    public class EmploymentStatusController : ControllerBase
    {
        private readonly IEmploymentStatusService _service;

        public EmploymentStatusController(IEmploymentStatusService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmploymentStatusList")]
        public async Task<IActionResult> GetEmploymentStatusList()
        {
            try
            {
                var response = await _service.GetEmploymentStatusList();
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
        [Route("GetEmploymentStatusById/{EmploymentStatusId}")]
        public async Task<IActionResult> EmploymentStatusDetails(int EmploymentStatusId)
        {
            try
            {
                var response = await _service.GetEmploymentStatus(EmploymentStatusId);
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
        [Route("PostEmploymentStatus")]
        public async Task<IActionResult> CreateEmploymentStatus(EmploymentStatus employmentStatus)
        {

            try
            {
                var response = await _service.CreateNewEmploymentStatus(employmentStatus);
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



        [HttpDelete("DeleteById/{EmploymentStatusId}")]
        public async Task<IActionResult> DeleteEmploymentStatus(int EmploymentStatusId)
        {

            try
            {
                var response = await _service.DeleteEmploymentStatus(EmploymentStatusId);
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
        [Route("PutEmploymentStatus/{EmploymentStatusId}")]
        public async Task<IActionResult> UpdateEmploymentStatus(int EmploymentStatusId, EmploymentStatus employmentStatus)
        {
            try
            {
                var res = await _service.UpdateEmploymentStatus(EmploymentStatusId, employmentStatus);
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
