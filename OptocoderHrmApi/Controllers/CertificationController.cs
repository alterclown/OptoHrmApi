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
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService _service;
        public CertificationController(ICertificationService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetCertificationList")]
        public async Task<IActionResult> GetCertificationList()
        {
            try
            {
                var response = await _service.GetCertificationList();
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
        [Route("GetCertificationById/{CertificationId}")]
        public async Task<IActionResult> CertificationDetails(int CertificationId)
        {
            try
            {
                var response = await _service.GetCertification(CertificationId);
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
        [Route("PostCertification")]
        public async Task<IActionResult> CreateCertification(Certification certification)
        {

            try
            {
                var response = await _service.CreateNewCertification(certification);
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



        [HttpDelete("DeleteById/{CertificationId}")]
        public async Task<IActionResult> DeleteCertification(int CertificationId)
        {

            try
            {
                var response = await _service.DeleteCertification(CertificationId);
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
        [Route("PutCertification/{CertificationId}")]
        public async Task<IActionResult> UpdateCertification(int CertificationId, Certification certification)
        {
            try
            {
                var res = await _service.UpdateCertification(CertificationId, certification);
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
