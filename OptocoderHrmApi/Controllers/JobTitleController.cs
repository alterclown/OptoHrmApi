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
    public class JobTitleController : ControllerBase
    {
        private readonly IJobTitleService _service;
        public JobTitleController(IJobTitleService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetJobTitleList")]
        public async Task<IActionResult> GetJobTitleList()
        {
            try
            {
                var response = await _service.GetJobTitleList();
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
        [Route("GetJobTitleById/{JobTitleId}")]
        public async Task<IActionResult> JobTitleDetails(int JobTitleId)
        {
            try
            {
                var response = await _service.GetJobTitle(JobTitleId);
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
        [Route("PostJobTitle")]
        public async Task<IActionResult> CreateJobTitle(JobTitle jobTitle)
        {

            try
            {
                var response = await _service.CreateNewJobTitle(jobTitle);
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



        [HttpDelete("DeleteById/{JobTitleId}")]
        public async Task<IActionResult> DeleteJobTitle(int JobTitleId)
        {

            try
            {
                var response = await _service.DeleteJobTitle(JobTitleId);
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
        [Route("PutJobTitle/{JobTitleId}")]
        public async Task<IActionResult> UpdateJobTitle(int JobTitleId, JobTitle jobTitle)
        {
            try
            {
                var res = await _service.UpdateJobTitle(JobTitleId, jobTitle);
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
