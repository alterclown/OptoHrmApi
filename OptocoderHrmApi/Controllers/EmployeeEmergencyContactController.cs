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
    public class EmployeeEmergencyContactController : ControllerBase
    {
        private readonly IEmployeeEmergencyContactService _service;
        public EmployeeEmergencyContactController(IEmployeeEmergencyContactService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeEmergencyContactList")]
        public async Task<IActionResult> GetEmployeeEmergencyContactList()
        {
            try
            {
                var response = await _service.GetEmployeeEmergencyContactList();
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
        [Route("GetEmployeeEmergencyContactById/{EmployeeEmergencyContactId}")]
        public async Task<IActionResult> EmployeeEmergencyContactDetails(int EmployeeEmergencyContactId)
        {
            try
            {
                var response = await _service.GetEmployeeEmergencyContact(EmployeeEmergencyContactId);
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
        [Route("PostEmployeeEmergencyContact")]
        public async Task<IActionResult> CreateEmployeeEmergencyContact(EmployeeEmergencyContact employeeEmergencyContact)
        {

            try
            {
                var response = await _service.CreateNewEmployeeEmergencyContact(employeeEmergencyContact);
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



        [HttpDelete("DeleteById/{EmployeeEmergencyContactId}")]
        public async Task<IActionResult> DeleteEmployeeEmergencyContact(int EmployeeEmergencyContactId)
        {

            try
            {
                var response = await _service.DeleteEmployeeEmergencyContact(EmployeeEmergencyContactId);
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
        [Route("PutEmployeeEmergencyContact/{EmployeeEmergencyContactId}")]
        public async Task<IActionResult> UpdateEmployeeEmergencyContact(int EmployeeEmergencyContactId, EmployeeEmergencyContact employeeEmergencyContact)
        {
            try
            {
                var res = await _service.UpdateEmployeeEmergencyContact(EmployeeEmergencyContactId, employeeEmergencyContact);
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
