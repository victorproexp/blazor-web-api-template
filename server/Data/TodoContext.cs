using Microsoft.EntityFrameworkCore;
using Model;

namespace Data
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoTask> Tasks => Set<TodoTask>();
        public DbSet<User> Users => Set<User>();

        public TodoContext (DbContextOptions<TodoContext> options)
            : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Et eksempel på at man selv kan styre hvad en tabel skal hedde.
            modelBuilder.Entity<TodoTask>().ToTable("Tasks");
        }
    }
}