using AutoMapper;
using Backend.DTOs;
using Backend.EntityLayer.Concrete;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserCreateDTO, User>();
        CreateMap<UserUpdateDTO, User>();

        CreateMap<Skill, SkillDTO>();
        CreateMap<SkillCreateDTO, Skill>();
        CreateMap<SkillUpdateDTO, Skill>();
        CreateMap<CharacterSkill, CharacterSkillDTO>()
            .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.Skill.Name))
            .ForMember(dest => dest.AbilityName, opt => opt.MapFrom(src => src.Skill.Ability.AbilityName));
    }
}