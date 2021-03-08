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
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _service;

        public DesignationController(IDesignationService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetDesignationList")]
        public async Task<IActionResult> GetPositionList()
        {
            try
            {
                var response = await _service.GetPositionList();
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
        [Route("GetDesignationById/{PositionId}")]
        public async Task<IActionResult> PositionDetails(int PositionId)
        {
            try
            {
                var response = await _service.GetPosition(PositionId);
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
        [Route("PostDesignation")]
        public async Task<IActionResult> CreatePosition(Position position)
        {

            try
            {
                var response = await _service.CreateNewPosition(position);
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
        public async Task<IActionResult> DeletePosition(int id)
        {

            try
            {
                var response = await _service.DeletePosition(id);
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
        [Route("PutDesignation/{PositionId}")]
        public async Task<IActionResult> UpdatePosition(int PositionId, Position position)
        {
            try
            {
                var res = await _service.UpdatePosition(PositionId, position);
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
