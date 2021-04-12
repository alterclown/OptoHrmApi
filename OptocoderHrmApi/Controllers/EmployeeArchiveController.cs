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
    public class EmployeeArchiveController : ControllerBase
    {
        private readonly IEmployeeArchiveService _service;
        public EmployeeArchiveController(IEmployeeArchiveService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeArchiveList")]
        public async Task<IActionResult> GetEmployeeArchiveList()
        {
            try
            {
                var response = await _service.GetEmployeeArchiveList();
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
        [Route("GetEmployeeArchiveById/{EmployeeArchiveId}")]
        public async Task<IActionResult> EmployeeArchiveDetails(int EmployeeArchiveId)
        {
            try
            {
                var response = await _service.GetEmployeeArchive(EmployeeArchiveId);
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
        [Route("PostEmployeeArchive")]
        public async Task<IActionResult> CreateEmployeeArchive(EmployeeArchived employeeArchive)
        {

            try
            {
                var response = await _service.CreateNewEmployeeArchive(employeeArchive);
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



        [HttpDelete("DeleteById/{EmployeeArchiveId}")]
        public async Task<IActionResult> DeleteEmployeeArchive(int EmployeeArchiveId)
        {

            try
            {
                var response = await _service.DeleteEmployeeArchive(EmployeeArchiveId);
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
        [Route("PutEmployeeArchive/{EmployeeArchiveId}")]
        public async Task<IActionResult> UpdateEmployeeArchive(int EmployeeArchiveId, EmployeeArchived employeeArchive)
        {
            try
            {
                var res = await _service.UpdateEmployeeArchive(EmployeeArchiveId, employeeArchive);
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
