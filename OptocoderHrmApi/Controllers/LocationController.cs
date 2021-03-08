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
    public class LocationController : ControllerBase
    {
        private readonly IGeoLocationService _service;

        public LocationController(IGeoLocationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetGeoLocationList()
        {
            try
            {
                var response = await _service.GetGeoLocationList();
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GeoLocationDetails(int id)
        {
            try
            {
                var response = await _service.GetGeoLocation(id);
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
        public async Task<IActionResult> CreateGeoLocation(GeoLocation location)
        {

            try
            {
                var response = await _service.CreateNewGeoLocation(location);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> GeoLocationDelete(int id)
        {

            try
            {
                var response = await _service.DeleteGeoLocation(id);
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
        public async Task<IActionResult> UpdateGeoLocation(int id, GeoLocation location)
        {
            try
            {
                var res = await _service.UpdateGeoLocation(id, location);
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
