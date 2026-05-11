using FocusListApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FocusListApi.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<TaskModel> DbTasks { get; set; }
    }
}