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
    public class SkillController : ControllerBase
    {
        private readonly ISkillsService _service;
        public SkillController(ISkillsService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetSkillList")]
        public async Task<IActionResult> GetSkillList()
        {
            try
            {
                var response = await _service.GetSkillsList();
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
        [Route("GetSkillById/{SkillId}")]
        public async Task<IActionResult> SkillDetails(int SkillId)
        {
            try
            {
                var response = await _service.GetSkills(SkillId);
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
        [Route("PostSkill")]
        public async Task<IActionResult> CreateSkill(Skill skill)
        {

            try
            {
                var response = await _service.CreateNewSkills(skill);
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



        [HttpDelete("DeleteById/{SkillId}")]
        public async Task<IActionResult> DeleteSkill(int SkillId)
        {

            try
            {
                var response = await _service.DeleteSkills(SkillId);
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
        [Route("PutSkill/{SkillId}")]
        public async Task<IActionResult> UpdateSkill(int SkillId, Skill skill)
        {
            try
            {
                var res = await _service.UpdateSkills(SkillId, skill);
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
