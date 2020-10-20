using Microsoft.EntityFrameworkCore;

namespace AutoParking_backend
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}