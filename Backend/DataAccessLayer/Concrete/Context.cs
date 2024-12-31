using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Misc> Miscellaneous { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Sense> Senses { get; set; }
        public DbSet<Throw> Throws { get; set; }
        public DbSet<Proficiency> Proficiencies { get; set; }
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
        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkill>()
                .HasKey(cs => new { cs.CharacterID, cs.SkillID });

            modelBuilder.Entity<CharacterSpell>()
                .HasKey(cs => new { cs.CharacterID, cs.SpellID });

            modelBuilder.Entity<CharacterProficiency>()
                .HasKey(cp => new { cp.CharacterID, cp.ProficiencyID });

            modelBuilder.Entity<CharacterAbility>()
                .HasKey(ca => new { ca.CharacterID, ca.AbilityID });

            modelBuilder.Entity<CharacterSense>()
                .HasKey(cs => new { cs.CharacterID, cs.SenseID });

            modelBuilder.Entity<CharacterThrow>()
                .HasKey(ct => new { ct.CharacterID, ct.ThrowID });

            base.OnModelCreating(modelBuilder);
        }
    }
}