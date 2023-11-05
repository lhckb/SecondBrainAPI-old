namespace SecondBrainAPI.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SecondBrainAPI.Models;
    public class SecondBrainDb : DbContext
    {
        public SecondBrainDb(DbContextOptions<SecondBrainDb> options) : base(options) { }

        public DbSet<Reminder> Reminders => Set<Reminder>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
