using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AbilityName = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityID);
                });

            migrationBuilder.CreateTable(
                name: "ArmorTypes",
                columns: table => new
                {
                    ArmorTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorTypes", x => x.ArmorTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentID);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    ConditionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.ConditionID);
                });

            migrationBuilder.CreateTable(
                name: "DamageTypes",
                columns: table => new
                {
                    DamageTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTypes", x => x.DamageTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeatureID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureID);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    ItemTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ItemTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Proficiencies",
                columns: table => new
                {
                    ProficiencyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proficiencies", x => x.ProficiencyID);
                });

            migrationBuilder.CreateTable(
                name: "Senses",
                columns: table => new
                {
                    SenseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senses", x => x.SenseID);
                });

            migrationBuilder.CreateTable(
                name: "Throws",
                columns: table => new
                {
                    ThrowID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Modifier = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Throws", x => x.ThrowID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Mail = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    HashedPassword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    WeaponTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.WeaponTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AbilityName = table.Column<string>(type: "text", nullable: false),
                    AbilityID = table.Column<int>(type: "integer", nullable: false),
                    Bonus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_Skills_Abilities_AbilityID",
                        column: x => x.AbilityID,
                        principalTable: "Abilities",
                        principalColumn: "AbilityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    SpellID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Damage = table.Column<string>(type: "text", nullable: false),
                    DamageTypeID = table.Column<int>(type: "integer", nullable: false),
                    HitDice = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Range = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    CastingTime = table.Column<string>(type: "text", nullable: false),
                    School = table.Column<string>(type: "text", nullable: true),
                    isCantrip = table.Column<bool>(type: "boolean", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.SpellID);
                    table.ForeignKey(
                        name: "FK_Spells_DamageTypes_DamageTypeID",
                        column: x => x.DamageTypeID,
                        principalTable: "DamageTypes",
                        principalColumn: "DamageTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GP = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ItemTypeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeID",
                        column: x => x.ItemTypeID,
                        principalTable: "ItemTypes",
                        principalColumn: "ItemTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Speed = table.Column<int>(type: "integer", nullable: false),
                    HitDice = table.Column<string>(type: "text", nullable: false),
                    ProficiencyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_Classes_Proficiencies_ProficiencyID",
                        column: x => x.ProficiencyID,
                        principalTable: "Proficiencies",
                        principalColumn: "ProficiencyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProficiencyID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageID);
                    table.ForeignKey(
                        name: "FK_Languages_Proficiencies_ProficiencyID",
                        column: x => x.ProficiencyID,
                        principalTable: "Proficiencies",
                        principalColumn: "ProficiencyID");
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    ToolID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProficiencyID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.ToolID);
                    table.ForeignKey(
                        name: "FK_Tools_Proficiencies_ProficiencyID",
                        column: x => x.ProficiencyID,
                        principalTable: "Proficiencies",
                        principalColumn: "ProficiencyID");
                });

            migrationBuilder.CreateTable(
                name: "SpellComponents",
                columns: table => new
                {
                    SpellComponentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpellID = table.Column<int>(type: "integer", nullable: false),
                    ComponentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellComponents", x => x.SpellComponentID);
                    table.ForeignKey(
                        name: "FK_SpellComponents_Components_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "Components",
                        principalColumn: "ComponentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellComponents_Spells_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spells",
                        principalColumn: "SpellID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "integer", nullable: false),
                    Defense = table.Column<int>(type: "integer", nullable: false),
                    ArmorTypeID = table.Column<int>(type: "integer", nullable: false),
                    ProficiencyID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Armors_ArmorTypes_ArmorTypeID",
                        column: x => x.ArmorTypeID,
                        principalTable: "ArmorTypes",
                        principalColumn: "ArmorTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Armors_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Armors_Proficiencies_ProficiencyID",
                        column: x => x.ProficiencyID,
                        principalTable: "Proficiencies",
                        principalColumn: "ProficiencyID");
                });

            migrationBuilder.CreateTable(
                name: "Miscellaneous",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miscellaneous", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Miscellaneous_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "integer", nullable: false),
                    Damage = table.Column<int>(type: "integer", nullable: false),
                    DamageTypeID = table.Column<int>(type: "integer", nullable: false),
                    WeaponTypeID = table.Column<int>(type: "integer", nullable: false),
                    Range = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    ProficiencyID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Weapons_DamageTypes_DamageTypeID",
                        column: x => x.DamageTypeID,
                        principalTable: "DamageTypes",
                        principalColumn: "DamageTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weapons_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weapons_Proficiencies_ProficiencyID",
                        column: x => x.ProficiencyID,
                        principalTable: "Proficiencies",
                        principalColumn: "ProficiencyID");
                    table.ForeignKey(
                        name: "FK_Weapons_WeaponTypes_WeaponTypeID",
                        column: x => x.WeaponTypeID,
                        principalTable: "WeaponTypes",
                        principalColumn: "WeaponTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    XP = table.Column<int>(type: "integer", nullable: false),
                    InventoryID = table.Column<int>(type: "integer", nullable: false),
                    IsMOB = table.Column<bool>(type: "boolean", nullable: true),
                    IsNPC = table.Column<bool>(type: "boolean", nullable: true),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK_Characters_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonusActions",
                columns: table => new
                {
                    BonusActionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActionName = table.Column<string>(type: "text", nullable: false),
                    SpellID = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CharacterID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusActions", x => x.BonusActionID);
                    table.ForeignKey(
                        name: "FK_BonusActions_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID");
                    table.ForeignKey(
                        name: "FK_BonusActions_Spells_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spells",
                        principalColumn: "SpellID");
                });

            migrationBuilder.CreateTable(
                name: "CharacterAbilities",
                columns: table => new
                {
                    CharacterAbilityID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterID = table.Column<int>(type: "integer", nullable: false),
                    AbilityID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAbilities", x => x.CharacterAbilityID);
                    table.ForeignKey(
                        name: "FK_CharacterAbilities_Abilities_AbilityID",
                        column: x => x.AbilityID,
                        principalTable: "Abilities",
                        principalColumn: "AbilityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterAbilities_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterCondition",
                columns: table => new
                {
                    CharacterConditionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterID = table.Column<int>(type: "integer", nullable: false),
                    ConditionID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterCondition", x => x.CharacterConditionID);
                    table.ForeignKey(
                        name: "FK_CharacterCondition_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterCondition_Conditions_ConditionID",
                        column: x => x.ConditionID,
                        principalTable: "Conditions",
                        principalColumn: "ConditionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFeatures",
                columns: table => new
                {
                    CharacterFeatureID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterID = table.Column<int>(type: "integer", nullable: false),
                    FeatureID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFeatures", x => x.CharacterFeatureID);
                    table.ForeignKey(
                        name: "FK_CharacterFeatures_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterFeatures_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "FeatureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterProficiencies",
                columns: table => new
                {
                    CharacterProficiencyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterID = table.Column<int>(type: "integer", nullable: false),
                    ProficiencyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterProficiencies", x => x.CharacterProficiencyID);
                    table.ForeignKey(
                        name: "FK_CharacterProficiencies_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterProficiencies_Proficiencies_ProficiencyID",
                        column: x => x.ProficiencyID,
                        principalTable: "Proficiencies",
                        principalColumn: "ProficiencyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSenses",
                columns: table => new
                {
                    CharacterSensesID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterID = table.Column<int>(type: "integer", nullable: false),
                    SenseID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSenses", x => x.CharacterSensesID);
                    table.ForeignKey(
                        name: "FK_CharacterSenses_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSenses_Senses_SenseID",
                        column: x => x.SenseID,
                        principalTable: "Senses",
                        principalColumn: "SenseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    CharacterSkillID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterID = table.Column<int>(type: "integer", nullable: false),
                    SkillID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => x.CharacterSkillID);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSpells",
                columns: table => new
                {
                    CharacterSpellID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterID = table.Column<int>(type: "integer", nullable: false),
                    SpellID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSpells", x => x.CharacterSpellID);
                    table.ForeignKey(
                        name: "FK_CharacterSpells_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSpells_Spells_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spells",
                        principalColumn: "SpellID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterThrows",
                columns: table => new
                {
                    CharacterThrowID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterID = table.Column<int>(type: "integer", nullable: false),
                    ThrowID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterThrows", x => x.CharacterThrowID);
                    table.ForeignKey(
                        name: "FK_CharacterThrows_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterThrows_Throws_ThrowID",
                        column: x => x.ThrowID,
                        principalTable: "Throws",
                        principalColumn: "ThrowID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventories_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    InventoryItemID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryID = table.Column<int>(type: "integer", nullable: false),
                    ItemID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.InventoryItemID);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armors_ArmorTypeID",
                table: "Armors",
                column: "ArmorTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Armors_ProficiencyID",
                table: "Armors",
                column: "ProficiencyID");

            migrationBuilder.CreateIndex(
                name: "IX_BonusActions_CharacterID",
                table: "BonusActions",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_BonusActions_SpellID",
                table: "BonusActions",
                column: "SpellID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbilities_AbilityID",
                table: "CharacterAbilities",
                column: "AbilityID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbilities_CharacterID",
                table: "CharacterAbilities",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCondition_CharacterID",
                table: "CharacterCondition",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCondition_ConditionID",
                table: "CharacterCondition",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFeatures_CharacterID",
                table: "CharacterFeatures",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFeatures_FeatureID",
                table: "CharacterFeatures",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterProficiencies_CharacterID",
                table: "CharacterProficiencies",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterProficiencies_ProficiencyID",
                table: "CharacterProficiencies",
                column: "ProficiencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassID",
                table: "Characters",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserID",
                table: "Characters",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSenses_CharacterID",
                table: "CharacterSenses",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSenses_SenseID",
                table: "CharacterSenses",
                column: "SenseID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_CharacterID",
                table: "CharacterSkills",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillID",
                table: "CharacterSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpells_CharacterID",
                table: "CharacterSpells",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpells_SpellID",
                table: "CharacterSpells",
                column: "SpellID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterThrows_CharacterID",
                table: "CharacterThrows",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterThrows_ThrowID",
                table: "CharacterThrows",
                column: "ThrowID");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ProficiencyID",
                table: "Classes",
                column: "ProficiencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CharacterID",
                table: "Inventories",
                column: "CharacterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_InventoryID",
                table: "InventoryItems",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ItemID",
                table: "InventoryItems",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeID",
                table: "Items",
                column: "ItemTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ProficiencyID",
                table: "Languages",
                column: "ProficiencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AbilityID",
                table: "Skills",
                column: "AbilityID");

            migrationBuilder.CreateIndex(
                name: "IX_SpellComponents_ComponentID",
                table: "SpellComponents",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_SpellComponents_SpellID",
                table: "SpellComponents",
                column: "SpellID");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_DamageTypeID",
                table: "Spells",
                column: "DamageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ProficiencyID",
                table: "Tools",
                column: "ProficiencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_DamageTypeID",
                table: "Weapons",
                column: "DamageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_ProficiencyID",
                table: "Weapons",
                column: "ProficiencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WeaponTypeID",
                table: "Weapons",
                column: "WeaponTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "BonusActions");

            migrationBuilder.DropTable(
                name: "CharacterAbilities");

            migrationBuilder.DropTable(
                name: "CharacterCondition");

            migrationBuilder.DropTable(
                name: "CharacterFeatures");

            migrationBuilder.DropTable(
                name: "CharacterProficiencies");

            migrationBuilder.DropTable(
                name: "CharacterSenses");

            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "CharacterSpells");

            migrationBuilder.DropTable(
                name: "CharacterThrows");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Miscellaneous");

            migrationBuilder.DropTable(
                name: "SpellComponents");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "ArmorTypes");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Senses");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Throws");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "WeaponTypes");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "DamageTypes");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Proficiencies");
        }
    }
}
