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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetClientList")]
        public async Task<IActionResult> GetClientList()
        {
            try
            {
                var response = await _service.GetClientList();
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

        // GET: Client/Details/5
        [HttpGet]
        [Route("GetClientById/{ClientId}")]
        public async Task<IActionResult> ClientDetails(int ClientId)
        {
            try
            {
                var response = await _service.GetClient(ClientId);
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
        [Route("PostClient")]
        public async Task<IActionResult> CreateClient(Client Client)
        {

            try
            {
                var response = await _service.CreateNewClient(Client);
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



        [HttpDelete("DeleteById/{ClientId}")]
        public async Task<IActionResult> DeleteClient(int ClientId)
        {

            try
            {
                var response = await _service.DeleteClient(ClientId);
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
        [Route("PutClient/{ClientId}")]
        public async Task<IActionResult> UpdateClient(int ClientId, Client Client)
        {
            try
            {
                var res = await _service.UpdateClient(ClientId, Client);
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
