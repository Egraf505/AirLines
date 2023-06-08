using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DB
{
    public partial class AirFligthsContext : DbContext
    {
        public AirFligthsContext()
        {
            Database.EnsureCreated();
        }

        public AirFligthsContext(DbContextOptions<AirFligthsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirCompany> AirCompanies { get; set; } = null!;
        public virtual DbSet<AirLine> AirLines { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AirFligths;Trusted_Connection=True;");
                optionsBuilder.UseSqlite("Data Source=airlights.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirCompany>(entity =>
            {
                entity.ToTable("air_company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tittle)
                    .HasMaxLength(50)
                    .HasColumnName("tittle");
            });

            modelBuilder.Entity<AirLine>(entity =>
            {
                entity.ToTable("air_lines");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityArrival).HasColumnName("city_arrival");

                entity.Property(e => e.CityDeparture).HasColumnName("city_departure");

                entity.Property(e => e.DatetimeArrival)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime_arrival");

                entity.Property(e => e.DatetimeDeparture)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime_departure");

                entity.Property(e => e.IdCompany).HasColumnName("id_company");

                entity.Property(e => e.IdPlanes).HasColumnName("id_planes");

                entity.HasOne(d => d.CityArrivalNavigation)
                    .WithMany(p => p.AirLineCityArrivalNavigations)
                    .HasForeignKey(d => d.CityArrival)
                    .HasConstraintName("FK__air_lines__city___44FF419A");

                entity.HasOne(d => d.CityDepartureNavigation)
                    .WithMany(p => p.AirLineCityDepartureNavigations)
                    .HasForeignKey(d => d.CityDeparture)
                    .HasConstraintName("FK__air_lines__city___440B1D61");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.AirLines)
                    .HasForeignKey(d => d.IdCompany)
                    .HasConstraintName("FK__air_lines__id_co__4222D4EF");

                entity.HasOne(d => d.IdPlanesNavigation)
                    .WithMany(p => p.AirLines)
                    .HasForeignKey(d => d.IdPlanes)
                    .HasConstraintName("FK__air_lines__id_pl__4316F928");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tittle)
                    .HasMaxLength(50)
                    .HasColumnName("tittle");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("plans");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.IdCompany).HasColumnName("id_company");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__plans__id_compan__3F466844");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("tickets");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAirLines).HasColumnName("id_air_lines");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.HasOne(d => d.IdAirLinesNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdAirLines)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tickets__id_air___45F365D3");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__tickets__id_user__38996AB5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(50)
                    .HasColumnName("middlename");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
