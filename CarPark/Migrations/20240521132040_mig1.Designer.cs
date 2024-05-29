﻿// <auto-generated />
using System;
using CarPark.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarPark.Migrations
{
    [DbContext(typeof(CarParkContext))]
    [Migration("20240521132040_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Ukrainian_100_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarPark.Models.DBuse", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusId"));

                    b.Property<string>("Brand")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Notes")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Numer")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<int?>("Years")
                        .HasColumnType("int");

                    b.HasKey("BusId")
                        .HasName("pk_d_Transports");

                    b.ToTable("d_Buses", (string)null);
                });

            modelBuilder.Entity("CarPark.Models.DCity", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CityID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Notes")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("CityId")
                        .HasName("pk_d_City");

                    b.ToTable("d_City", (string)null);
                });

            modelBuilder.Entity("CarPark.Models.DDriver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DriverID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriverId"));

                    b.Property<decimal?>("Experience")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("DriverId")
                        .HasName("pk_d_Drivers");

                    b.ToTable("d_Drivers", (string)null);
                });

            modelBuilder.Entity("CarPark.Models.DRoute", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RouteID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"));

                    b.Property<int>("Bcity")
                        .HasColumnType("int")
                        .HasColumnName("BCity");

                    b.Property<int>("Ecity")
                        .HasColumnType("int")
                        .HasColumnName("ECity");

                    b.Property<bool?>("IsWork")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("RouteLen")
                        .HasColumnType("int");

                    b.Property<int?>("RouteTime")
                        .HasColumnType("int");

                    b.HasKey("RouteId")
                        .HasName("pk_d_Routes");

                    b.HasIndex("Bcity");

                    b.HasIndex("Ecity");

                    b.ToTable("d_Routes", (string)null);
                });

            modelBuilder.Entity("CarPark.Models.TBill", b =>
                {
                    b.Property<int>("FlightsId")
                        .HasColumnType("int")
                        .HasColumnName("FlightsID");

                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BillID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ClientID");

                    b.HasKey("FlightsId")
                        .HasName("pk_t_Bills");

                    b.HasIndex("ClientId");

                    b.ToTable("t_Bills", (string)null);
                });

            modelBuilder.Entity("CarPark.Models.TFlight", b =>
                {
                    b.Property<int>("FlightsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FlightsID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightsId"));

                    b.Property<DateTime?>("BdateRoute")
                        .HasColumnType("date")
                        .HasColumnName("BDateRoute");

                    b.Property<TimeSpan?>("BtimeRoute")
                        .HasColumnType("time")
                        .HasColumnName("BTimeRoute");

                    b.Property<int>("BusId")
                        .HasColumnType("int")
                        .HasColumnName("BusID");

                    b.Property<int>("DriverId")
                        .HasColumnType("int")
                        .HasColumnName("DriverID");

                    b.Property<DateTime?>("EdateRoute")
                        .HasColumnType("date")
                        .HasColumnName("EDateRoute");

                    b.Property<TimeSpan?>("EtimeRoute")
                        .HasColumnType("time")
                        .HasColumnName("ETimeRoute");

                    b.Property<bool?>("IsCanselet")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsEnd")
                        .HasColumnType("bit");

                    b.Property<int>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("RouteID");

                    b.HasKey("FlightsId")
                        .HasName("pk_t_flights");

                    b.HasIndex("BusId");

                    b.HasIndex("DriverId");

                    b.HasIndex("RouteId");

                    b.ToTable("t_Flights", (string)null);
                });

            modelBuilder.Entity("CarPark.Models.TTrackingsBu", b =>
                {
                    b.Property<int>("TrackingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TrackingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackingId"));

                    b.Property<DateTime?>("Bdate")
                        .HasColumnType("date");

                    b.Property<int>("BusId")
                        .HasColumnType("int")
                        .HasColumnName("BusID");

                    b.Property<DateTime?>("Edate")
                        .HasColumnType("date");

                    b.Property<string>("Notes")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(12, 2)");

                    b.HasKey("TrackingId")
                        .HasName("pk_t_TrackingsTransports");

                    b.HasIndex("BusId");

                    b.ToTable("t_TrackingsBus", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarPark.Models.TClient", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("TClient");
                });

            modelBuilder.Entity("CarPark.Models.DRoute", b =>
                {
                    b.HasOne("CarPark.Models.DCity", "BcityNavigation")
                        .WithMany("DRouteBcityNavigations")
                        .HasForeignKey("Bcity")
                        .IsRequired()
                        .HasConstraintName("FK_BCity");

                    b.HasOne("CarPark.Models.DCity", "EcityNavigation")
                        .WithMany("DRouteEcityNavigations")
                        .HasForeignKey("Ecity")
                        .IsRequired()
                        .HasConstraintName("FK_Ectiy");

                    b.Navigation("BcityNavigation");

                    b.Navigation("EcityNavigation");
                });

            modelBuilder.Entity("CarPark.Models.TBill", b =>
                {
                    b.HasOne("CarPark.Models.TClient", "Client")
                        .WithMany("TBills")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_BillClient");

                    b.HasOne("CarPark.Models.TFlight", "Flights")
                        .WithOne("TBill")
                        .HasForeignKey("CarPark.Models.TBill", "FlightsId")
                        .IsRequired()
                        .HasConstraintName("FK_BillFlights");

                    b.Navigation("Client");

                    b.Navigation("Flights");
                });

            modelBuilder.Entity("CarPark.Models.TFlight", b =>
                {
                    b.HasOne("CarPark.Models.DBuse", "Bus")
                        .WithMany("TFlights")
                        .HasForeignKey("BusId")
                        .IsRequired()
                        .HasConstraintName("FK_BusFlights");

                    b.HasOne("CarPark.Models.DDriver", "Driver")
                        .WithMany("TFlights")
                        .HasForeignKey("DriverId")
                        .IsRequired()
                        .HasConstraintName("FK_Drivers");

                    b.HasOne("CarPark.Models.DRoute", "Route")
                        .WithMany("TFlights")
                        .HasForeignKey("RouteId")
                        .IsRequired()
                        .HasConstraintName("FK_Routes");

                    b.Navigation("Bus");

                    b.Navigation("Driver");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("CarPark.Models.TTrackingsBu", b =>
                {
                    b.HasOne("CarPark.Models.DBuse", "Bus")
                        .WithMany("TTrackingsBus")
                        .HasForeignKey("BusId")
                        .IsRequired()
                        .HasConstraintName("FK_Bus");

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarPark.Models.DBuse", b =>
                {
                    b.Navigation("TFlights");

                    b.Navigation("TTrackingsBus");
                });

            modelBuilder.Entity("CarPark.Models.DCity", b =>
                {
                    b.Navigation("DRouteBcityNavigations");

                    b.Navigation("DRouteEcityNavigations");
                });

            modelBuilder.Entity("CarPark.Models.DDriver", b =>
                {
                    b.Navigation("TFlights");
                });

            modelBuilder.Entity("CarPark.Models.DRoute", b =>
                {
                    b.Navigation("TFlights");
                });

            modelBuilder.Entity("CarPark.Models.TFlight", b =>
                {
                    b.Navigation("TBill");
                });

            modelBuilder.Entity("CarPark.Models.TClient", b =>
                {
                    b.Navigation("TBills");
                });
#pragma warning restore 612, 618
        }
    }
}