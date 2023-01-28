﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusiciansAbilities.Models;

#nullable disable

namespace MusiciansAbilities.Migrations
{
    [DbContext(typeof(DbResultsContext))]
    partial class DbResultsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusiciansAbilities.Models.ExperimentResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReactionTime")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExperimentResults");
                });

            modelBuilder.Entity("MusiciansAbilities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instrument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecretId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeSpentPracticing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MusiciansAbilities.Models.ExperimentResult", b =>
                {
                    b.HasOne("MusiciansAbilities.Models.User", null)
                        .WithMany("ExperimentResults")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MusiciansAbilities.Models.User", b =>
                {
                    b.Navigation("ExperimentResults");
                });
#pragma warning restore 612, 618
        }
    }
}
