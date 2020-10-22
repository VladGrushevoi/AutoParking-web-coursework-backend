using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private ClientService clientService;

        public ClientController(ClientService service)
        {
            this.clientService = service;
        }


        [HttpGet]
        public ActionResult<List<Client>> GetAllClients()
        {
            return Ok(clientService.GetAllClients().Result);
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetClientById(int id)
        {
            return Ok(clientService.GetClientById(id).Result);
        }

        [HttpPost]
        public ActionResult<Client> AddClient([FromBody] Client c)
        {
            return Created("Created", clientService.AddClient(c).Result);
        }

        [HttpGet("init")]
        public ActionResult<List<Client>> InitClient()
        {
            return Created("Created", clientService.InitClient().Result);
        }

        [HttpPatch("{id}")]
        public ActionResult<Client> EditClientInf(int id, [FromBody] Client c)
        {
            return Ok(clientService.EditInformation(id, c).Result);
        }
    }
}