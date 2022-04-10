
using AutoMapper;
using GraduateProject.Common.DTOs;
using GraduateProject.Common.Models;

namespace Pal.Web.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<DoctorTranslate, DoctorTranslateDTO>().ReverseMap();
        }

    }
}