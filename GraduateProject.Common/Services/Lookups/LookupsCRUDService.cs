using AutoMapper;
using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.Department;
using GraduateProject.Common.DTOs.Lookups;
using GraduateProject.Common.Models;
using GraduateProject.Common.Models.SysModels;
using GraduateProject.Common.Services.Languages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.Lookups
{
    public class LookupsCRUDService : ILookupsCRUDService
    {
        #region Fields and Ctor

        private readonly ILanguageService _languageService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _autoMapper;
        public LookupsCRUDService(ApplicationDbContext context, ILanguageService languageService, IMapper autoMapper)
        {
            _context = context;
            _languageService = languageService;
            _autoMapper = autoMapper;
        }

        #endregion


        #region City

        public async Task<SysCityDTO> AddCity(SysCityDTO model)
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                var newId = await _context.SysCities.AnyAsync() ? await _context.SysCities.MaxAsync(a => a.Id) + 1 : 1;
                model.Id = newId;
                SysCity sysCity = _autoMapper.Map<SysCity>(model);
                sysCity.Translates = model.Translates.Select(t => new SysCityTranslate
                {
                    CityId = newId,
                    Name = t.Name,
                    LanguageId = t.LanguageId
                }).ToList();

                await _context.AddAsync(sysCity);
                await _context.SaveChangesAsync();
                
                model.Translates.ForEach(t =>
                {
                    t.Id = sysCity.Translates.Where(tran => tran.LanguageId == t.LanguageId).FirstOrDefault().Id;
                });
                return model;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<SysCityDTO>> CityList()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<SysCityDTO> result = await _context.SysCities.Select(a => new SysCityDTO
                {
                    Id = a.Id,
                    Name = a.Translates.FirstOrDefault(a => a.LanguageId == langId).Name,
                    
                    Translates = a.Translates.Select(t => new SysCityTranslateDTO
                    {
                        Id = t.Id,
                        CityId = t.CityId,
                        LanguageId = t.LanguageId,
                        Name = t.Name,
                    }).ToList()

                }).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCity(int id)
        {
            try
            {
                if (await _context.Doctors.AnyAsync(a => a.CityId == id) 
                        || await _context.MedicalCenters.AnyAsync(a => a.CityId == id)
                        || await _context.Hotels.AnyAsync(a => a.CityId == id) 
                        || await _context.PlaceToVisits.AnyAsync(a => a.CityId == id))

                    return false;


                var model = await _context.SysCities.FirstOrDefaultAsync(a => a.Id == id);
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<SysCityDTO>> GetSysCities()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();

            return await _context.SysCities.Select(x => new SysCityDTO
            {
                Id = x.Id,
                Name = x.Translates.FirstOrDefault(x => x.LanguageId == langId).Name

            }).ToListAsync();
        }

        public async Task<bool> UpdateCity(SysCityDTO model)
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                var sysCity = _autoMapper.Map<SysCity>(model);
                sysCity.Translates = model.Translates.Select(a => new SysCityTranslate
                {
                    Id = a.Id,
                    CityId = model.Id,
                    Name = a.Name,
                    LanguageId = a.LanguageId,
                }).ToList();
                _context.Update(sysCity);
                await _context.SaveChangesAsync();
                model.Translates.ForEach(t =>
                {
                    t.Id = sysCity.Translates.Where(tran => tran.LanguageId == t.LanguageId).FirstOrDefault().Id;
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<SysCityDTO> GetCityById(int id)
        {
            try
            {
                var city = await _context.SysCities.Include(d => d.Translates).FirstOrDefaultAsync(d => d.Id == id);
                if (city == null)
                    return null;
                SysCityDTO model = _autoMapper.Map<SysCityDTO>(city);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Region

        public async Task<List<SysRegionDTO>> GetSysRegions()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();

            return await _context.SysRegions.Select(x => new SysRegionDTO
            {
                Id = x.Id,
                Name = x.Translates.FirstOrDefault(x => x.LanguageId == langId).Name

            }).ToListAsync();
        }
        public async Task<List<SysRegionDTO>> RegionList()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<SysRegionDTO> result = await _context.SysRegions.Select(a => new SysRegionDTO
                {
                    Id = a.Id,
                    Name = a.Translates.FirstOrDefault(a => a.LanguageId == langId).Name,
                    CityId = a.CityId,
                    CityName = a.SysCity.Translates.FirstOrDefault(t => t.LanguageId == langId).Name,

                    Translates = a.Translates.Select(t => new SysRegionTranslateDTO
                    {
                        Id = t.Id,
                        RegionId = t.RegionId,
                        LanguageId = t.LanguageId,
                        Name = t.Name,
                    }).ToList()

                }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<SysRegionDTO> GetRegionById(int id)
        {
            try
            {
                var region = await _context.SysRegions.Include(d => d.Translates).FirstOrDefaultAsync(d => d.Id == id);
                if (region == null)
                    return null;
                SysRegionDTO model = _autoMapper.Map<SysRegionDTO>(region);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<SysRegionDTO> AddRegion(SysRegionDTO model)
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                var newId = await _context.SysRegions.AnyAsync() ? await _context.SysRegions.MaxAsync(a => a.Id) + 1 : 1;
                model.Id = newId;
                SysRegion sysRegion = _autoMapper.Map<SysRegion>(model);
                sysRegion.Translates = model.Translates.Select(t => new SysRegionTranslate
                {
                    RegionId = newId,
                    Name = t.Name,
                    LanguageId = t.LanguageId
                }).ToList();

                await _context.AddAsync(sysRegion);
                await _context.SaveChangesAsync();

                model.Translates.ForEach(t =>
                {
                    t.Id = sysRegion.Translates.Where(tran => tran.LanguageId == t.LanguageId).FirstOrDefault().Id;
                });
                return model;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> DeleteRegion(int id)
        {
            try
            {
                if (await _context.Doctors.AnyAsync(a => a.RegionId == id)
                        || await _context.MedicalCenters.AnyAsync(a => a.RegionId == id)
                        || await _context.Hotels.AnyAsync(a => a.RegionId == id)
                        || await _context.PlaceToVisits.AnyAsync(a => a.RegionId == id))

                    return false;


                var region = await _context.SysRegions.FirstOrDefaultAsync(a => a.Id == id);
                
                _context.SysRegions.Remove(region);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateRegion(SysRegionDTO model)
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                var sysRegion = _autoMapper.Map<SysRegion>(model);
                sysRegion.Translates = model.Translates.Select(a => new SysRegionTranslate
                {
                    Id = a.Id,
                    RegionId = model.Id,
                    Name = a.Name,
                    LanguageId = a.LanguageId,
                }).ToList();
                _context.Update(sysRegion);
                await _context.SaveChangesAsync();
                model.Translates.ForEach(t =>
                {
                    t.Id = sysRegion.Translates.Where(tran => tran.LanguageId == t.LanguageId).FirstOrDefault().Id;
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion


        #region Place Types

        public async Task<SysPlaceTypeDTO> AddPlaceType(SysPlaceTypeDTO model)
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                var newId = await _context.SysPlaceTypes.AnyAsync() ? await _context.SysPlaceTypes.MaxAsync(a => a.Id) + 1 : 1;
                model.Id = newId;
                SysPlaceType sysPlaceType = _autoMapper.Map<SysPlaceType>(model);
                sysPlaceType.Translates = model.Translates.Select(t => new SysPlaceTypeTranslate
                {
                    PlaceTypeId = newId,
                    Name = t.Name,
                    LanguageId = t.LanguageId
                }).ToList();

                await _context.AddAsync(sysPlaceType);
                await _context.SaveChangesAsync();

                model.Translates.ForEach(t =>
                {
                    t.Id = sysPlaceType.Translates.Where(tran => tran.LanguageId == t.LanguageId).FirstOrDefault().Id;
                });
                return model;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<SysPlaceTypeDTO>> PlaceTypesList()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<SysPlaceTypeDTO> result = await _context.SysPlaceTypes.Select(a => new SysPlaceTypeDTO
                {
                    Id = a.Id,
                    Name = a.Translates.FirstOrDefault(a => a.LanguageId == langId).Name,

                    Translates = a.Translates.Select(t => new SysPlaceTypeTranslateDTO
                    {
                        Id = t.Id,
                        PlaceTypeId = t.PlaceTypeId,
                        LanguageId = t.LanguageId,
                        Name = t.Name,
                    }).ToList()

                }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeletePlaceType(int id)
        {
            try
            {
                if (await _context.SysPlaceTypes.AnyAsync(a => a.Id == id))
                    return false;


                var model = await _context.SysPlaceTypes.FirstOrDefaultAsync(a => a.Id == id);
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<SysPlaceTypeDTO>> GetSysPlaceTypes()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();

            return await _context.SysPlaceTypes.Select(x => new SysPlaceTypeDTO
            {
                Id = x.Id,
                Name = x.Translates.FirstOrDefault(x => x.LanguageId == langId).Name

            }).ToListAsync();
        }

        public async Task<bool> UpdatePlaceType(SysPlaceTypeDTO model)
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                var sysPlaceType = _autoMapper.Map<SysPlaceType>(model);
                sysPlaceType.Translates = model.Translates.Select(a => new SysPlaceTypeTranslate
                {
                    Id = a.Id,
                    PlaceTypeId = model.Id,
                    Name = a.Name,
                    LanguageId = a.LanguageId,
                }).ToList();
                _context.Update(sysPlaceType);
                await _context.SaveChangesAsync();
                model.Translates.ForEach(t =>
                {
                    t.Id = sysPlaceType.Translates.Where(tran => tran.LanguageId == t.LanguageId).FirstOrDefault().Id;
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<SysPlaceTypeDTO> GetPlaceTypeById(int id)
        {
            try
            {
                var placeType = await _context.SysPlaceTypes.Include(d => d.Translates).FirstOrDefaultAsync(d => d.Id == id);
                if (placeType == null)
                    return null;
                SysPlaceTypeDTO model = _autoMapper.Map<SysPlaceTypeDTO>(placeType);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion


        #region Department

        public async Task<List<DepartmentDTO>> GetSysDepartments()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();

            return await _context.Departments.Select(x => new DepartmentDTO
            {
                Id = x.Id,
                Name = x.Translates.FirstOrDefault(x => x.LanguageId == langId).Name

            }).ToListAsync();
        }

        public async Task<List<DepartmentDTO>> DepartmentList()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<DepartmentDTO> result = await _context.Departments.Select(a => new DepartmentDTO
                {
                    Id = a.Id,
                    Name = a.Translates.FirstOrDefault(a => a.LanguageId == langId).Name,

                    Translates = a.Translates.Select(t => new DepartmentTranslateDTO
                    {
                        DepartmentId = t.DepartmentId,
                        LanguageId = t.LanguageId,
                        Name = t.Name,
                    }).ToList()

                }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<DepartmentDTO> AddDepartment(DepartmentDTO model)
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                var newId = await _context.Departments.AnyAsync() ? await _context.Departments.MaxAsync(a => a.Id) + 1 : 1; //
                model.Id = newId;
                Department department = _autoMapper.Map<Department>(model);
                department.Translates = model.Translates.Select(t => new DepartmentTranslate
                {
                    DepartmentId = newId,
                    Name = t.Name,
                    LanguageId = t.LanguageId
                }).ToList();

                await _context.AddAsync(department);
                await _context.SaveChangesAsync();

                foreach (var t in model.Translates)
                {
                    t.Id = department.Translates.Where(tran => tran.LanguageId == t.LanguageId).FirstOrDefault().Id;
                }
                return model;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            try
            {
                if (await _context.Departments.AnyAsync(a => a.Id == id))
                    return false;

                var model = await _context.Departments.FirstOrDefaultAsync(a => a.Id == id);
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDepartment(DepartmentDTO model)
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                var department = _autoMapper.Map<Department>(model);
                department.Translates = model.Translates.Select(a => new DepartmentTranslate
                {
                    Id = a.Id,
                    DepartmentId = model.Id,
                    Name = a.Name,
                    LanguageId = a.LanguageId,
                }).ToList();
                _context.Update(department);
                await _context.SaveChangesAsync();

                foreach (var t in model.Translates)
                {
                    t.Id = department.Translates.Where(tran => tran.LanguageId == t.LanguageId).FirstOrDefault().Id;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<DepartmentDTO> GetDepartmentById(int id)
        {
            try 
            {
                var department = await _context.Departments.Include(d => d.Translates).FirstOrDefaultAsync(d => d.Id == id);
                if (department == null)
                    return null;
                DepartmentDTO model = _autoMapper.Map<DepartmentDTO>(department);
                return model;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        #endregion
    }
}
