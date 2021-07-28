﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YuHan.CabsBooking.Infrastructure.Data;

namespace YuHan.CabsBooking.Infrastructure.Migrations
{
    [DbContext(typeof(CabsBookingDbContext))]
    [Migration("20210726190947_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YuHan.CabsBooking.ApplicationCore.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnType("date");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FromPlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickUpAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("PickupDate")
                        .HasColumnType("date");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ToPlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("FromPlaceId");

                    b.HasIndex("ToPlaceId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("YuHan.CabsBooking.ApplicationCore.Entities.BookingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnType("date");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Charge")
                        .HasColumnType("money");

                    b.Property<string>("CompTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Feedback")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("FromPlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickUpAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("PickupDate")
                        .HasColumnType("date");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ToPlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("FromPlaceId");

                    b.HasIndex("ToPlaceId");

                    b.ToTable("Bookingw history");
                });

            modelBuilder.Entity("YuHan.CabsBooking.ApplicationCore.Entities.CabType", b =>
                {
                    b.Property<int>("CabTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CabTypeName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CabTypeId");

                    b.ToTable("CabTypes");
                });

            modelBuilder.Entity("YuHan.CabsBooking.ApplicationCore.Entities.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlaceName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("YuHan.CabsBooking.ApplicationCore.Entities.Booking", b =>
                {
                    b.HasOne("YuHan.CabsBooking.ApplicationCore.Entities.CabType", "CabType")
                        .WithMany("Bookings")
                        .HasForeignKey("CabTypeId");

                    b.HasOne("YuHan.CabsBooking.ApplicationCore.Entities.Place", "FromPlace")
                        .WithMany("FromBookings")
                        .HasForeignKey("FromPlaceId");

                    b.HasOne("YuHan.CabsBooking.ApplicationCore.Entities.Place", "ToPlace")
                        .WithMany("ToBookings")
                        .HasForeignKey("ToPlaceId");

                    b.Navigation("CabType");

                    b.Navigation("FromPlace");

                    b.Navigation("ToPlace");
                });

            modelBuilder.Entity("YuHan.CabsBooking.ApplicationCore.Entities.BookingHistory", b =>
                {
                    b.HasOne("YuHan.CabsBooking.ApplicationCore.Entities.CabType", "CabType")
                        .WithMany("BookingHistories")
                        .HasForeignKey("CabTypeId");

                    b.HasOne("YuHan.CabsBooking.ApplicationCore.Entities.Place", "FromPlace")
                        .WithMany("FromBookingHistories")
                        .HasForeignKey("FromPlaceId");

                    b.HasOne("YuHan.CabsBooking.ApplicationCore.Entities.Place", "ToPlace")
                        .WithMany("ToBookingHistories")
                        .HasForeignKey("ToPlaceId");

                    b.Navigation("CabType");

                    b.Navigation("FromPlace");

                    b.Navigation("ToPlace");
                });

            modelBuilder.Entity("YuHan.CabsBooking.ApplicationCore.Entities.CabType", b =>
                {
                    b.Navigation("BookingHistories");

                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("YuHan.CabsBooking.ApplicationCore.Entities.Place", b =>
                {
                    b.Navigation("FromBookingHistories");

                    b.Navigation("FromBookings");

                    b.Navigation("ToBookingHistories");

                    b.Navigation("ToBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
