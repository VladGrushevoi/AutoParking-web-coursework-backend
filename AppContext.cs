using Microsoft.EntityFrameworkCore;
using Models;

namespace AutoParking_backend
{
    public class AppContext : DbContext
    {
        public DbSet<Parking> parkings {get; set;}
        public AppContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}