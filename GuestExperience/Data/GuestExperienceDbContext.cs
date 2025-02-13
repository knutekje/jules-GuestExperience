using GuestExperience.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestExperience.Data
{
    public class GuestExperienceDbContext : DbContext
    {
        public GuestExperienceDbContext(DbContextOptions<GuestExperienceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Guest entity.
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.ToTable("guest");
                entity.HasKey(g => g.Id);

                entity.Property(g => g.FirstName)
                      .HasColumnName("first_name")
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(g => g.LastName)
                      .HasColumnName("last_name")
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(g => g.Email)
                      .HasColumnName("email")
                      .HasMaxLength(200);
                entity.Property(g => g.PhoneNumber)
                      .HasColumnName("phone_number")
                      .HasMaxLength(50);
                entity.Property(g => g.Address)
                      .HasColumnName("address")
                      .HasMaxLength(300);
                entity.Property(g => g.City)
                      .HasColumnName("city")
                      .HasMaxLength(100);
                entity.Property(g => g.Nationality)
                      .HasColumnName("nationality")
                      .HasMaxLength(100);
                entity.Property(g => g.CreatedAt)
                      .HasColumnName("created_at")
                      .HasColumnType("datetime");
                entity.Property(g => g.UpdatedAt)
                      .HasColumnName("updated_at")
                      .HasColumnType("datetime");

                // One Guest has many Reservations.
                entity.HasMany(g => g.Reservations)
                      .WithOne(r => r.Guest)
                      .HasForeignKey(r => r.GuestId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Reservation entity.
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservation");
                entity.HasKey(r => r.Id);

                // One Reservation has many Bookings.
                entity.HasMany(r => r.Bookings)
                      .WithOne(b => b.Reservation)
                      .HasForeignKey(b => b.ReservationId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Booking entity.
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");
                entity.HasKey(b => b.Id);

                entity.Property(b => b.CheckIn)
                      .IsRequired()
                      .HasColumnName("check_in")
                      .HasColumnType("datetime");
                entity.Property(b => b.CheckOut)
                      .IsRequired()
                      .HasColumnName("check_out")
                      .HasColumnType("datetime");

                // One Booking belongs to one Reservation.
                entity.HasOne(b => b.Reservation)
                      .WithMany(r => r.Bookings)
                      .HasForeignKey(b => b.ReservationId)
                      .OnDelete(DeleteBehavior.Cascade);

                // One Booking is associated with one Room.
                entity.HasOne(b => b.Room)
                      .WithMany(r => r.Bookings)
                      .HasForeignKey(b => b.RoomId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Room entity.
            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");
                entity.HasKey(r => r.Id);

                entity.Property(r => r.RoomNumber)
                      .HasColumnName("room_number")
                      .IsRequired();
                entity.Property(r => r.RoomType)
                      .HasColumnName("room_type")
                      .IsRequired();
                entity.Property(r => r.Capacity)
                      .HasColumnName("capacity")
                      .IsRequired();
                entity.Property(r => r.Status)
                      .HasColumnName("status")
                      .IsRequired();
                entity.Property(r => r.PriceId)
                      .HasColumnName("price_id")
                      .IsRequired();
                entity.Property(r => r.Floor)
                      .HasColumnName("floor")
                      .IsRequired();
                entity.Property(r => r.ExtraBed)
                      .HasColumnName("extra_bed")
                      .IsRequired();
                entity.Property(r => r.LastMaintained)
                      .HasColumnName("last_maintained");
                entity.Property(r => r.CreatedAt)
                      .HasColumnName("created_at")
                      .HasColumnType("datetime");
                entity.Property(r => r.UpdatedAt)
                      .HasColumnName("updated_at")
                      .HasColumnType("datetime");

                entity.HasIndex(r => r.RoomNumber).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
