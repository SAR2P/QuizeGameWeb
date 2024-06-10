using Microsoft.EntityFrameworkCore;

namespace Quize_api.Models
{
    public class QuizeDbContext:DbContext
    {
        public QuizeDbContext(DbContextOptions<QuizeDbContext> options) : base(options)
        {
            
        }

        public DbSet<Question> questions { get; set; }

        public DbSet<Participant> participants { get; set; }
    }
}
