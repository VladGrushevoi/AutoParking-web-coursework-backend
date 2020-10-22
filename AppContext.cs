using Microsoft.EntityFrameworkCore;
using Models;

namespace AutoParking_backend
{
    public class AppContext : DbContext
    {
        public DbSet<Parking> parkings {get; set;}
        public DbSet<Client> clients {get; set;}
        public AppContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}