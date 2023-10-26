﻿// <auto-generated />
using System;
using ABtesting.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ABtesting.Service.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231024080020_SqlServerInit")]
    partial class SqlServerInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ABtesting.Bll.Command.Device", b =>
                {
                    b.Property<Guid>("DeviceToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeviceToken");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ABtesting.Bll.Command.DevicesExperiment", b =>
                {
                    b.Property<Guid>("ExperimentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeviceToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExperimentId", "DeviceToken");

                    b.HasIndex("DeviceToken");

                    b.ToTable("DevicesExperiments");
                });

            modelBuilder.Entity("ABtesting.Bll.Command.Experiment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ChanceInPercents")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Experiments");
                });

            modelBuilder.Entity("ABtesting.Bll.Command.DevicesExperiment", b =>
                {
                    b.HasOne("ABtesting.Bll.Command.Device", "Device")
                        .WithMany("DevicesExperiments")
                        .HasForeignKey("DeviceToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ABtesting.Bll.Command.Experiment", "Experiment")
                        .WithMany("DevicesExperiments")
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Experiment");
                });

            modelBuilder.Entity("ABtesting.Bll.Command.Device", b =>
                {
                    b.Navigation("DevicesExperiments");
                });

            modelBuilder.Entity("ABtesting.Bll.Command.Experiment", b =>
                {
                    b.Navigation("DevicesExperiments");
                });
#pragma warning restore 612, 618
        }
    }
}