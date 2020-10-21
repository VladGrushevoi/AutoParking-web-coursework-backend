using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Srvices;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {

        private ParkingService parkingService;

        public ParkingController(ParkingService service) => this.parkingService = service;

        [HttpGet]
        public ActionResult<List<Parking>> GetAllParkings()
        {
            return Ok(parkingService.GetAllParking().Result);
        }

        [HttpGet("{id}")]
        public ActionResult<Parking> GetPArkingById(int id)
        {
            return Ok(parkingService.GetParkingById(id).Result);
        }

        [HttpGet("init")]
        public ActionResult<List<Parking>> InitParkings()
        {
            return Created("Created",parkingService.CreateParkings().Result);
        }
    }    
}