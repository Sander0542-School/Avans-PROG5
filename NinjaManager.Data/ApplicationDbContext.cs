using Microsoft.EntityFrameworkCore;
using NinjaManager.Data.Models;

namespace NinjaManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Gear> Gears { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gear>().HasIndex(gear => new {gear.Name, gear.Category}).IsUnique();

            modelBuilder.Entity<NinjaGear>()
                .HasKey(item => new {item.NinjaId, item.GearId});

            modelBuilder.Entity<NinjaGear>()
                .HasOne(ninjaGear => ninjaGear.Gear)
                .WithMany(gear => gear.NinjaGears)
                .HasForeignKey(ninjaGear => ninjaGear.GearId);

            modelBuilder.Entity<NinjaGear>()
                .HasOne(ninjaGear => ninjaGear.Ninja)
                .WithMany(ninja => ninja.NinjaGears)
                .HasForeignKey(ninjaGear => ninjaGear.NinjaId);

            #region Seeders

            #region GearSeeder

            modelBuilder.Entity<Gear>().HasData(
                new Gear
                {
                    Id = 1,
                    Name = "Iron Helmet",
                    Gold = 50,
                    Category = Gear.GearCategory.Head,
                    Strength = 10,
                    Intelligence = 10,
                    Agility = 100
                },
                new Gear
                {
                    Id = 2,
                    Name = "Gold Helmet",
                    Gold = 75,
                    Category = Gear.GearCategory.Head,
                    Strength = 50,
                    Intelligence = 50,
                    Agility = 50
                },
                new Gear
                {
                    Id = 3,
                    Name = "Diamond Helmet",
                    Gold = 100,
                    Category = Gear.GearCategory.Head,
                    Strength = 100,
                    Intelligence = 100,
                    Agility = 10
                },
                new Gear
                {
                    Id = 4,
                    Name = "Iron Necklace",
                    Gold = 50,
                    Category = Gear.GearCategory.Necklace,
                    Strength = 10,
                    Intelligence = 10,
                    Agility = 100
                },
                new Gear
                {
                    Id = 5,
                    Name = "Gold Necklace",
                    Gold = 75,
                    Category = Gear.GearCategory.Necklace,
                    Strength = 50,
                    Intelligence = 50,
                    Agility = 50
                },
                new Gear
                {
                    Id = 6,
                    Name = "Diamond Necklace",
                    Gold = 100,
                    Category = Gear.GearCategory.Necklace,
                    Strength = 100,
                    Intelligence = 100,
                    Agility = 10
                },
                new Gear
                {
                    Id = 7,
                    Name = "Iron Chest",
                    Gold = 50,
                    Category = Gear.GearCategory.Chest,
                    Strength = 10,
                    Intelligence = 10,
                    Agility = 100
                },
                new Gear
                {
                    Id = 8,
                    Name = "Gold Chest",
                    Gold = 75,
                    Category = Gear.GearCategory.Chest,
                    Strength = 50,
                    Intelligence = 50,
                    Agility = 50
                },
                new Gear
                {
                    Id = 9,
                    Name = "Diamond Chest",
                    Gold = 100,
                    Category = Gear.GearCategory.Chest,
                    Strength = 100,
                    Intelligence = 100,
                    Agility = 10
                },
                new Gear
                {
                    Id = 10,
                    Name = "Iron Gloves",
                    Gold = 50,
                    Category = Gear.GearCategory.Hand,
                    Strength = 10,
                    Intelligence = 10,
                    Agility = 100
                },
                new Gear
                {
                    Id = 11,
                    Name = "Gold Gloves",
                    Gold = 75,
                    Category = Gear.GearCategory.Hand,
                    Strength = 50,
                    Intelligence = 50,
                    Agility = 50
                },
                new Gear
                {
                    Id = 12,
                    Name = "Diamond Gloves",
                    Gold = 100,
                    Category = Gear.GearCategory.Hand,
                    Strength = 100,
                    Intelligence = 100,
                    Agility = 10
                },
                new Gear
                {
                    Id = 13,
                    Name = "Iron Ring",
                    Gold = 50,
                    Category = Gear.GearCategory.Ring,
                    Strength = 10,
                    Intelligence = 10,
                    Agility = 100
                },
                new Gear
                {
                    Id = 14,
                    Name = "Gold Ring",
                    Gold = 75,
                    Category = Gear.GearCategory.Ring,
                    Strength = 50,
                    Intelligence = 50,
                    Agility = 50
                },
                new Gear
                {
                    Id = 15,
                    Name = "Diamond Ring",
                    Gold = 100,
                    Category = Gear.GearCategory.Ring,
                    Strength = 100,
                    Intelligence = 100,
                    Agility = 10
                },
                new Gear
                {
                    Id = 16,
                    Name = "Iron Boots",
                    Gold = 50,
                    Category = Gear.GearCategory.Feet,
                    Strength = 10,
                    Intelligence = 10,
                    Agility = 100
                },
                new Gear
                {
                    Id = 17,
                    Name = "Gold Boots",
                    Gold = 75,
                    Category = Gear.GearCategory.Feet,
                    Strength = 50,
                    Intelligence = 50,
                    Agility = 50
                },
                new Gear
                {
                    Id = 18,
                    Name = "Diamond Boots",
                    Gold = 100,
                    Category = Gear.GearCategory.Feet,
                    Strength = 100,
                    Intelligence = 100,
                    Agility = 10
                }
            );

            #endregion

            #region NinjaSeeder

            modelBuilder.Entity<Ninja>().HasData(
                new Ninja
                {
                    Id = 1,
                    Name = "John Doe",
                    Gold = 600
                },
                new Ninja
                {
                    Id = 2,
                    Name = "Jane Doe",
                    Gold = 275
                }
            );

            #endregion

            #endregion
        }
    }
}