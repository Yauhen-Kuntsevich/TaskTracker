using dotenv.net;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

namespace TaskTracker.Data;

public class TaskTrackerContext : DbContext
{
    public DbSet<UserTask> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotEnv.Load();
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("TASK_TRACKER_CONNECTION"));
    }
}
