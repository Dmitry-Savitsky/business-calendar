using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Models;

namespace EntityFrameworkCore.MySQL.Data
{
    public class RepairManagementDbContext : DbContext
    {
        public RepairManagementDbContext(DbContextOptions<RepairManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderHasExecutor> OrderHasExecutors { get; set; }
        public DbSet<ExecutorHasService> ExecutorHasServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Client
            modelBuilder.Entity<Client>()
                .HasKey(c => c.IdClient);

            // Company
            modelBuilder.Entity<Company>()
                .HasKey(c => c.IdCompany);

            // Executor
            modelBuilder.Entity<Executor>()
                .HasKey(e => e.IdExecutor);
            modelBuilder.Entity<Executor>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Executors)
                .HasForeignKey(e => e.IdCompany);

            // Service
            modelBuilder.Entity<Service>()
                .HasKey(s => s.IdService);
            modelBuilder.Entity<Service>()
                .HasOne(s => s.Company)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.IdCompany);

            // ClientAddress
            modelBuilder.Entity<ClientAddress>()
                .HasKey(ca => ca.IdClientAddress);
            modelBuilder.Entity<ClientAddress>()
                .HasOne(ca => ca.Client)
                .WithMany(c => c.ClientAddresses)
                .HasForeignKey(ca => ca.IdClient);

            // Order
            modelBuilder.Entity<Order>()
                .HasKey(o => o.IdOrder);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.IdClient);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Service)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.IdService);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.ClientAddress)
                .WithMany(ca => ca.Orders)
                .HasForeignKey(o => o.IdClientAddress);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Company)
                .WithMany()
                .HasForeignKey(o => o.IdCompany);

            // Review
            modelBuilder.Entity<Review>()
                .HasKey(r => r.IdReview);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.IdClient);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Order)
                .WithMany(o => o.Reviews)
                .HasForeignKey(r => r.IdOrder);

            // OrderHasExecutor (Many-to-Many)
            modelBuilder.Entity<OrderHasExecutor>()
                .HasKey(oe => new { oe.IdOrder, oe.IdExecutor });
            modelBuilder.Entity<OrderHasExecutor>()
                .HasOne(oe => oe.Order)
                .WithMany(o => o.OrderHasExecutors)
                .HasForeignKey(oe => oe.IdOrder);
            modelBuilder.Entity<OrderHasExecutor>()
                .HasOne(oe => oe.Executor)
                .WithMany(e => e.OrderHasExecutors)
                .HasForeignKey(oe => oe.IdExecutor);

            // ExecutorHasService (Many-to-Many)
            modelBuilder.Entity<ExecutorHasService>()
                .HasKey(es => new { es.IdExecutor, es.IdService });
            modelBuilder.Entity<ExecutorHasService>()
                .HasOne(es => es.Executor)
                .WithMany(e => e.ExecutorHasServices)
                .HasForeignKey(es => es.IdExecutor);
            modelBuilder.Entity<ExecutorHasService>()
                .HasOne(es => es.Service)
                .WithMany(s => s.ExecutorHasServices)
                .HasForeignKey(es => es.IdService);
        }
    }
}