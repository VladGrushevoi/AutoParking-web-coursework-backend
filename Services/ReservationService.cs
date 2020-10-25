using System.Threading.Tasks;
using AutoParking_backend;
using Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ReservationService 
    {
        private AppContext _context;

        public ReservationService(AppContext context)
        {
            this._context = context;
        }

        public List<Reserv> GetallReserv()
        {
            return _context.reservations.ToList();
        }

        public List<Place> FreePlace(SearchModel sm) => GetFreePlace(sm).ToList();
        

        public List<Place> FreePlaceByParking(int id ,SearchModel sm)
        {
            var freePlace = GetFreePlace(sm);
            freePlace = freePlace.Where(p => p.ParkingId == id);
            return freePlace.ToList();
        }

        public Task<Reserv> ReservPlace(ReservModel rm)
        {
            _context.reservations.AddAsync(new Reserv{
                ClientId = rm.ClientId.Value,
                PlaceId = rm.PlaceId.Value,
                StartPeriod = rm.StartPeriod.Value.Date,
                EndPeriod = rm.EndPeriod.Value.Date
            });
            _context.SaveChangesAsync();

            return Task.Run(() => _context.reservations.OrderByDescending(r => r.ReservId).First());
        }

        public IQueryable<Place> GetFreePlace(SearchModel rm)
        {
            IQueryable<Reserv> actualReserv = GetActualReserv();

            return from place in _context.places
                    join reserv in actualReserv 
                    on place.PlaceId equals reserv.PlaceId into gr
                    from reserv in gr.DefaultIfEmpty()
                    where place.PlaceId != reserv.PlaceId && place.TypeCarId == rm.TypeCar && place.TypeId == rm.TypePlace
                    select place;
        }

        private IQueryable<Reserv> GetActualReserv()
        {
            return from reserv in _context.reservations
                    where reserv.EndPeriod.Date > System.DateTime.Now.Date
                    select reserv;
        }

    }
}