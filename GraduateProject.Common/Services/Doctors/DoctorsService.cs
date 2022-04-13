using AutoMapper;
using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.Doctor;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.FileManager;
using GraduateProject.Common.Services.Languages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.Doctors
{
    public class DoctorsService : IDoctorsService
    {
        #region Fields and Ctor

        private readonly ILanguageService _languageService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _autoMapper;
        private readonly IFileManagerService _fileManager; 
        public DoctorsService(ApplicationDbContext context, ILanguageService languageService, IMapper autoMapper, IFileManagerService fileManager)
        {
            _context = context;
            _languageService = languageService;
            _autoMapper = autoMapper;
            _fileManager = fileManager;
        }

        #endregion

        #region Methods
        public async Task<bool> AddDoctor(DoctorDTO model)
        {
            try
            {
                List<DoctorTranslate> doctorTranslates = new List<DoctorTranslate>();
                Doctor doctor = _autoMapper.Map<Doctor>(model);
                foreach (var t in model.Translates)
                {
                    doctorTranslates.Add(new DoctorTranslate
                    {
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        Gender = t.Gender,
                        WorkingPlace = t.WorkingPlace,
                        LanguageId = t.LanguageId
                    });
                }
                if(model.ImageFile != null)
                {
                    doctor.ImagePath = await _fileManager.UploadFileAsync(model.ImageFile, "doctor", true);
                }
                doctor.Translates = doctorTranslates;
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> DeleteDoctor(int id)
        {
            try
            {
                var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
                doctor.IsDeleted = true;
                _context.Doctors.Update(doctor);
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public Task<List<DoctorListDTO>> FilterDoctors(int? DepartmentId, int? cityId, int? rate)
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {

            }
            catch(Exception ex)
            {

            }
            throw new NotImplementedException();
        }

        public async Task<List<DoctorListDTO>> GetActivatedDoctors()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<DoctorListDTO> result = await _context.Doctors/*.Include(d => d.MedicalCenter).ThenInclude(m => m.Translates).Include(d => d.Department).ThenInclude(d => d.Translates)*/.Where(d => d.IsActive == true).Select(d => new DoctorListDTO
                {
                    Id = d.Id,
                    Email = d.Email,
                    Phone = d.Phone,
                    FullName = d.Translates.FirstOrDefault(d => d.LanguageId == langId).FirstName + d.Translates.FirstOrDefault(d => d.LanguageId == langId).LastName,
                    DepartmentName = d.Department.Translates.FirstOrDefault(d => d.LanguageId == langId).Name,
                    MedicalCenterName = d.MedicalCenter.Translates.FirstOrDefault(d => d.LanguageId == langId).Name,
                    Location = d.Location,
                }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<DoctorDTO> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _context.Doctors.Include(d => d.Translates).FirstOrDefaultAsync(d => d.Id == id);

                if (doctor == null)
                    return null;

                DoctorDTO model = _autoMapper.Map<DoctorDTO>(doctor);

                return model;
            }
            catch(Exception e)
            {
                return null;
            }
            
        }

        public async Task<List<DoctorListDTO>> GetUnActivatedDoctors()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<DoctorListDTO> result = await _context.Doctors/*.Include(d => d.MedicalCenter).ThenInclude(m => m.Translates).Include(d => d.Department).ThenInclude(d => d.Translates)*/.Where(d => d.IsActive == false).Select(d => new DoctorListDTO
                {
                    Id = d.Id,
                    Email = d.Email,
                    Phone = d.Phone,
                    FullName = d.Translates.FirstOrDefault(d => d.LanguageId == langId).FirstName + d.Translates.FirstOrDefault(d => d.LanguageId == langId).LastName,
                    DepartmentName = d.Department.Translates.FirstOrDefault(d => d.LanguageId == langId).Name,
                    MedicalCenterName = d.MedicalCenter.Translates.FirstOrDefault(d => d.LanguageId == langId).Name,
                    Location = d.Location,
                }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateDoctor(DoctorDTO model)
        {
            try
            {
                List<DoctorTranslate> doctorTranslates = new List<DoctorTranslate>();
                Doctor doctor = _autoMapper.Map<Doctor>(model);
                foreach (var t in model.Translates)
                {
                    doctorTranslates.Add(new DoctorTranslate
                    {
                        DoctorId = t.DoctorId,
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        Gender = t.Gender,
                        WorkingPlace = t.WorkingPlace,
                        LanguageId = t.LanguageId
                    });
                }
                if (model.ImageFile != null)
                {
                    if(model.ImagePath != null)
                        await _fileManager.DeleteFileAsync(model.ImagePath);

                    doctor.ImagePath = await _fileManager.UploadFileAsync(model.ImageFile, "doctor", true);
                }
                doctor.Translates = doctorTranslates;
                _context.Update(doctor);
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
