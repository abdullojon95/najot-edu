using AutoMapper;
using NajotEdu.Application.Abstractions;
using NajotEdu.Application.Models;
using NajotEdu.Domain.Entities;
using NajotEdu.Domain.Enums;

namespace NajotEdu.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IHashProvider hashProvider)
        {
            CreateMap<User, TeacherViewModel>();
            CreateMap<CreateTeacherModel, User>()
                .ForMember(d => d.Role, o => o.MapFrom(s => UserRole.Teacher))
                .ForMember(d => d.PasswordHash, o => o.MapFrom(s => hashProvider.GetHash(s.Password)));
            CreateMap<UpdateTeacherModel, User>()
                .ForMember(d => d.PasswordHash, o => o.MapFrom(s => s.Password)).BeforeMap((model, entity, context) =>
                {
                    entity.PasswordHash = model.Password == null
                    ? entity.PasswordHash
                    : hashProvider.GetHash(model.Password);
                });
        }
    }
}
