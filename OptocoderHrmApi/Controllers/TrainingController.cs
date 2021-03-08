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
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _service;
        public TrainingController(ITrainingService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetTrainingList")]
        public async Task<IActionResult> GetTrainingList()
        {
            try
            {
                var response = await _service.GetTrainingList();
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

        // GET: Employee/Details/5
        [HttpGet]
        [Route("GetTrainingById/{TrainingId}")]
        public async Task<IActionResult> TrainingDetails(int TrainingId)
        {
            try
            {
                var response = await _service.GetTraining(TrainingId);
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
        [Route("PostTraining")]
        public async Task<IActionResult> CreateTraining(training training)
        {

            try
            {
                var response = await _service.CreateNewTraining(training);
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
        public async Task<IActionResult> DeleteTraining(int id)
        {

            try
            {
                var response = await _service.DeleteTraining(id);
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
        [Route("PutTraining/{TrainingId}")]
        public async Task<IActionResult> UpdateTraining(int TrainingId, training training)
        {
            try
            {
                var res = await _service.UpdateTraining(TrainingId, training);
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
