using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourPlanner_Client.Models;
using Npgsql;
using System.Configuration;

namespace TourPlanner_Client.DAL.Database
{
    public class TourPlannerDbContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourLog> TourLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            optionsBuilder.UseNpgsql(connectionString);
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure value conversion for _TransportType enum
            modelBuilder.Entity<Tour>()
                .HasMany(t => t.TourLogs)
                .WithOne()
                .HasForeignKey(tl => tl.TourId);
            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}