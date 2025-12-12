using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project.Models;

public partial class MovieDatabaseSqlContext : DbContext
{
    public MovieDatabaseSqlContext()
    {
    }

    public MovieDatabaseSqlContext(DbContextOptions<MovieDatabaseSqlContext> options)
        : base(options)
    {
    }

    public DbSet<Review> Reviews { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=./Database/MovieDatabaseSQL.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
