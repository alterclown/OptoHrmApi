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
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _service;

        public EducationController(IEducationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetEducationList")]
        public async Task<IActionResult> GetEducationList()
        {
            try
            {
                var response = await _service.GetEducationList();
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

        // GET: Education/Details/5
        [HttpGet]
        [Route("GetEducationById/{EducationId}")]
        public async Task<IActionResult> EducationDetails(int EducationId)
        {
            try
            {
                var response = await _service.GetEducation(EducationId);
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
        [Route("PostEducation")]
        public async Task<IActionResult> CreateEducation(Education Education)
        {

            try
            {
                var response = await _service.CreateNewEducation(Education);
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



        [HttpDelete("DeleteById/{EducationId}")]
        public async Task<IActionResult> DeleteEducation(int EducationId)
        {

            try
            {
                var response = await _service.DeleteEducation(EducationId);
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
        [Route("PutEducation/{EducationId}")]
        public async Task<IActionResult> UpdateEducation(int EducationId, Education Education)
        {
            try
            {
                var res = await _service.UpdateEducation(EducationId, Education);
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
