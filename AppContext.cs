using Microsoft.EntityFrameworkCore;
using Models;

namespace AutoParking_backend
{
    public class AppContext : DbContext
    {
        public DbSet<Parking> parkings {get; set;}
        public DbSet<Client> clients {get; set;}
        public DbSet<TypeCar> typeCars {get; set;}
        public DbSet<TypePlace> typePlaces {get; set;}
        public DbSet<Place> places {get; set;}
        public DbSet<Reserv> reservations {get; set;}
        public AppContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}