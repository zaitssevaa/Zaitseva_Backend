using Microsoft.EntityFrameworkCore;

namespace Zaitseva_Backend.Models
{
    public class TourContext: DbContext
    {
            public TourContext(DbContextOptions<TourContext> options)
                : base(options)
            {
            Database.Migrate();
            }
        public DbSet<Zaitseva_Backend.Models.Tour> Tour { get; set; } = default!;
        public DbSet<Zaitseva_Backend.Models.Agency> Agency { get; set; } = default!;
    }
}
