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
    public class TrainingSessionController : ControllerBase
    {
        private readonly ITrainingSessionService _service;
        public TrainingSessionController(ITrainingSessionService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetTrainingSessionList")]
        public async Task<IActionResult> GetTrainingSessionList()
        {
            try
            {
                var response = await _service.GetTrainingSessionList();
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
        [Route("GetTrainingSessionById/{TrainingSessionId}")]
        public async Task<IActionResult> TrainingSessionDetails(int TrainingSessionId)
        {
            try
            {
                var response = await _service.GetTrainingSession(TrainingSessionId);
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
        [Route("PostTrainingSession")]
        public async Task<IActionResult> CreateTrainingSession(TrainingSession trainingSession)
        {

            try
            {
                var response = await _service.CreateNewTrainingSession(trainingSession);
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



        [HttpDelete("DeleteById/{TrainingSessionId}")]
        public async Task<IActionResult> DeleteTrainingSession(int TrainingSessionId)
        {

            try
            {
                var response = await _service.DeleteTrainingSession(TrainingSessionId);
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
        [Route("PutTrainingSession/{TrainingSessionId}")]
        public async Task<IActionResult> UpdateTrainingSession(int TrainingSessionId, TrainingSession trainingSession)
        {
            try
            {
                var res = await _service.UpdateTrainingSession(TrainingSessionId, trainingSession);
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
