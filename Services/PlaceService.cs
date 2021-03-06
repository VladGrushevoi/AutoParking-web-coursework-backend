using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoParking_backend;
using Models;

namespace Services
{
    public class PlaceService
    {
        private AppContext _context;

        public PlaceService(AppContext context)
        {
            this._context = context;
        }

        public Task<Place> AddPlace(int IdParking, Place p)
        {
            p.ParkingId = IdParking;
            _context.places.AddAsync(p);
            _context.SaveChangesAsync();

            return Task.Run(() => _context.places.OrderByDescending(c => c.PlaceId).FirstOrDefault());
        }

        public Task<List<Place>> GetAllPlaceByIdParking(int IdParking)
        {
            return Task.Run(() =>  _context.places.Where(p => p.ParkingId == IdParking).ToList());
        }

        public List<Place> GetFreePlace(int idPark)
        {
            List<int> actualReserv = GetActualReserv().ToList();
            List<Place> allPlace = _context.places.Where(p => p.ParkingId == idPark).ToList();
            List<Place> freePlaces = new List<Place>();

            foreach (var place in allPlace)
            {
                if(!(actualReserv.Contains(place.PlaceId)))
                {
                    freePlaces.Add(place);
                }
            }

            return freePlaces;
        }

        private IQueryable<int> GetActualReserv()
        {
            return from reserv in _context.reservations
                    where reserv.EndPeriod.Date > System.DateTime.Now.Date
                    select reserv.PlaceId;
        }

        ///================================================////
        ///       Це тупо для ініціалізіції інфи          ////
        public List<Place> InitPlace()
        {
            foreach(var p in _context.parkings){
                foreach(var tc in _context.typeCars){
                    foreach(var tp in _context.typePlaces){
                        for(int i = 0; i < 5; i++)
                        {
                            _context.places.AddAsync(new Place{
                            ParkingId = p.ParkingId,
                            TypeCarId = tc.TypeCarId,
                            TypeId = tp.TypeId,
                            Price = 100
                            });
                        }
                    }
                }
            }
            
            _context.SaveChangesAsync();
            return _context.places.ToList();
        }
    }
}