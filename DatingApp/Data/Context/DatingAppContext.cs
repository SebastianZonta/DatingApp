using DatingApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Data.Context
{
    public class DatingAppContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DatingAppContext(DbContextOptions options) : base(options)
        {

        }
    }
}
