using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Entities;

namespace YuHan.CabsBooking.Infrastructure.Data
{
    public class CabsBookingDbContext : DbContext
    {
        public CabsBookingDbContext(DbContextOptions<CabsBookingDbContext> options) : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<CabType> CabTypes { get; set; }
        public DbSet<BookingHistory> bookingHistories { get; set; }


        // to use fluent API, we need to override a method onModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>(ConfigurePlaces);
            modelBuilder.Entity<Booking>(ConfigureBooking);
            modelBuilder.Entity<BookingHistory>(ConfigureBookingHistory);
            modelBuilder.Entity<CabType>(ConfigureCabTypes);
        }

        private void ConfigurePlaces(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Places");
            builder.Property(t => t.PlaceName).HasMaxLength(30);
        }

        private void ConfigureCabTypes(EntityTypeBuilder<CabType> builder)
        {
            builder.ToTable("CabTypes");
            builder.Property(t => t.CabTypeName).HasMaxLength(30);
        }
        private void ConfigureBooking(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingDate).HasColumnType("date");
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickUpAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
            builder.Property(b => b.PickupDate).HasColumnType("date");
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);
            builder.HasOne(b => b.FromPlace).WithMany(b => b.FromBookings).HasForeignKey(b => b.FromPlaceId);
            builder.HasOne(b => b.ToPlace).WithMany(b => b.ToBookings).HasForeignKey(b => b.ToPlaceId);
        }

        private void ConfigureBookingHistory(EntityTypeBuilder<BookingHistory> builder)
        {
            builder.ToTable("Bookings history");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingDate).HasColumnType("date");
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickUpAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
            builder.Property(b => b.PickupDate).HasColumnType("date");
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);
            builder.Property(b => b.CompTime).HasMaxLength(5);
            builder.Property(b => b.Charge).HasColumnType("money");
            builder.Property(b => b.Feedback).HasMaxLength(1000);
            builder.HasOne(b => b.FromPlace).WithMany(b => b.FromBookingHistories).HasForeignKey(b => b.FromPlaceId);
            builder.HasOne(b => b.ToPlace).WithMany(b => b.ToBookingHistories).HasForeignKey(b => b.ToPlaceId);
        }
    }
}
