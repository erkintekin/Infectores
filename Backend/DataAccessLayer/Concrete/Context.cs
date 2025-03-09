using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.EntityLayer.Concrete;
using System.Security.Cryptography;

namespace Backend.DataAccessLayer.Concrete
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // First, create ItemTypes
            modelBuilder.Entity<ItemType>()
            .HasData(
                new ItemType { ItemTypeID = 1, Type = "Weapon" },
                new ItemType { ItemTypeID = 2, Type = "Armor" }
            );

            // Then create Items
            modelBuilder.Entity<Item>()
            .HasData(
                new Item
                {
                    ItemID = 1,
                    Name = "Sword",
                    GP = 10,
                    Description = "A sharp blade.",
                    ItemTypeID = 1,
                    ItemType = new ItemType { ItemTypeID = 1, Type = "Weapon" }
                },
                new Item
                {
                    ItemID = 2,
                    Name = "Shield",
                    GP = 15,
                    Description = "Protects against attacks.",
                    ItemTypeID = 2,
                    ItemType = new ItemType { ItemTypeID = 2, Type = "Armor" }
                }
            );

            // Create Misc items
            modelBuilder.Entity<Misc>()
            .HasData(
                new Misc
                {
                    MiscID = 1,
                    ItemID = 1,
                    Item = new Item
                    {
                        ItemID = 1,
                        Name = "Sword",
                        GP = 10,
                        Description = "A sharp blade.",
                        ItemTypeID = 1,
                        ItemType = new ItemType { ItemTypeID = 1, Type = "Weapon" }
                    }
                },
                new Misc
                {
                    MiscID = 2,
                    ItemID = 2,
                    Item = new Item
                    {
                        ItemID = 2,
                        Name = "Shield",
                        GP = 15,
                        Description = "Protects against attacks.",
                        ItemTypeID = 2,
                        ItemType = new ItemType { ItemTypeID = 2, Type = "Armor" }
                    }
                }
            );

            // Create ArmorTypes
            modelBuilder.Entity<ArmorType>()
            .HasData(
                new ArmorType { ArmorTypeID = 1, Type = "Light" }
            );

            // Create Armors
            modelBuilder.Entity<Armor>()
            .HasData(
                new Armor
                {
                    ArmorID = 1,
                    ArmorClass = 18,
                    ArmorTypeID = 1,
                    Item = new Item
                    {
                        ItemID = 2,
                        Name = "Shield",
                        GP = 15,
                        Description = "Protects against attacks.",
                        ItemTypeID = 2,
                        ItemType = new ItemType { ItemTypeID = 2, Type = "Armor" }
                    },
                    ArmorType = new ArmorType { ArmorTypeID = 1, Type = "Light" }
                }
            );

            // Create Users
            modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    UserID = 1,
                    Name = "Admin",
                    Surname = "User",
                    Email = "admin@infectores.com",
                    PasswordHash = "admin123",
                    IsAdmin = true
                },
                new User
                {
                    UserID = 2,
                    Name = "Test",
                    Surname = "User",
                    Email = "test@infectores.com",
                    PasswordHash = "test123",
                    IsAdmin = false
                }
            );

            // Create Proficiencies
            modelBuilder.Entity<Proficiency>()
            .HasData(
                new Proficiency { ProficiencyID = 1, Name = "Combat" },
                new Proficiency { ProficiencyID = 2, Name = "Magic" }
            );

            // Create Classes
            modelBuilder.Entity<Class>()
            .HasData(
                new Class
                {
                    ClassID = 1,
                    Name = "Wizard",
                    Speed = 30,
                    HitDice = "1d8",
                    ProficiencyID = 1
                },
                new Class
                {
                    ClassID = 2,
                    Name = "Fighter",
                    Speed = 25,
                    HitDice = "1d10",
                    ProficiencyID = 2
                }
            );

            // Create Tools
            modelBuilder.Entity<Tool>()
            .HasData(
                new Tool { ToolID = 1, Name = "Thieves' Tools" },
                new Tool { ToolID = 2, Name = "Herbalism Kit" }
            );

            // Create ProficiencyTools
            modelBuilder.Entity<ProficiencyTool>()
            .HasData(
                new ProficiencyTool
                {
                    ProficiencyID = 1,
                    ToolID = 1,
                    Proficiency = new Proficiency { ProficiencyID = 1, Name = "Combat" },
                    Tool = new Tool { ToolID = 1, Name = "Thieves' Tools" }
                },
                new ProficiencyTool
                {
                    ProficiencyID = 2,
                    ToolID = 2,
                    Proficiency = new Proficiency { ProficiencyID = 2, Name = "Magic" },
                    Tool = new Tool { ToolID = 2, Name = "Herbalism Kit" }
                }
            );
        }
    }

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<BonusAction> BonusActions { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Misc> Miscellaneous { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Sense> Senses { get; set; }
        public DbSet<Throw> Throws { get; set; }
        public DbSet<Proficiency> Proficiencies { get; set; }
        public DbSet<ProficiencyTool> ProficiencyTools { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<ArmorType> ArmorTypes { get; set; }
        public DbSet<DamageType> DamageTypes { get; set; }
        public DbSet<CharacterFeature> CharacterFeatures { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<CharacterSpell> CharacterSpells { get; set; }
        public DbSet<CharacterProficiency> CharacterProficiencies { get; set; }
        public DbSet<CharacterAbility> CharacterAbilities { get; set; }
        public DbSet<CharacterSenses> CharacterSenses { get; set; }
        public DbSet<CharacterThrow> CharacterThrows { get; set; }
        public DbSet<SpellComponent> SpellComponents { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<CharacterBonusAction> CharacterBonusActions { get; set; }
        public DbSet<CharacterLanguage> CharacterLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Inventory)
                .WithOne(i => i.Character)
                .HasForeignKey<Inventory>(i => i.CharacterID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Proficiency)
                .WithMany(p => p.Classes)
                .HasForeignKey(c => c.ProficiencyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProficiencyTool>()
                .HasKey(pt => new { pt.ProficiencyID, pt.ToolID });

            modelBuilder.Entity<ProficiencyTool>()
                .HasOne(pt => pt.Proficiency)
                .WithMany(p => p.ProficiencyTools)
                .HasForeignKey(pt => pt.ProficiencyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProficiencyTool>()
                .HasOne(pt => pt.Tool)
                .WithMany(t => t.ProficiencyTools)
                .HasForeignKey(pt => pt.ToolID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterThrow>()
                .HasKey(ct => new { ct.CharacterID, ct.ThrowID });

            modelBuilder.Entity<CharacterThrow>()
                .HasOne(ct => ct.Character)
                .WithMany(c => c.Throws)
                .HasForeignKey(ct => ct.CharacterID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterThrow>()
                .HasOne(ct => ct.Throw)
                .WithMany()
                .HasForeignKey(ct => ct.ThrowID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterSpell>()
                .HasKey(cs => new { cs.CharacterID, cs.SpellID });

            modelBuilder.Entity<CharacterSpell>()
                .HasOne(cs => cs.Character)
                .WithMany(c => c.Spells)
                .HasForeignKey(cs => cs.CharacterID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterSpell>()
                .HasOne(cs => cs.Spell)
                .WithMany()
                .HasForeignKey(cs => cs.SpellID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterSkill>()
                .HasKey(cs => new { cs.CharacterID, cs.SkillID });

            modelBuilder.Entity<CharacterSkill>()
                .HasOne(cs => cs.Character)
                .WithMany(c => c.Skills)
                .HasForeignKey(cs => cs.CharacterID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterSkill>()
                .HasOne(cs => cs.Skill)
                .WithMany()
                .HasForeignKey(cs => cs.SkillID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterAbility>()
                .HasKey(ca => new { ca.CharacterID, ca.AbilityID });

            modelBuilder.Entity<CharacterAbility>()
                .HasOne(ca => ca.Character)
                .WithMany(c => c.Abilities)
                .HasForeignKey(ca => ca.CharacterID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterAbility>()
                .HasOne(ca => ca.Ability)
                .WithMany()
                .HasForeignKey(ca => ca.AbilityID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Misc>()
                .HasOne(m => m.Item)
                .WithOne(i => i.Misc)
                .HasForeignKey<Misc>(m => m.ItemID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpellComponent>()
                .HasKey(sc => new { sc.SpellID, sc.ComponentID });

            modelBuilder.Entity<SpellComponent>()
                .HasOne(sc => sc.Spell)
                .WithMany(s => s.Components)
                .HasForeignKey(sc => sc.SpellID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpellComponent>()
                .HasOne(sc => sc.Component)
                .WithMany()
                .HasForeignKey(sc => sc.ComponentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterBonusAction>()
                .HasOne(cba => cba.Character)
                .WithMany(c => c.BonusActions)
                .HasForeignKey(cba => cba.CharacterID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BonusAction>()
                .HasMany<CharacterBonusAction>()
                .WithOne(cba => cba.BonusAction)
                .HasForeignKey(cba => cba.BonusActionID);

            modelBuilder.Entity<CharacterLanguage>()
                .HasKey(cl => new { cl.CharacterID, cl.LanguageID });

            modelBuilder.Entity<CharacterLanguage>()
                .HasOne(cl => cl.Character)
                .WithMany(c => c.Languages)
                .HasForeignKey(cl => cl.CharacterID);

            modelBuilder.Entity<Spell>()
                .HasOne(s => s.DamageType)
                .WithMany()
                .HasForeignKey(s => s.DamageTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}