using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controller
{
    [ApiController]
    [Route("api")]
    public class ReservationController : ControllerBase
    {
        private ReservationService reservationService;

        public ReservationController(ReservationService service)
        {
            this.reservationService = service;
        }

        [HttpGet("getreserv")]
        public ActionResult<List<Reserv>> GetAllReserv()
        {
            return Ok(reservationService.GetallReserv());
        }
        [HttpGet("get-reserv/client/{id}")]
        public ActionResult<List<Reserv>> GetReservByClient(int id)
        {
            return Ok(reservationService.GetReservByClient(id));
        }

        [HttpGet("search/freeplace")]
        public ActionResult<List<Place>> GetAllFreePlace()
        {
            return Ok(reservationService.FreePlace(new SearchModel{TypeCar=1, TypePlace=2}));
        }

        [HttpGet("search/parking/{id}/place")]
        public ActionResult<List<Place>> GetAllFreePlaceByParking(int id )
        {
            return Ok(reservationService.FreePlaceByParking(id, new SearchModel{TypeCar=1, TypePlace=2}));
        }

        [HttpPost("reserv")]
        public ActionResult<Reserv> AddReserv([FromBody] ReservModel rm)
        {
            return Created("Created reserv",reservationService.ReservPlace(rm).Result);
        }
    }
}