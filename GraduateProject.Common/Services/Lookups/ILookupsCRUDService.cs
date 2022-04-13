using GraduateProject.Common.DTOs.Department;
using GraduateProject.Common.DTOs.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.Lookups
{
    public interface ILookupsCRUDService
    {
        #region City

        Task<List<SysCityDTO>> GetSysCities();
        Task<List<SysCityDTO>> CityList();
        Task<SysCityDTO> AddCity(SysCityDTO model);
        Task<bool> DeleteCity(int id);
        Task<bool> UpdateCity(SysCityDTO model);

        #endregion

        // TODO Place Type

        #region Place Type

        Task<List<SysPlaceTypeDTO>> GetSysPlaceTypes();
        Task<List<SysPlaceTypeDTO>> PlaceTypesList();
        Task<SysPlaceTypeDTO> AddPlaceType(SysPlaceTypeDTO model);
        Task<bool> DeletePlaceType(int id);
        Task<bool> UpdatePlaceType(SysPlaceTypeDTO model);

        #endregion


        #region Department

        Task<List<DepartmentDTO>> GetSysDepartments();
        Task<List<DepartmentDTO>> DepartmentList();
        Task<DepartmentDTO> AddDepartment(DepartmentDTO model);
        Task<bool> DeleteDepartment(int id);
        Task<bool> UpdateDepartment(DepartmentDTO model);

        #endregion
    }
}
