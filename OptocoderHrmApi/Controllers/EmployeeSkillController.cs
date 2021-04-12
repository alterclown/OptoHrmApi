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
    public class EmployeeSkillController : ControllerBase
    {
        private readonly IEmployeeSkillService _service;
        public EmployeeSkillController(IEmployeeSkillService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetEmployeeSkillList")]
        public async Task<IActionResult> GetEmployeeSkillList()
        {
            try
            {
                var response = await _service.GetEmployeeSkillList();
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
        [Route("GetEmployeeSkillById/{EmployeeSkillId}")]
        public async Task<IActionResult> EmployeeSkillDetails(int EmployeeSkillId)
        {
            try
            {
                var response = await _service.GetEmployeeSkill(EmployeeSkillId);
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
        [Route("PostEmployeeSkill")]
        public async Task<IActionResult> CreateEmployeeSkill(EmployeeSkill employeeSkill)
        {

            try
            {
                var response = await _service.CreateNewEmployeeSkill(employeeSkill);
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



        [HttpDelete("DeleteById/{EmployeeSkillId}")]
        public async Task<IActionResult> DeleteEmployeeSkill(int EmployeeSkillId)
        {

            try
            {
                var response = await _service.DeleteEmployeeSkill(EmployeeSkillId);
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
        [Route("PutEmployeeSkill/{EmployeeSkillId}")]
        public async Task<IActionResult> UpdateEmployeeSkill(int EmployeeSkillId, EmployeeSkill employeeSkill)
        {
            try
            {
                var res = await _service.UpdateEmployeeSkill(EmployeeSkillId, employeeSkill);
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
