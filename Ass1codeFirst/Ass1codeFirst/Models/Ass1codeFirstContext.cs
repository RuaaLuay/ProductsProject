using Microsoft.EntityFrameworkCore;

namespace Ass1codeFirst.Models
{
    public class Ass1codeFirstContext : DbContext
    {
        public Ass1codeFirstContext(DbContextOptions options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections{ get; set; }
    }
}
