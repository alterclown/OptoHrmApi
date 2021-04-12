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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;
        public ProjectController(IProjectService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetProjectList")]
        public async Task<IActionResult> GetProjectList()
        {
            try
            {
                var response = await _service.GetProjectList();
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
        [Route("GetProjectById/{ProjectId}")]
        public async Task<IActionResult> ProjectDetails(int ProjectId)
        {
            try
            {
                var response = await _service.GetProject(ProjectId);
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
        public async Task<IActionResult> CreateProject(Project project)
        {

            try
            {
                var response = await _service.CreateNewProject(project);
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



        [HttpDelete("DeleteById/{ProjectId}")]
        public async Task<IActionResult> DeleteProject(int ProjectId)
        {

            try
            {
                var response = await _service.DeleteProject(ProjectId);
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
        [Route("PutProject/{ProjectId}")]
        public async Task<IActionResult> UpdateProject(int ProjectId, Project project)
        {
            try
            {
                var res = await _service.UpdateProject(ProjectId, project);
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
