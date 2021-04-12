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
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _service;
        public HolidayController(IHolidayService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetHolidayList")]
        public async Task<IActionResult> GetHolidayList()
        {
            try
            {
                var response = await _service.GetHolidayList();
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
        [Route("GetHolidayById/{HolidayId}")]
        public async Task<IActionResult> HolidayDetails(int HolidayId)
        {
            try
            {
                var response = await _service.GetHoliday(HolidayId);
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
        [Route("PostHoliday")]
        public async Task<IActionResult> CreateHoliday(Holiday holiday)
        {

            try
            {
                var response = await _service.CreateNewHoliday(holiday);
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



        [HttpDelete("DeleteById/{HolidayId}")]
        public async Task<IActionResult> DeleteHoliday(int HolidayId)
        {

            try
            {
                var response = await _service.DeleteHoliday(HolidayId);
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
        [Route("PutHoliday/{HolidayId}")]
        public async Task<IActionResult> UpdateHoliday(int HolidayId, Holiday holiday)
        {
            try
            {
                var res = await _service.UpdateHoliday(HolidayId, holiday);
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
