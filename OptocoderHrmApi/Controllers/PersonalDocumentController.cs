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
    public class PersonalDocumentController : ControllerBase
    {
        private readonly IPersonalDocumentService _service;
        public PersonalDocumentController(IPersonalDocumentService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetPersonalDocumentList")]
        public async Task<IActionResult> GetPersonalDocumentList()
        {
            try
            {
                var response = await _service.GetPersonalDocumentList();
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
        [Route("GetPersonalDocumentById/{PersonalDocumentId}")]
        public async Task<IActionResult> PersonalDocumentDetails(int PersonalDocumentId)
        {
            try
            {
                var response = await _service.GetPersonalDocument(PersonalDocumentId);
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
        [Route("PostPersonalDocument")]
        public async Task<IActionResult> CreatePersonalDocument(PersonalDocument personalDocument)
        {

            try
            {
                var response = await _service.CreateNewPersonalDocument(personalDocument);
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



        [HttpDelete("DeleteById/{PersonalDocumentId}")]
        public async Task<IActionResult> DeletePersonalDocument(int PersonalDocumentId)
        {

            try
            {
                var response = await _service.DeletePersonalDocument(PersonalDocumentId);
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
        [Route("PutPersonalDocument/{PersonalDocumentId}")]
        public async Task<IActionResult> UpdatePersonalDocument(int PersonalDocumentId, PersonalDocument personalDocument)
        {
            try
            {
                var res = await _service.UpdatePersonalDocument(PersonalDocumentId, personalDocument);
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
