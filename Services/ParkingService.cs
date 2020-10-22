using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoParking_backend;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
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

        public Task<Parking> AddParking(Parking p)
        {
            _context.parkings.AddAsync(p);
            _context.SaveChangesAsync();
            return Task.Run(() => _context.parkings.OrderByDescending(p=> p.ParkingId).FirstOrDefault());
        }

        public Task<Parking> UpdateParking(int id,Parking p)
        {
            var parking = _context.parkings.FirstAsync(p => p.ParkingId == id);
            if(parking != null)
            {
                if(p.Name != null)
                {
                    parking.Result.Name = p.Name;
                }
                if(p.Description != null)
                {
                    parking.Result.Description = p.Description;
                }
                _context.SaveChangesAsync();
            }
            return Task.Run(() => _context.parkings.Find(id));
        }

        public Parking DeleteParking(int id)
        {
            var parking = _context.parkings.FindAsync(id);
            _context.parkings.Remove(parking.Result);
            _context.SaveChangesAsync();
            return parking.Result;
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