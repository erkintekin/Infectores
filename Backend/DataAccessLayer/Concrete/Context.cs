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
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { ProficiencyID = 1, Name = "Combat" });
            modelBuilder.Entity<Class>().HasData(new Class { ClassID = 1, Name = "Wizard", Speed = 30, HitDice = "1d8", ProficiencyID = 1 });
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
        public DbSet<CharacterSense> CharacterSenses { get; set; }
        public DbSet<CharacterThrow> CharacterThrows { get; set; }
        public DbSet<SpellComponent> SpellComponents { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Inventory)
                .WithOne(i => i.Character)
                .HasForeignKey<Inventory>(i => i.CharacterID);

            modelBuilder.Entity<Class>()
            .HasOne(c => c.Proficiency)
            .WithMany(p => p.Classes) // Proficiency birden çok Class'a sahip
            .HasForeignKey(c => c.ProficiencyID);

            modelBuilder.Entity<ProficiencyTool>().HasKey(fk => new { fk.ProficiencyID, fk.ToolID }); // Composite Key

            modelBuilder.Entity<ProficiencyTool>()
            .HasOne(k => k.Proficiency)
            .WithMany(k => k.ProficiencyTools)
            .HasForeignKey(fk => fk.ProficiencyID);

            modelBuilder.Entity<ProficiencyTool>()
            .HasOne(o => o.Tool)
            .WithMany(m => m.ProficiencyTools)
            .HasForeignKey(fk => fk.ToolID);

            modelBuilder.Entity<CharacterThrow>()
            .HasKey(ct => new { ct.CharacterID, ct.ThrowID });

            modelBuilder.Entity<CharacterThrow>()
            .HasOne(ct => ct.Character)
            .WithMany(ct => ct.Throws)
            .HasForeignKey(ct => ct.CharacterID);

            modelBuilder.Entity<CharacterThrow>()
            .HasOne(ct => ct.Throw)
            .WithMany()
            .HasForeignKey(ct => ct.ThrowID);

            modelBuilder.Entity<CharacterSpell>()
            .HasKey(cs => new { cs.CharacterID, cs.SpellID });

            modelBuilder.Entity<CharacterSpell>()
            .HasOne(cs => cs.Character)
            .WithMany(cs => cs.Spells)
            .HasForeignKey(cs => cs.CharacterID);

            modelBuilder.Entity<CharacterSpell>()
            .HasOne(cs => cs.Spell)
            .WithMany()
            .HasForeignKey(cs => cs.SpellID);

            modelBuilder.Entity<CharacterSkill>()
            .HasKey(cs => new { cs.CharacterID, cs.SkillID });

            modelBuilder.Entity<CharacterSkill>()
            .HasOne(cs => cs.Character)
            .WithMany(cs => cs.Skills)
            .HasForeignKey(cs => cs.CharacterID);

            modelBuilder.Entity<CharacterSkill>()
            .HasOne(cs => cs.Skill)
            .WithMany()
            .HasForeignKey(cs => cs.SkillID);

            modelBuilder.Entity<CharacterAbility>()
            .HasKey(ca => new { ca.CharacterID, ca.AbilityID });

            modelBuilder.Entity<CharacterAbility>()
            .HasOne(ca => ca.Character)
            .WithMany(ca => ca.Abilities)
            .HasForeignKey(ca => ca.CharacterID);

            modelBuilder.Entity<CharacterAbility>()
            .HasOne(ca => ca.Ability)
            .WithMany()
            .HasForeignKey(ca => ca.AbilityID);

            modelBuilder.Entity<CharacterCondition>()
            .HasKey(cc => new { cc.CharacterID, cc.ConditionID });

            modelBuilder.Entity<CharacterCondition>()
            .HasOne(cc => cc.Character)
            .WithMany(cc => cc.Conditions)
            .HasForeignKey(cc => cc.CharacterID);

            modelBuilder.Entity<CharacterCondition>()
            .HasOne(cc => cc.Condition)
            .WithMany()
            .HasForeignKey(cc => cc.ConditionID);

            modelBuilder.Entity<CharacterFeature>()
            .HasKey(cf => new { cf.CharacterID, cf.FeatureID });

            modelBuilder.Entity<CharacterFeature>()
            .HasOne(cf => cf.Character)
            .WithMany(cf => cf.Features)
            .HasForeignKey(cf => cf.CharacterID);

            modelBuilder.Entity<CharacterFeature>()
            .HasOne(cf => cf.Feature)
            .WithMany()
            .HasForeignKey(cf => cf.FeatureID);

            modelBuilder.Entity<CharacterProficiency>()
            .HasKey(cp => new { cp.CharacterID, cp.ProficiencyID });

            modelBuilder.Entity<CharacterProficiency>()
            .HasOne(cp => cp.Character)
            .WithMany(cp => cp.Proficiencies)
            .HasForeignKey(cp => cp.CharacterID);

            modelBuilder.Entity<CharacterProficiency>()
            .HasOne(cp => cp.Proficiency)
            .WithMany()
            .HasForeignKey(cp => cp.ProficiencyID);

            modelBuilder.Entity<CharacterSense>()
            .HasKey(cp => new { cp.CharacterID, cp.SenseID });

            modelBuilder.Entity<CharacterSense>()
            .HasOne(cs => cs.Character)
            .WithMany(cs => cs.Senses)
            .HasForeignKey(cs => cs.CharacterID);

            modelBuilder.Entity<CharacterSense>()
            .HasOne(cs => cs.Sense)
            .WithMany()
            .HasForeignKey(cs => cs.SenseID);

            modelBuilder.Entity<Misc>()
            .HasKey(m => m.ItemID);

            modelBuilder.Entity<Misc>()
                .HasOne(m => m.Item)
                .WithOne(i => i.Misc) // Item tarafında da navigasyon tanımı
                .HasForeignKey<Misc>(m => m.ItemID);

            modelBuilder.Entity<Armor>().HasData(
                new Armor { Defense = 18, ArmorTypeID = 1, ItemID = 1 }
            );

            modelBuilder.Entity<SpellComponent>()
            .HasKey(sc => new { sc.SpellID, sc.ComponentID });

            modelBuilder.Entity<SpellComponent>()
            .HasOne(cp => cp.Spell)
            .WithMany(cp => cp.Components)
            .HasForeignKey(cp => cp.SpellID);

            modelBuilder.Entity<SpellComponent>()
            .HasOne(sp => sp.Component)
            .WithMany()
            .HasForeignKey(sp => sp.ComponentID);

            modelBuilder.Entity<Proficiency>()
            .HasData(new Proficiency { ProficiencyID = 1 });

            modelBuilder.Entity<Class>()
            .HasData(
                new Class { ClassID = 1, HitDice = "1d8", Name = "Wizard", ProficiencyID = 1, Speed = 30 });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();


        }

    }
}
