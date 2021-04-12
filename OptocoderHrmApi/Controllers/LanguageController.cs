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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _service;
        public LanguageController(ILanguageService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetLanguageList")]
        public async Task<IActionResult> GetLanguageList()
        {
            try
            {
                var response = await _service.GetLanguageList();
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
        [Route("GetLanguageById/{LanguageId}")]
        public async Task<IActionResult> LanguageDetails(int LanguageId)
        {
            try
            {
                var response = await _service.GetLanguage(LanguageId);
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
        [Route("PostLanguage")]
        public async Task<IActionResult> CreateLanguage(Language language)
        {

            try
            {
                var response = await _service.CreateNewLanguage(language);
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



        [HttpDelete("DeleteById/{LanguageId}")]
        public async Task<IActionResult> DeleteLanguage(int LanguageId)
        {

            try
            {
                var response = await _service.DeleteLanguage(LanguageId);
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
        [Route("PutLanguage/{LanguageId}")]
        public async Task<IActionResult> UpdateLanguage(int LanguageId, Language language)
        {
            try
            {
                var res = await _service.UpdateLanguage(LanguageId, language);
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
