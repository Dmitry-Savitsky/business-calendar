﻿// <auto-generated />
using System;
using EntityFrameworkCore.MySQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(RepairManagementDbContext))]
    partial class RepairManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ClientPhone")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdClient");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WebApplication1.Models.ClientAddress", b =>
                {
                    b.Property<int>("IdClientAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdClientAddress"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int?>("ClientIdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.HasKey("IdClientAddress");

                    b.HasIndex("ClientIdClient");

                    b.HasIndex("IdClient");

                    b.ToTable("ClientAddresses");
                });

            modelBuilder.Entity("WebApplication1.Models.Company", b =>
                {
                    b.Property<int>("IdCompany")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdCompany"));

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("CompanyPhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdCompany");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WebApplication1.Models.CompanyHasOrder", b =>
                {
                    b.Property<int>("CompanyIdCompany")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("OrderIdOrder")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("CompanyIdCompany", "OrderIdOrder");

                    b.HasIndex("OrderIdOrder");

                    b.ToTable("CompanyHasOrders");
                });

            modelBuilder.Entity("WebApplication1.Models.Executor", b =>
                {
                    b.Property<int>("IdExecutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdExecutor"));

                    b.Property<int?>("CompanyIdCompany")
                        .HasColumnType("int");

                    b.Property<string>("ExecutorName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ExecutorPhone")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.HasKey("IdExecutor");

                    b.HasIndex("CompanyIdCompany");

                    b.HasIndex("IdCompany");

                    b.ToTable("Executors");
                });

            modelBuilder.Entity("WebApplication1.Models.ExecutorHasService", b =>
                {
                    b.Property<int>("IdExecutor")
                        .HasColumnType("int");

                    b.Property<int>("IdService")
                        .HasColumnType("int");

                    b.HasKey("IdExecutor", "IdService");

                    b.HasIndex("IdService");

                    b.ToTable("ExecutorHasServices");
                });

            modelBuilder.Entity("WebApplication1.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdOrder"));

                    b.Property<int?>("ClientIdClient")
                        .HasColumnType("int");

                    b.Property<bool?>("Completed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("Confirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdClientAddress")
                        .HasColumnType("int");

                    b.Property<int>("IdService")
                        .HasColumnType("int");

                    b.Property<string>("OrderComment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("OrderEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("OrderStart")
                        .HasColumnType("datetime(6)");

                    b.HasKey("IdOrder");

                    b.HasIndex("ClientIdClient");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdClientAddress");

                    b.HasIndex("IdService");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebApplication1.Models.OrderHasExecutor", b =>
                {
                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdExecutor")
                        .HasColumnType("int");

                    b.HasKey("IdOrder", "IdExecutor");

                    b.HasIndex("IdExecutor");

                    b.ToTable("OrderHasExecutors");
                });

            modelBuilder.Entity("WebApplication1.Models.Review", b =>
                {
                    b.Property<int>("IdReview")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdReview"));

                    b.Property<int?>("ClientIdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("ReviewRating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdReview");

                    b.HasIndex("ClientIdClient");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdOrder");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WebApplication1.Models.Service", b =>
                {
                    b.Property<int>("IdService")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdService"));

                    b.Property<int?>("CompanyIdCompany")
                        .HasColumnType("int");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("ServicePrice")
                        .HasColumnType("int");

                    b.Property<int>("ServiceType")
                        .HasColumnType("int");

                    b.HasKey("IdService");

                    b.HasIndex("CompanyIdCompany");

                    b.HasIndex("IdCompany");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("WebApplication1.Models.ClientAddress", b =>
                {
                    b.HasOne("WebApplication1.Models.Client", null)
                        .WithMany("ClientAddresses")
                        .HasForeignKey("ClientIdClient");

                    b.HasOne("WebApplication1.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("WebApplication1.Models.CompanyHasOrder", b =>
                {
                    b.HasOne("WebApplication1.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyIdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderIdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebApplication1.Models.Executor", b =>
                {
                    b.HasOne("WebApplication1.Models.Company", null)
                        .WithMany("Executors")
                        .HasForeignKey("CompanyIdCompany");

                    b.HasOne("WebApplication1.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebApplication1.Models.ExecutorHasService", b =>
                {
                    b.HasOne("WebApplication1.Models.Executor", "Executor")
                        .WithMany()
                        .HasForeignKey("IdExecutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Executor");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("WebApplication1.Models.Order", b =>
                {
                    b.HasOne("WebApplication1.Models.Client", null)
                        .WithMany("Orders")
                        .HasForeignKey("ClientIdClient");

                    b.HasOne("WebApplication1.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.ClientAddress", "ClientAddress")
                        .WithMany()
                        .HasForeignKey("IdClientAddress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("ClientAddress");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("WebApplication1.Models.OrderHasExecutor", b =>
                {
                    b.HasOne("WebApplication1.Models.Executor", "Executor")
                        .WithMany()
                        .HasForeignKey("IdExecutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Executor");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebApplication1.Models.Review", b =>
                {
                    b.HasOne("WebApplication1.Models.Client", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ClientIdClient");

                    b.HasOne("WebApplication1.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebApplication1.Models.Service", b =>
                {
                    b.HasOne("WebApplication1.Models.Company", null)
                        .WithMany("Services")
                        .HasForeignKey("CompanyIdCompany");

                    b.HasOne("WebApplication1.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebApplication1.Models.Client", b =>
                {
                    b.Navigation("ClientAddresses");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("WebApplication1.Models.Company", b =>
                {
                    b.Navigation("Executors");

                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
