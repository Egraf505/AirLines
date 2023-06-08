﻿// <auto-generated />
using System;
using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DB.Migrations
{
    [DbContext(typeof(AirFligthsContext))]
    [Migration("20230418193733_changeHistory")]
    partial class changeHistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DB.AirCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("tittle");

                    b.HasKey("Id");

                    b.ToTable("air_company", (string)null);
                });

            modelBuilder.Entity("DB.AirLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CityArrival")
                        .HasColumnType("int")
                        .HasColumnName("city_arrival");

                    b.Property<int?>("CityDeparture")
                        .HasColumnType("int")
                        .HasColumnName("city_departure");

                    b.Property<DateTime?>("DatetimeArrival")
                        .HasColumnType("datetime")
                        .HasColumnName("datetime_arrival");

                    b.Property<DateTime?>("DatetimeDeparture")
                        .HasColumnType("datetime")
                        .HasColumnName("datetime_departure");

                    b.Property<int?>("IdCompany")
                        .HasColumnType("int")
                        .HasColumnName("id_company");

                    b.Property<int?>("IdPlanes")
                        .HasColumnType("int")
                        .HasColumnName("id_planes");

                    b.HasKey("Id");

                    b.HasIndex("CityArrival");

                    b.HasIndex("CityDeparture");

                    b.HasIndex("IdCompany");

                    b.HasIndex("IdPlanes");

                    b.ToTable("air_lines", (string)null);
                });

            modelBuilder.Entity("DB.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("tittle");

                    b.HasKey("Id");

                    b.ToTable("city", (string)null);
                });

            modelBuilder.Entity("DB.Model.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CityArrive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityDeparture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateArrive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateDeparture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleOfTicket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("DB.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Distance")
                        .HasColumnType("int")
                        .HasColumnName("distance");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int")
                        .HasColumnName("id_company");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("plans", (string)null);
                });

            modelBuilder.Entity("DB.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdAirLines")
                        .HasColumnType("int")
                        .HasColumnName("id_air_lines");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("IdAirLines");

                    b.HasIndex("IdUser");

                    b.ToTable("tickets", (string)null);
                });

            modelBuilder.Entity("DB.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastname");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("login");

                    b.Property<string>("Middlename")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("middlename");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DB.AirLine", b =>
                {
                    b.HasOne("DB.City", "CityArrivalNavigation")
                        .WithMany("AirLineCityArrivalNavigations")
                        .HasForeignKey("CityArrival")
                        .HasConstraintName("FK__air_lines__city___44FF419A");

                    b.HasOne("DB.City", "CityDepartureNavigation")
                        .WithMany("AirLineCityDepartureNavigations")
                        .HasForeignKey("CityDeparture")
                        .HasConstraintName("FK__air_lines__city___440B1D61");

                    b.HasOne("DB.AirCompany", "IdCompanyNavigation")
                        .WithMany("AirLines")
                        .HasForeignKey("IdCompany")
                        .HasConstraintName("FK__air_lines__id_co__4222D4EF");

                    b.HasOne("DB.Plan", "IdPlanesNavigation")
                        .WithMany("AirLines")
                        .HasForeignKey("IdPlanes")
                        .HasConstraintName("FK__air_lines__id_pl__4316F928");

                    b.Navigation("CityArrivalNavigation");

                    b.Navigation("CityDepartureNavigation");

                    b.Navigation("IdCompanyNavigation");

                    b.Navigation("IdPlanesNavigation");
                });

            modelBuilder.Entity("DB.Plan", b =>
                {
                    b.HasOne("DB.AirCompany", "IdCompanyNavigation")
                        .WithMany("Plans")
                        .HasForeignKey("IdCompany")
                        .IsRequired()
                        .HasConstraintName("FK__plans__id_compan__3F466844");

                    b.Navigation("IdCompanyNavigation");
                });

            modelBuilder.Entity("DB.Ticket", b =>
                {
                    b.HasOne("DB.AirLine", "IdAirLinesNavigation")
                        .WithMany("Tickets")
                        .HasForeignKey("IdAirLines")
                        .IsRequired()
                        .HasConstraintName("FK__tickets__id_air___45F365D3");

                    b.HasOne("DB.User", "IdUserNavigation")
                        .WithMany("Tickets")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__tickets__id_user__38996AB5");

                    b.Navigation("IdAirLinesNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("DB.AirCompany", b =>
                {
                    b.Navigation("AirLines");

                    b.Navigation("Plans");
                });

            modelBuilder.Entity("DB.AirLine", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("DB.City", b =>
                {
                    b.Navigation("AirLineCityArrivalNavigations");

                    b.Navigation("AirLineCityDepartureNavigations");
                });

            modelBuilder.Entity("DB.Plan", b =>
                {
                    b.Navigation("AirLines");
                });

            modelBuilder.Entity("DB.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
