using AutoMapper;
using Backend.DTOs;
using Backend.EntityLayer.Concrete;

namespace Backend.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // Character mappings
            CreateMap<Character, CharacterDTO>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class == null ? string.Empty : src.Class.Name));
            CreateMap<CharacterCreateDTO, Character>();
            CreateMap<CharacterUpdateDTO, Character>();

            // Item mappings
            CreateMap<Item, ItemDTO>()
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.ItemType == null ? string.Empty : src.ItemType.Type));
            CreateMap<ItemCreateDTO, Item>();
            CreateMap<ItemUpdateDTO, Item>();

            // Spell mappings
            CreateMap<Spell, SpellDTO>()
                .ForMember(dest => dest.DamageType, opt => opt.MapFrom(src => src.DamageType == null ? string.Empty : src.DamageType.Type))
                .ForMember(dest => dest.Components, opt => opt.MapFrom(src => src.Components == null ? new List<string>() :
                    src.Components.Select(c => c.Component == null ? string.Empty : c.Component.Name).ToList()));
            CreateMap<SpellCreateDTO, Spell>();
            CreateMap<SpellUpdateDTO, Spell>();

            // Class mappings
            CreateMap<Class, ClassDTO>();
            CreateMap<ClassCreateDTO, Class>();
            CreateMap<ClassUpdateDTO, Class>();

            // User mappings
            CreateMap<User, UserDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Existing mappings
            CreateMap<CharacterAbility, CharacterAbilityDTO>()
                .ForMember(dest => dest.AbilityName, opt => opt.MapFrom(src => src.Ability == null ? string.Empty : src.Ability.AbilityName));
            CreateMap<CharacterSkill, CharacterSkillDTO>()
                .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.Skill == null ? string.Empty : src.Skill.Name));
            CreateMap<Inventory, InventoryDTO>();
            CreateMap<InventoryItem, InventoryItemDTO>();
        }
    }
}