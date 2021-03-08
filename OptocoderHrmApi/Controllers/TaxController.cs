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
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _service;
        public TaxController(ITaxService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetTaxList")]
        public async Task<IActionResult> GetTaxList()
        {
            try
            {
                var response = await _service.GetTaxList();
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
        [Route("GetTaxById/{TaxesId}")]
        public async Task<IActionResult> TaxDetails(int TaxesId)
        {
            try
            {
                var response = await _service.GetTax(TaxesId);
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
        [Route("PostTax")]
        public async Task<IActionResult> CreateTax(Taxis taxis)
        {

            try
            {
                var response = await _service.CreateNewTax(taxis);
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
        public async Task<IActionResult> DeleteTax(int id)
        {

            try
            {
                var response = await _service.DeleteTax(id);
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
        [Route("PutTax/{TaxesId}")]
        public async Task<IActionResult> UpdateTax(int TaxesId, Taxis taxis)
        {
            try
            {
                var res = await _service.UpdateTax(TaxesId, taxis);
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
