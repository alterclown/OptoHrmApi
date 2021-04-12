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
    public class TravelController : ControllerBase
    {
        private readonly ITravelService _service;
        public TravelController(ITravelService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetTravelList")]
        public async Task<IActionResult> GetTravelList()
        {
            try
            {
                var response = await _service.GetTravelList();
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
        [Route("GetTravelById/{TravelId}")]
        public async Task<IActionResult> TravelDetails(int TravelId)
        {
            try
            {
                var response = await _service.GetTravel(TravelId);
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
        [Route("PostTravel")]
        public async Task<IActionResult> CreateTravel(Travel travel)
        {

            try
            {
                var response = await _service.CreateNewTravel(travel);
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



        [HttpDelete("DeleteById/{TravelId}")]
        public async Task<IActionResult> DeleteTravel(int TravelId)
        {

            try
            {
                var response = await _service.DeleteTravel(TravelId);
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
        [Route("PutTravel/{TravelId}")]
        public async Task<IActionResult> UpdateTravel(int TravelId, Travel travel)
        {
            try
            {
                var res = await _service.UpdateTravel(TravelId, travel);
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
