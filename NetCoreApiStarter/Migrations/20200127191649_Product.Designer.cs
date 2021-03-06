﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCoreApiStarter.Models;

namespace NetCoreApiStarter.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20200127191649_Product")]
    partial class Product
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("NetCoreApiStarter.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsComplete");

                    b.Property<int>("Priority");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2020, 1, 27, 11, 16, 49, 662, DateTimeKind.Local).AddTicks(7194),
                            Description = "Prod-01",
                            IsComplete = false,
                            Priority = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2020, 1, 27, 11, 16, 49, 662, DateTimeKind.Local).AddTicks(7202),
                            Description = "Prod-02",
                            IsComplete = false,
                            Priority = 3
                        });
                });

            modelBuilder.Entity("NetCoreApiStarter.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsComplete");

                    b.Property<int>("Priority");

                    b.HasKey("Id");

                    b.ToTable("ToDos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2020, 1, 27, 11, 16, 49, 661, DateTimeKind.Local).AddTicks(5003),
                            Description = "Clean house",
                            IsComplete = false,
                            Priority = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2020, 1, 27, 11, 16, 49, 662, DateTimeKind.Local).AddTicks(5804),
                            Description = "Bake cake",
                            IsComplete = false,
                            Priority = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
