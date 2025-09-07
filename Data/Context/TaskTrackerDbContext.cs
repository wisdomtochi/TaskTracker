using Microsoft.EntityFrameworkCore;
using TaskTracker.Entities;

namespace TaskTracker.Data.Context
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Activity> Activities { get; set; }

        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Activity>().HasData(
                new Activity
                {
                    Id = Guid.Parse("c1a1f1ee-6c54-4b01-90e6-d701748f0851"),
                    Title = "Sample Activity",
                    Description = "This is a sample activity description.",
                    DueDate = DateTime.UtcNow.AddDays(7),
                    IsCompleted = false,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    LastModifiedAt = DateTime.UtcNow
                }
            );
        }
    }
}
