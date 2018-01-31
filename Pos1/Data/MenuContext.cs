using Microsoft.EntityFrameworkCore;
using Pos1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos1.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuCategory>().ToTable("MenuCategories");
            modelBuilder.Entity<MenuItem>().ToTable("MenuItems");
            modelBuilder.Entity<InventoryItem>().ToTable("InventoryItems");
            modelBuilder.Entity<Recipe>().ToTable("Recipes");
            modelBuilder.Entity<Inventory>().ToTable("Inventories");
        }
    }
}
