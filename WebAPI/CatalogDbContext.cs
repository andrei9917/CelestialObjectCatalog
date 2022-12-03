using System;
using Microsoft.EntityFrameworkCore;
using WebAPI.Constants;
using WebAPI.Models;

namespace WebAPI
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<DiscoverySourceType> DiscoverySourceType { get; set; }
        public DbSet<ObjectType> ObjectType { get; set; }
        public DbSet<DiscoverySource> DiscoverySource { get; set; }
        public DbSet<CelestialObject> CelestialObject { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///// Insert ObjectTypes /////
            modelBuilder.Entity<ObjectType>().HasData(new ObjectType 
                { ObjectTypeId = (int)ObjectTypes.Planet, 
                    Name = "Planet"});

            modelBuilder.Entity<ObjectType>().HasData(new ObjectType 
                { ObjectTypeId = (int)ObjectTypes.Star, 
                    Name = "Star" });

            modelBuilder.Entity<ObjectType>().HasData(new ObjectType 
                { ObjectTypeId = (int)ObjectTypes.BlackHole, 
                    Name = "Black Hole" });

            modelBuilder.Entity<ObjectType>().HasData(new ObjectType
            {
                ObjectTypeId = (int)ObjectTypes.Unknown,
                Name = "Unknown"
            });


            ///// Insert DiscoverySourceTypes /////
            modelBuilder.Entity<DiscoverySourceType>().HasData(new DiscoverySourceType 
                { DiscoverySourceTypeId = (int)DiscoverySourceTypes.SpaceTelescope, 
                    Name = "Space telescope" });

            modelBuilder.Entity<DiscoverySourceType>().HasData(new DiscoverySourceType 
                { DiscoverySourceTypeId = (int)DiscoverySourceTypes.GroundTelescope, 
                    Name = "Ground telescope" });

            modelBuilder.Entity<DiscoverySourceType>().HasData(new DiscoverySourceType 
                { DiscoverySourceTypeId = (int)DiscoverySourceTypes.Other, 
                    Name = "Other" });


            ///// DiscoverySources mock data /////
            modelBuilder.Entity<DiscoverySource>().HasData(new DiscoverySource
            {
                DiscoverySourceId = 1,
                Name = "Hubble Space Telescope",
                EstablishmentDate = new DateTime(1994, 04, 25),
                DiscoverySourceTypeId = 1,
                StateOwner = "USA"
            });

            modelBuilder.Entity<DiscoverySource>().HasData(new DiscoverySource
            {
                DiscoverySourceId = 2,
                Name = "Arecibo Observatory",
                EstablishmentDate = new DateTime(1960, 06, 01),
                DiscoverySourceTypeId = 2,
                StateOwner = "Puerto Rico"
            });

            modelBuilder.Entity<DiscoverySource>().HasData(new DiscoverySource
            {
                DiscoverySourceId = 3,
                Name = "Pulkovo Observatory",
                EstablishmentDate = new DateTime(1839, 08, 07),
                DiscoverySourceTypeId = 2,
                StateOwner = "Russia"
            });

            modelBuilder.Entity<DiscoverySource>().HasData(new DiscoverySource
            {
                DiscoverySourceId = 4,
                Name = "NEOSSat",
                EstablishmentDate = new DateTime(2013, 02, 25),
                DiscoverySourceTypeId = 1,
                StateOwner = "Canada"
            });

            modelBuilder.Entity<DiscoverySource>().HasData(new DiscoverySource
            {
                DiscoverySourceId = 5,
                Name = "Astrosat",
                EstablishmentDate = new DateTime(2015, 09, 28),
                DiscoverySourceTypeId = 1,
                StateOwner = "India"
            });

            modelBuilder.Entity<DiscoverySource>().HasData(new DiscoverySource
            {
                DiscoverySourceId = 6,
                Name = "Spektr-R",
                EstablishmentDate = new DateTime(2011, 07, 18),
                DiscoverySourceTypeId = 1,
                StateOwner = "Russia"
            });

            modelBuilder.Entity<DiscoverySource>().HasData(new DiscoverySource
            {
                DiscoverySourceId = 7,
                Name = "Subaru Telescope",
                EstablishmentDate = new DateTime(2011, 07, 18),
                DiscoverySourceTypeId = 2,
                StateOwner = "Japan"
            });

            modelBuilder.Entity<DiscoverySource>().HasData(new DiscoverySource
            {
                DiscoverySourceId = 8,
                Name = "ALMA",
                EstablishmentDate = new DateTime(2011, 06, 15),
                DiscoverySourceTypeId = 2,
                StateOwner = "Chile"
            });

            modelBuilder.Entity<DiscoverySource>().HasData(new DiscoverySource
            {
                DiscoverySourceId = 9,
                Name = "Keck",
                EstablishmentDate = new DateTime(1993, 11, 24),
                DiscoverySourceTypeId = 2,
                StateOwner = "USA"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
