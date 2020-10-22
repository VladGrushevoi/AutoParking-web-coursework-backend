using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypesController : ControllerBase
    {
        private TypeCarService typeCarService;
        private TypePlaceService typePlaceService;

        public TypesController(TypeCarService typeCar, TypePlaceService typePlace)
        {
            this.typeCarService = typeCar;
            this.typePlaceService = typePlace;
        }

        [HttpGet("init/car")]
        public ActionResult<TypeCar> InitTypeCar()
        {
            return Created("Created type car", typeCarService.InitType());
        }

        [HttpGet("init/place")]
        public ActionResult<TypeCar> InitTypePlace()
        {
            return Created("Created type palce", typePlaceService.InitPlace());
        }
    }
}