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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetCompanyList")]
        public async Task<IActionResult> GetCompanyList()
        {
            try
            {
                var response = await _service.GetCompanyList();
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
        [Route("GetCompanyById/{CompanyId}")]
        public async Task<IActionResult> CompanyDetails(int CompanyId)
        {
            try
            {
                var response = await _service.GetCompany(CompanyId);
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
        [Route("PostCompany")]
        public async Task<IActionResult> CreateCompany(Company company)
        {

            try
            {
                var response = await _service.CreateNewCompany(company);
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



        [HttpDelete("DeleteById/{CompanyId}")]
        public async Task<IActionResult> DeleteCompany(int CompanyId)
        {

            try
            {
                var response = await _service.DeleteCompany(CompanyId);
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
        [Route("PutCompany/{CompanyId}")]
        public async Task<IActionResult> UpdateCompany(int CompanyId, Company company)
        {
            try
            {
                var res = await _service.UpdateCompany(CompanyId, company);
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
