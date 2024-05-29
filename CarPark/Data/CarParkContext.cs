using System;
using System.Collections.Generic;
using CarPark.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Data;

public partial class CarParkContext : IdentityDbContext<IdentityUser>
{
    public CarParkContext()
    {
    }

    public CarParkContext(DbContextOptions<CarParkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DBuse> DBuses { get; set; }

    public virtual DbSet<DCity> DCities { get; set; }

    public virtual DbSet<DDriver> DDrivers { get; set; }

    public virtual DbSet<DRoute> DRoutes { get; set; }

    public virtual DbSet<TBill> TBills { get; set; }

    public virtual DbSet<TClient> TClients { get; set; }

    public virtual DbSet<TFlight> TFlights { get; set; }

    public virtual DbSet<TTrackingsBu> TTrackingsBus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CarPark;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseCollation("Ukrainian_100_CI_AS");

        modelBuilder.Entity<DBuse>(entity =>
        {
            entity.HasKey(e => e.BusId).HasName("pk_d_Transports");

            entity.ToTable("d_Buses");

            entity.Property(e => e.BusId).HasColumnName("BusID");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Numer)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DCity>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("pk_d_City");

            entity.ToTable("d_City");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DDriver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("pk_d_Drivers");

            entity.ToTable("d_Drivers");

            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.Experience).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DRoute>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("pk_d_Routes");

            entity.ToTable("d_Routes");

            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.Bcity).HasColumnName("BCity");
            entity.Property(e => e.Ecity).HasColumnName("ECity");
            entity.Property(e => e.Notes)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.BcityNavigation).WithMany(p => p.DRouteBcityNavigations)
                .HasForeignKey(d => d.Bcity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BCity");

            entity.HasOne(d => d.EcityNavigation).WithMany(p => p.DRouteEcityNavigations)
                .HasForeignKey(d => d.Ecity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ectiy");
        });

        modelBuilder.Entity<TBill>(entity =>
        {
            entity.HasKey(e => e.FlightsId).HasName("pk_t_Bills");

            entity.ToTable("t_Bills");

            entity.Property(e => e.FlightsId)
                .ValueGeneratedNever()
                .HasColumnName("FlightsID");
            entity.Property(e => e.BillId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BillID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");

            entity.HasOne(d => d.Client).WithMany(p => p.TBills)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillClient");

            entity.HasOne(d => d.Flights).WithOne(p => p.TBill)
                .HasForeignKey<TBill>(d => d.FlightsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillFlights");
        });

        modelBuilder.Entity<TFlight>(entity =>
        {
            entity.HasKey(e => e.FlightsId).HasName("pk_t_flights");

            entity.ToTable("t_Flights");

            entity.Property(e => e.FlightsId).HasColumnName("FlightsID");
            entity.Property(e => e.BdateRoute)
                .HasColumnType("date")
                .HasColumnName("BDateRoute");
            entity.Property(e => e.BusId).HasColumnName("BusID");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.EdateRoute)
                .HasColumnType("date")
                .HasColumnName("EDateRoute");
            entity.Property(e => e.RouteId).HasColumnName("RouteID");

            entity.HasOne(d => d.Bus).WithMany(p => p.TFlights)
                .HasForeignKey(d => d.BusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BusFlights");

            entity.HasOne(d => d.Driver).WithMany(p => p.TFlights)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Drivers");

            entity.HasOne(d => d.Route).WithMany(p => p.TFlights)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Routes");
        });

        modelBuilder.Entity<TTrackingsBu>(entity =>
        {
            entity.HasKey(e => e.TrackingId).HasName("pk_t_TrackingsTransports");

            entity.ToTable("t_TrackingsBus");

            entity.Property(e => e.TrackingId).HasColumnName("TrackingID");
            entity.Property(e => e.Bdate).HasColumnType("date");
            entity.Property(e => e.BusId).HasColumnName("BusID");
            entity.Property(e => e.Edate).HasColumnType("date");
            entity.Property(e => e.Notes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Bus).WithMany(p => p.TTrackingsBus)
                .HasForeignKey(d => d.BusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
