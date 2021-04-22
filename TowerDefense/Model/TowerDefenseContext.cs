using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Model
{
    public class TowerDefenseContext : DbContext
    {
        public DbSet<Coordinates> Route {get; set;}
        public DbSet<TowerModel> Towers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@$"Server={Environment.MachineName};Database=tower;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
