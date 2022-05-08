
using AutoMapper;
using GraduateProject.Common.DTOs.Department;
using GraduateProject.Common.DTOs.Doctor;
using GraduateProject.Common.DTOs.Hotel;
using GraduateProject.Common.DTOs.Lookups;
using GraduateProject.Common.DTOs.MedicalCenter;
using GraduateProject.Common.DTOs.PlaceToVisit;
using GraduateProject.Common.Models;
using GraduateProject.Common.Models.SysModels;
using GraduateProject.Common.ViewModels;

namespace Pal.Web.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Doctors

            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<DoctorTranslate, DoctorTranslateDTO>().ReverseMap();

            CreateMap<Doctor, DoctorViewModel>()
                .ForMember(dest => dest.Age, source => source.MapFrom(source => source.Birthday))
                .ReverseMap();
            #endregion

            #region Departments

            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<DepartmentTranslate, DepartmentTranslateDTO>().ReverseMap();

            #endregion

            #region SysCities

            CreateMap<SysCity, SysCityDTO>().ReverseMap();
            CreateMap<SysCityTranslate, SysCityTranslateDTO>().ReverseMap();

            #endregion

            #region SysRegions

            CreateMap<SysRegion, SysRegionDTO>().ReverseMap();
            CreateMap<SysRegionTranslate, SysRegionTranslateDTO>().ReverseMap();

            #endregion

            #region SysPlaceTypes

            CreateMap<SysPlaceType, SysPlaceTypeDTO>().ReverseMap();
            CreateMap<SysPlaceTypeTranslate, SysPlaceTypeTranslateDTO>().ReverseMap();

            #endregion


            #region Medical Centers

            CreateMap<MedicalCenter, MedicalCenterDTO>().ReverseMap();
            CreateMap<MedicalCenterTranslate, MedicalCenterTranslateDTO>().ReverseMap();

            #endregion

            #region Hotels

            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<HotelTranslate, HotelTranslateDTO>().ReverseMap();

            #endregion

            #region Places To Visit

            CreateMap<PlaceToVisit, PlaceToVisitDTO>().ReverseMap();
            CreateMap<PlaceToVisitTranslate, PlaceToVisitTranslateDTO>().ReverseMap();

            #endregion
        }

    }
}