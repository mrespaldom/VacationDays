﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacationsDays.Data;

#nullable disable

namespace VacationsDays.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("System.Collections.Generic.Dictionary<int, string>", b =>
                {
                    b.ToTable("Dictionary<int, string>");
                });

            modelBuilder.Entity("VacationsDays.Models.DayData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DayOfYear")
                        .HasColumnType("int");

                    b.Property<bool>("IsCheckedCH")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCheckedV")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DaysData");
                });

            modelBuilder.Entity("VacationsDays.Models.Vacation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlokedJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookedDays")
                        .HasColumnType("int");

                    b.Property<int>("ChDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("LegalVacYear")
                        .HasColumnType("int");

                    b.Property<int>("LegalVacYearBef")
                        .HasColumnType("int");

                    b.Property<int>("LegalVacYearBefH2")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RemainingDays")
                        .HasColumnType("int");

                    b.Property<int?>("SelectedDays")
                        .HasColumnType("int");

                    b.Property<int>("TotalDays")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VacTotalDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vacations");
                });
#pragma warning restore 612, 618
        }
    }
}
