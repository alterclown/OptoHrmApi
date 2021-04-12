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
    public class TrainingSetupController : ControllerBase
    {
        private readonly ITrainingSetupService _service;
        public TrainingSetupController(ITrainingSetupService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetTrainingSetupList")]
        public async Task<IActionResult> GetTrainingSetupList()
        {
            try
            {
                var response = await _service.GetTrainingSetupList();
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
        [Route("GetTrainingSetupById/{TrainingSetupId}")]
        public async Task<IActionResult> TrainingSetupDetails(int TrainingSetupId)
        {
            try
            {
                var response = await _service.GetTrainingSetup(TrainingSetupId);
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
        [Route("PostTrainingSetup")]
        public async Task<IActionResult> CreateTrainingSetup(TrainingSetup trainingSetup)
        {

            try
            {
                var response = await _service.CreateNewTrainingSetup(trainingSetup);
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



        [HttpDelete("DeleteById/{TrainingSetupId}")]
        public async Task<IActionResult> DeleteTrainingSetup(int TrainingSetupId)
        {

            try
            {
                var response = await _service.DeleteTrainingSetup(TrainingSetupId);
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
        [Route("PutTrainingSetup/{TrainingSetupId}")]
        public async Task<IActionResult> UpdateTrainingSetup(int TrainingSetupId, TrainingSetup trainingSetup)
        {
            try
            {
                var res = await _service.UpdateTrainingSetup(TrainingSetupId, trainingSetup);
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
