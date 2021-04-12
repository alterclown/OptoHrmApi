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
    public class EmployeeCertificationController : ControllerBase
    {
        private readonly IEmployeeCertificationService _service;
        public EmployeeCertificationController(IEmployeeCertificationService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeCertificationList")]
        public async Task<IActionResult> GetEmployeeCertificationList()
        {
            try
            {
                var response = await _service.GetEmployeeCertificationList();
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
        [Route("GetEmployeeCertificationById/{EmployeeCertificationId}")]
        public async Task<IActionResult> EmployeeCertificationDetails(int EmployeeCertificationId)
        {
            try
            {
                var response = await _service.GetEmployeeCertification(EmployeeCertificationId);
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
        [Route("PostEmployeeCertification")]
        public async Task<IActionResult> CreateEmployeeCertification(EmployeeCertification employeeCertification)
        {

            try
            {
                var response = await _service.CreateNewEmployeeCertification(employeeCertification);
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



        [HttpDelete("DeleteById/{EmployeeCertificationId}")]
        public async Task<IActionResult> DeleteEmployeeCertification(int EmployeeCertificationId)
        {

            try
            {
                var response = await _service.DeleteEmployeeCertification(EmployeeCertificationId);
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
        [Route("PutEmployeeCertification/{EmployeeCertificationId}")]
        public async Task<IActionResult> UpdateEmployeeCertification(int EmployeeCertificationId, EmployeeCertification employeeCertification)
        {
            try
            {
                var res = await _service.UpdateEmployeeCertification(EmployeeCertificationId, employeeCertification);
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
