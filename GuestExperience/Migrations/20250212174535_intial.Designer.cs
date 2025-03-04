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
    [Migration("20250212174535_intial")]
    partial class intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("GuestExperience.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime")
                        .HasColumnName("check_in");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime")
                        .HasColumnName("check_out");

                    b.Property<int>("ReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("RoomId");

                    b.ToTable("booking", (string)null);
                });

            modelBuilder.Entity("GuestExperience.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("city");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("nationality");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("phone_number");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("guest", (string)null);
                });

            modelBuilder.Entity("GuestExperience.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuestId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.ToTable("reservation", (string)null);
                });

            modelBuilder.Entity("GuestExperience.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER")
                        .HasColumnName("capacity");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
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
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("RoomNumber")
                        .IsUnique();

                    b.ToTable("room", (string)null);
                });

            modelBuilder.Entity("GuestExperience.Models.Booking", b =>
                {
                    b.HasOne("GuestExperience.Models.Reservation", "Reservation")
                        .WithMany("Bookings")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuestExperience.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("GuestExperience.Models.Reservation", b =>
                {
                    b.HasOne("GuestExperience.Models.Guest", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("GuestExperience.Models.Guest", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("GuestExperience.Models.Reservation", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("GuestExperience.Models.Room", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
