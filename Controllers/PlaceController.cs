using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private PlaceService placeService;

        public PlaceController(PlaceService service)
        {
            this.placeService = service;
        }

        [HttpGet("init")]
        public ActionResult<List<Place>> InitPlace()
        {
            return Created("Created place", placeService.InitPlace());
        }

        [HttpGet("parking/{id}")]
        public ActionResult<Place> GetPlaceByIdParking(int id)
        {
            return Ok(placeService.GetAllPlaceByIdParking(id).Result);
        }
    }
}