﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TourPlanner_Client.DAL.Database;

#nullable disable

namespace TourPlanner_Client.Migrations
{
    [DbContext(typeof(TourPlannerDbContext))]
    partial class TourPlannerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TourPlanner_Client.Models.Tour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Distance")
                        .HasColumnType("real");

                    b.Property<DateTime>("Estimate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ttype")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TourPlanner_Client.Models.TourLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Difficulty")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("TourId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("TourLogs");
                });

            modelBuilder.Entity("TourPlanner_Client.Models.TourLogs", b =>
                {
                    b.HasOne("TourPlanner_Client.Models.Tour", null)
                        .WithMany("TourLogs")
                        .HasForeignKey("TourId");
                });

            modelBuilder.Entity("TourPlanner_Client.Models.Tour", b =>
                {
                    b.Navigation("TourLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
