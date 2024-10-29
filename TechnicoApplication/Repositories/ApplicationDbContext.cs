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
    public DbSet<OwnerItem> OwnerItems { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=(local);Initial Catalog=technico-app; Integrated Security = True;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)//check to add constraints
    {
        //modelBuilder
        //    .Entity<Customer>()
        //    .HasIndex(p => p.Email)
        //    .IsUnique();
    }

}
