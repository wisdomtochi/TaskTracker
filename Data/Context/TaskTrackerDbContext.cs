using Microsoft.EntityFrameworkCore;
using TaskTracker.Entities;

namespace TaskTracker.Data.Context
{
    public class TaskTrackerDbContext : DbContext
    {
        //public TaskTrackerDbContext()
        //{
            
        //}

        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Activity> Activities { get; set; }

        public virtual DbSet<Tag> Tags {  get; set; }
    }
}
