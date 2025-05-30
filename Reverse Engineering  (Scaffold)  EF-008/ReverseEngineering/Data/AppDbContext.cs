using System;
using System.Collections.Generic;
using EF008.ReverseEngineering.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF008.ReverseEngineering.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Speaker> Speakers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source =  = ABDULLAH\\MSSQLSERVER22 ; Initial Catalog = TechTalk ; Integrated Security = SSPI; TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Speaker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Speakers__3214EC0736C723DA");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(25);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
