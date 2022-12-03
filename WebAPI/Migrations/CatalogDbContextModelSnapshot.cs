﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI;

namespace WebAPI.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    partial class CatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.CelestialObject", b =>
                {
                    b.Property<int>("CelestialObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DiscoveryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscoverySourceId")
                        .HasColumnType("int");

                    b.Property<double>("EquatorialDiameter")
                        .HasColumnType("float");

                    b.Property<double>("Mass")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObjectTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SurfaceTemperature")
                        .HasColumnType("int");

                    b.HasKey("CelestialObjectId");

                    b.HasIndex("DiscoverySourceId");

                    b.HasIndex("ObjectTypeId");

                    b.ToTable("CelestialObject");
                });

            modelBuilder.Entity("WebAPI.Models.DiscoverySource", b =>
                {
                    b.Property<int>("DiscoverySourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscoverySourceTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EstablishmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateOwner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiscoverySourceId");

                    b.HasIndex("DiscoverySourceTypeId");

                    b.ToTable("DiscoverySource");

                    b.HasData(
                        new
                        {
                            DiscoverySourceId = 1,
                            DiscoverySourceTypeId = 1,
                            EstablishmentDate = new DateTime(1994, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Hubble Space Telescope",
                            StateOwner = "USA"
                        },
                        new
                        {
                            DiscoverySourceId = 2,
                            DiscoverySourceTypeId = 2,
                            EstablishmentDate = new DateTime(1960, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Arecibo Observatory",
                            StateOwner = "Puerto Rico"
                        },
                        new
                        {
                            DiscoverySourceId = 3,
                            DiscoverySourceTypeId = 2,
                            EstablishmentDate = new DateTime(1839, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pulkovo Observatory",
                            StateOwner = "Russia"
                        },
                        new
                        {
                            DiscoverySourceId = 4,
                            DiscoverySourceTypeId = 1,
                            EstablishmentDate = new DateTime(2013, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "NEOSSat",
                            StateOwner = "Canada"
                        },
                        new
                        {
                            DiscoverySourceId = 5,
                            DiscoverySourceTypeId = 1,
                            EstablishmentDate = new DateTime(2015, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Astrosat",
                            StateOwner = "India"
                        },
                        new
                        {
                            DiscoverySourceId = 6,
                            DiscoverySourceTypeId = 1,
                            EstablishmentDate = new DateTime(2011, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Spektr-R",
                            StateOwner = "Russia"
                        },
                        new
                        {
                            DiscoverySourceId = 7,
                            DiscoverySourceTypeId = 2,
                            EstablishmentDate = new DateTime(2011, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Subaru Telescope",
                            StateOwner = "Japan"
                        },
                        new
                        {
                            DiscoverySourceId = 8,
                            DiscoverySourceTypeId = 2,
                            EstablishmentDate = new DateTime(2011, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "ALMA",
                            StateOwner = "Chile"
                        },
                        new
                        {
                            DiscoverySourceId = 9,
                            DiscoverySourceTypeId = 2,
                            EstablishmentDate = new DateTime(1993, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Keck",
                            StateOwner = "USA"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.DiscoverySourceType", b =>
                {
                    b.Property<int>("DiscoverySourceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiscoverySourceTypeId");

                    b.ToTable("DiscoverySourceType");

                    b.HasData(
                        new
                        {
                            DiscoverySourceTypeId = 1,
                            Name = "Space telescope"
                        },
                        new
                        {
                            DiscoverySourceTypeId = 2,
                            Name = "Ground telescope"
                        },
                        new
                        {
                            DiscoverySourceTypeId = 3,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.ObjectType", b =>
                {
                    b.Property<int>("ObjectTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObjectTypeId");

                    b.ToTable("ObjectType");

                    b.HasData(
                        new
                        {
                            ObjectTypeId = 1,
                            Name = "Planet"
                        },
                        new
                        {
                            ObjectTypeId = 2,
                            Name = "Star"
                        },
                        new
                        {
                            ObjectTypeId = 3,
                            Name = "Black Hole"
                        },
                        new
                        {
                            ObjectTypeId = 4,
                            Name = "Unknown"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.CelestialObject", b =>
                {
                    b.HasOne("WebAPI.Models.DiscoverySource", "DiscoverySource")
                        .WithMany("CelestialObjects")
                        .HasForeignKey("DiscoverySourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.ObjectType", "ObjectType")
                        .WithMany("CelestialObjects")
                        .HasForeignKey("ObjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscoverySource");

                    b.Navigation("ObjectType");
                });

            modelBuilder.Entity("WebAPI.Models.DiscoverySource", b =>
                {
                    b.HasOne("WebAPI.Models.DiscoverySourceType", "DiscoverySourceType")
                        .WithMany("DiscoverySources")
                        .HasForeignKey("DiscoverySourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscoverySourceType");
                });

            modelBuilder.Entity("WebAPI.Models.DiscoverySource", b =>
                {
                    b.Navigation("CelestialObjects");
                });

            modelBuilder.Entity("WebAPI.Models.DiscoverySourceType", b =>
                {
                    b.Navigation("DiscoverySources");
                });

            modelBuilder.Entity("WebAPI.Models.ObjectType", b =>
                {
                    b.Navigation("CelestialObjects");
                });
#pragma warning restore 612, 618
        }
    }
}
