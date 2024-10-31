using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;

namespace TechnicoApplication.Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Repair> Repairs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=(local);Initial Catalog=technico-app; Integrated Security = True;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder
            .Entity<Owner>()
            .HasIndex(p => p.Email)
            .IsUnique();

        modelBuilder
            .Entity<Item>()
            .HasIndex(p => p.E9Number)
            .IsUnique();

        //modelBuilder.Entity<Owner>()
        //.HasMany(o => o.Items)
        //.WithMany(i => i.Owners)
        //.UsingEntity(j => j.ToTable("ItemOwner"));

        ////modelBuilder.Entity<Owner>().HasMany(u => u.Items).WithMany(p => p.Owners).UsingEntity(j => j.ToTable("ItemOwner"));
        //base.OnModelCreating(modelBuilder);
    }
}
