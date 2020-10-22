using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

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

        [HttpPost]
        public ActionResult<Parking> AddParking([FromBody] Parking p)
        {
            return Created("Created parking", parkingService.AddParking(p).Result);
        }

        [HttpPatch("{id}")]
        public ActionResult<Parking> UpdateParking(int id, [FromBody] Parking p)
        {
            return Ok(parkingService.UpdateParking(id, p).Result);
        }

        [HttpDelete("{id}")]
        public ActionResult<Parking> DeleteParking(int id)
        {
            return Ok(parkingService.DeleteParking(id));
        }
    }    
}