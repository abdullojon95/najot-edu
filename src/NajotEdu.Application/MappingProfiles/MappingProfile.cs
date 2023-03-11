using AutoMapper;
using NajotEdu.Application.Models;
using NajotEdu.Domain.Entities;

namespace NajotEdu.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User,TeacherViewModel>();
            CreateMap<CreateTeacherModel,User>();
        }
    }
}
