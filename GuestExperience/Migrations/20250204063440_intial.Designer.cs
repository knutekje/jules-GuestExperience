﻿// <auto-generated />
using System;
using GuestExperience.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuestExperience.Migrations
{
    [DbContext(typeof(GuestExperienceDbContext))]
    [Migration("20250204063440_intial")]
    partial class intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("GuestExperience.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER")
                        .HasColumnName("capacity");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<bool>("ExtraBed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("extra_bed");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER")
                        .HasColumnName("floor");

                    b.Property<DateTime?>("LastMaintained")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_maintained");

                    b.Property<int>("PriceId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("price_id");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnName("room_number");

                    b.Property<int>("RoomType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("room_type");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("room");
                });
#pragma warning restore 612, 618
        }
    }
}
