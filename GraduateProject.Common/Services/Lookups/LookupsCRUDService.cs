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


                var city = await _context.SysCities.FirstOrDefaultAsync(a => a.Id == id);
                city.IsDeleted = true;
                _context.SysCities.Update(city);
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
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeletePlaceType(int id)
        {
            try
            {
                if (await _context.PlaceToVisits.AnyAsync(a => a.PlaceTypeId == id))
                    return false;


                var sysPlaceType = await _context.SysPlaceTypes.FirstOrDefaultAsync(a => a.Id == id);
                sysPlaceType.IsDeleted = true;
                _context.SysPlaceTypes.Update(sysPlaceType);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
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
            catch (Exception)
            {
                return false;
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
            catch (Exception)
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

                var department = await _context.Departments.FirstOrDefaultAsync(a => a.Id == id);
                department.IsDeleted = true;
                _context.Departments.Update(department);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
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
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
