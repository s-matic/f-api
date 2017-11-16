using Microsoft.EntityFrameworkCore;

namespace FeedbackApi.Models
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options)
            : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FeedbackDB.db");
        }
    }
}