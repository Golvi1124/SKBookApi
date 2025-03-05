using System;
using Microsoft.EntityFrameworkCore;

namespace SKBookApi.Models;

public class DatabaseContext : DbContext
{


    public DbSet<Villain> Villains { get; set; } = default!;
    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Short> Shorts { get; set; } = default!;


    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=SKing.db");
        }
    }
//  to explicitly configure table relationships. This ensures Entity Framework knows about many-to-many relationships.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Book>()
        .HasMany(b => b.villains)
        .WithMany(v => v.books);

    modelBuilder.Entity<Short>()
        .HasMany(s => s.villains)
        .WithMany(v => v.shorts);
}


}

