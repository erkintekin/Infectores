using AutoMapper;
using Backend.DTOs;
using Backend.EntityLayer.Concrete;

namespace Backend.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Character, CharacterDTO>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name))
                .ReverseMap();

            CreateMap<CharacterAbility, CharacterAbilityDTO>()
                .ForMember(dest => dest.AbilityName, opt => opt.MapFrom(src => src.Ability.AbilityName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Ability.Description))
                .ReverseMap();

            CreateMap<CharacterSkill, CharacterSkillDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Skill.Name))
                .ForMember(dest => dest.AbilityName, opt => opt.MapFrom(src => src.Skill.AbilityName))
                .ReverseMap();

            CreateMap<Inventory, InventoryDTO>().ReverseMap();

            CreateMap<InventoryItem, InventoryItemDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Item.Description))
                .ForMember(dest => dest.GP, opt => opt.MapFrom(src => src.Item.GP))
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.Item.ItemType.Type))
                .ReverseMap();

            CreateMap<Spell, SpellDTO>()
                .ForMember(dest => dest.DamageType, opt => opt.MapFrom(src => src.DamageType.Type))
                .ForMember(dest => dest.Components, opt => opt.MapFrom(src => src.Components.Select(c => c.Component.Name)))
                .ReverseMap();
        }
    }
}