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
    public class MyProjectController : ControllerBase
    {
        private readonly IMyProjectService _service;
        public MyProjectController(IMyProjectService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetMyProjectList")]
        public async Task<IActionResult> GetMyProjectList()
        {
            try
            {
                var response = await _service.GetMyProjectList();
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
        [Route("GetMyProjectById/{MyProjectId}")]
        public async Task<IActionResult> MyProjectDetails(int MyProjectId)
        {
            try
            {
                var response = await _service.GetMyProject(MyProjectId);
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
        [Route("PostMyProject")]
        public async Task<IActionResult> CreateMyProject(MyProject myProject)
        {

            try
            {
                var response = await _service.CreateNewMyProject(myProject);
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



        [HttpDelete("DeleteById/{MyProjectId}")]
        public async Task<IActionResult> DeleteMyProject(int MyProjectId)
        {

            try
            {
                var response = await _service.DeleteMyProject(MyProjectId);
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
        [Route("PutMyProject/{MyProjectId}")]
        public async Task<IActionResult> UpdateMyProject(int MyProjectId, MyProject myProject)
        {
            try
            {
                var res = await _service.UpdateMyProject(MyProjectId, myProject);
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
