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
    public class LeaveRulesController : ControllerBase
    {
        private readonly ILeaveRulesService _service;
        public LeaveRulesController(ILeaveRulesService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetLeaveRulesList")]
        public async Task<IActionResult> GetLeaveRulesList()
        {
            try
            {
                var response = await _service.GetLeaveRulesList();
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
        [Route("GetLeaveRulesById/{LeaveRulesId}")]
        public async Task<IActionResult> LeaveRulesDetails(int LeaveRulesId)
        {
            try
            {
                var response = await _service.GetLeaveRules(LeaveRulesId);
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
        [Route("PostLeaveRules")]
        public async Task<IActionResult> CreateLeaveRules(LeaveRule leaveRules)
        {

            try
            {
                var response = await _service.CreateNewLeaveRules(leaveRules);
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



        [HttpDelete("DeleteById/{LeaveRulesId}")]
        public async Task<IActionResult> DeleteLeaveRules(int LeaveRulesId)
        {

            try
            {
                var response = await _service.DeleteLeaveRules(LeaveRulesId);
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
        [Route("PutLeaveRules/{LeaveRulesId}")]
        public async Task<IActionResult> UpdateLeaveRules(int LeaveRulesId, LeaveRule leaveRules)
        {
            try
            {
                var res = await _service.UpdateLeaveRules(LeaveRulesId, leaveRules);
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
