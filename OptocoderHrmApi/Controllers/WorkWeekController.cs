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
    public class WorkWeekController : ControllerBase
    {
        private readonly IWorkWeekService _service;
        public WorkWeekController(IWorkWeekService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetWorkWeekList")]
        public async Task<IActionResult> GetWorkWeekList()
        {
            try
            {
                var response = await _service.GetWorkWeekList();
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
        [Route("GetWorkWeekById/{WorkWeekId}")]
        public async Task<IActionResult> WorkWeekDetails(int WorkWeekId)
        {
            try
            {
                var response = await _service.GetWorkWeek(WorkWeekId);
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
        [Route("PostWorkWeek")]
        public async Task<IActionResult> CreateWorkWeek(WorkWeek wWorkWeek)
        {

            try
            {
                var response = await _service.CreateNewWorkWeek(wWorkWeek);
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



        [HttpDelete("DeleteById/{WorkWeekId}")]
        public async Task<IActionResult> DeleteWorkWeek(int WorkWeekId)
        {

            try
            {
                var response = await _service.DeleteWorkWeek(WorkWeekId);
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
        [Route("PutWorkWeek/{WorkWeekId}")]
        public async Task<IActionResult> UpdateWorkWeek(int WorkWeekId, WorkWeek wWorkWeek)
        {
            try
            {
                var res = await _service.UpdateWorkWeek(WorkWeekId, wWorkWeek);
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
