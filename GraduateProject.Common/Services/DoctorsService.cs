using AutoMapper;
using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs;
using GraduateProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services
{
    public class DoctorsService : IDoctorsService
    {
        #region Fields and Ctor
        private readonly ILanguageService _languageService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _autoMapper;
        public DoctorsService(ApplicationDbContext context, ILanguageService languageService, IMapper autoMapper)
        {
            _context = context;
            _languageService = languageService;
            _autoMapper = autoMapper;
        }

        #endregion

        #region Methods
        public async Task<bool> AddDoctor(DoctorDTO model)
        {
            try
            {
                List<DoctorTranslate> doctorTranslates = new List<DoctorTranslate>();
                Doctor doctor = _autoMapper.Map<Doctor>(model);
                foreach (var t in model.Tranlates)
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
                doctor.Tranlates = doctorTranslates;
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

        public Task<List<DoctorDTO>> FilterDoctors(int? DepartmentId, int? cityId, int? rate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DoctorDTO>> GetAcitvatedDoctors()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<DoctorDTO> result = await _context.Doctors.Where(d => d.IsActive == true).Select(d => new DoctorDTO
                {
                    Id = d.Id,
                    Email = d.Email,
                    Phone = d.Phone,
                    FullName = d.Tranlates.FirstOrDefault(d => d.LanguageId == langId).FirstName + d.Tranlates.FirstOrDefault(d => d.LanguageId == langId).LastName,
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
                var doctor = await _context.Doctors.Include(d => d.Tranlates).FirstOrDefaultAsync(d => d.Id == id);

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

        public async Task<List<DoctorDTO>> GetUnActivatedDoctors()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<DoctorDTO> result = await _context.Doctors.Where(d => d.IsActive == false).Select(d => new DoctorDTO
                {
                    Id = d.Id,
                    Email = d.Email,
                    Phone = d.Phone,
                    FullName = d.Tranlates.FirstOrDefault(d => d.LanguageId == langId).FirstName + d.Tranlates.FirstOrDefault(d => d.LanguageId == langId).LastName,
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
                foreach (var t in model.Tranlates)
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
                doctor.Tranlates = doctorTranslates;
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
