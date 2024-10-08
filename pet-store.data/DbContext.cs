namespace pet_store.Data;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(e=>e.Products)
            .WithOne(e => e.Order);
        modelBuilder.Entity<Product>()
            .HasOne(e=>e.Order)
            .WithMany(e => e.Products)
            .HasForeignKey(e=>e.OrderId);
    }
    public string DbPath { get; }

    public DbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "products.db");
    }
    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}