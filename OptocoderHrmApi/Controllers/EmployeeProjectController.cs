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
    public class EmployeeProjectController : ControllerBase
    {
        private readonly IEmployeeProjectService _service;
        public EmployeeProjectController(IEmployeeProjectService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeProjectList")]
        public async Task<IActionResult> GetEmployeeProjectList()
        {
            try
            {
                var response = await _service.GetEmployeeProjectList();
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
        [Route("GetEmployeeProjectById/{EmployeeProjectId}")]
        public async Task<IActionResult> EmployeeProjectDetails(int EmployeeProjectId)
        {
            try
            {
                var response = await _service.GetEmployeeProject(EmployeeProjectId);
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
        [Route("PostEmployeeProject")]
        public async Task<IActionResult> CreateEmployeeProject(EmployeeProject employeeProject)
        {

            try
            {
                var response = await _service.CreateNewEmployeeProject(employeeProject);
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



        [HttpDelete("DeleteById/{EmployeeProjectId}")]
        public async Task<IActionResult> DeleteEmployeeProject(int EmployeeProjectId)
        {

            try
            {
                var response = await _service.DeleteEmployeeProject(EmployeeProjectId);
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
        [Route("PutEmployeeProject/{EmployeeProjectId}")]
        public async Task<IActionResult> UpdateEmployeeProject(int EmployeeProjectId, EmployeeProject employeeProject)
        {
            try
            {
                var res = await _service.UpdateEmployeeProject(EmployeeProjectId, employeeProject);
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
