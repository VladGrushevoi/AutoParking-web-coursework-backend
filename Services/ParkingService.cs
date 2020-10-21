using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoParking_backend;
using Models;

namespace Srvices
{
    public class ParkingService
    {
        private AppContext _context;

        public ParkingService(AppContext context)
        {
            this._context = context;
        }

        public Task<List<Parking>> GetAllParking()
        {
            return Task.Run(() => _context.parkings.ToList());
        }

        public Task<Parking> GetParkingById(int id)
        {
            return Task.Run(() => _context.parkings.Find(id));
        }

        ///================================================////
        ///       Це тупо для ініціалізіції інфи          ////

        public Task<List<Parking>> CreateParkings()
        {
           return Task.Run(()=>{
                for(int i = 0; i < 3; i++)
                {
                    _context.parkings.Add(new Parking{
                        Name = $"Автостоянка-{i}",
                        Description = "Деякий опис автостоянки"
                    });
                }
                _context.SaveChangesAsync();
                return _context.parkings.ToList();
            });
        }
    }    
}