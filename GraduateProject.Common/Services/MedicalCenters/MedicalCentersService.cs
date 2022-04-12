using AutoMapper;
using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.MedicalCenter;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.FileManager;
using GraduateProject.Common.Services.Languages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.MedicalCenters
{
    public class MedicalCentersService : IMedicalCentersService
    {
        #region Fields and Ctor

        private readonly ILanguageService _languageService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _autoMapper;
        private readonly IFileManagerService _fileManager;
        public MedicalCentersService(ApplicationDbContext context, ILanguageService languageService, IMapper autoMapper, IFileManagerService fileManager)
        {
            _context = context;
            _languageService = languageService;
            _autoMapper = autoMapper;
            _fileManager = fileManager;
        }

        #endregion

        #region Methods

        public async Task<bool> AddMedicalCenter(MedicalCenterDTO model)
        {
            try
            {
                List<MedicalCenterTranslate> translates = new List<MedicalCenterTranslate>();
                MedicalCenter medicalCenter = _autoMapper.Map<MedicalCenter>(model);
                foreach (var t in model.Translates)
                {
                    translates.Add(new MedicalCenterTranslate
                    {
                        Name = t.Name,
                        Description = t.Description,
                        LanguageId = t.LanguageId
                    });
                }
                if (model.ImageFile != null)
                {
                    medicalCenter.ImagePath = await _fileManager.UploadFileAsync(model.ImageFile, "medicalCenter", true);
                }
                medicalCenter.Translates = translates;
                _context.Add(medicalCenter);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMedicalCenter(int id)
        {
            try
            {
                var medicalCenter = await _context.MedicalCenters.FirstOrDefaultAsync(d => d.Id == id);
                medicalCenter.IsDeleted = true;
                _context.MedicalCenters.Update(medicalCenter);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<List<MedicalCenterListDTO>> FilterMedicalCenters(int? cityId, int? rate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MedicalCenterListDTO>> GetAcitvatedMedicalCenters()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<MedicalCenterListDTO> result = await _context.MedicalCenters/*.Include(d => d.MedicalCenter).ThenInclude(m => m.Translates).Include(d => d.Department).ThenInclude(d => d.Translates)*/.Where(d => d.IsActive == true).Select(d => new MedicalCenterListDTO
                {
                    Id = d.Id,
                    Email = d.Email,
                    Phone = d.Phone,
                    Name = d.Translates.FirstOrDefault(d => d.LanguageId == langId).Name,
                    Location = d.Location,
                }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<MedicalCenterDTO> GetMedicalCenterById(int id)
        {
            try
            {
                var medicalCenter = await _context.MedicalCenters.Include(d => d.Translates).FirstOrDefaultAsync(d => d.Id == id);

                if (medicalCenter == null)
                    return null;

                MedicalCenterDTO model = _autoMapper.Map<MedicalCenterDTO>(medicalCenter);

                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<MedicalCenterListDTO>> GetUnActivatedMedicalCenters()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<MedicalCenterListDTO> result = await _context.MedicalCenters/*.Include(d => d.MedicalCenter).ThenInclude(m => m.Translates).Include(d => d.Department).ThenInclude(d => d.Translates)*/.Where(d => d.IsActive == false).Select(d => new MedicalCenterListDTO
                {
                    Id = d.Id,
                    Email = d.Email,
                    Phone = d.Phone,
                    Name = d.Translates.FirstOrDefault(d => d.LanguageId == langId).Name,
                    Location = d.Location,
                }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateMedicalCenter(MedicalCenterDTO model)
        {
            try
            {
                List<MedicalCenterTranslate> translates = new List<MedicalCenterTranslate>();
                MedicalCenter medicalCenter = _autoMapper.Map<MedicalCenter>(model);
                foreach (var t in model.Translates)
                {
                    translates.Add(new MedicalCenterTranslate
                    {
                        MedicalCenterId = t.MedicalCenterId,
                        Name = t.Name,
                        Description = t.Description,
                        LanguageId = t.LanguageId
                    });
                }
                if (model.ImageFile != null)
                {
                    if(model.ImagePath != null)
                        await _fileManager.DeleteFileAsync(model.ImagePath);

                    medicalCenter.ImagePath = await _fileManager.UploadFileAsync(model.ImageFile, "medicalCenter", true);
                }
                medicalCenter.Translates = translates;
                _context.Update(medicalCenter);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
