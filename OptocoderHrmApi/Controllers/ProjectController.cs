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
    public class ProjectController : ControllerBase
    {
        private readonly IEmployeeProjectService _service;

        public ProjectController(IEmployeeProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetProjectList")]
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
        [Route("GetProjectById/{ProjectHandleId}")]
        public async Task<IActionResult> EmployeeProjectDetails(int ProjectHandleId)
        {
            try
            {
                var response = await _service.GetEmployeeProject(ProjectHandleId);
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
        [Route("PostProject")]
        public async Task<IActionResult> EmployeeProjectCompany(EmployeeProject project)
        {

            try
            {
                var response = await _service.CreateNewEmployeeProject(project);
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
        public async Task<IActionResult> DeleteEmployeeProject(int id)
        {

            try
            {
                var response = await _service.DeleteEmployeeProject(id);
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
        [Route("PutProject/{ProjectHandleId}")]
        public async Task<IActionResult> UpdateEmployeeProject(int ProjectHandleId, EmployeeProject project)
        {
            try
            {
                var res = await _service.UpdateEmployeeProject(ProjectHandleId, project);
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
