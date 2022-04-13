using AutoMapper;
using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.Hotel;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.FileManager;
using GraduateProject.Common.Services.Languages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.Hotels
{
    public class HotelsService : IHotelsService
    {
        #region Fields and Ctor

        private readonly ILanguageService _languageService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _autoMapper;
        private readonly IFileManagerService _fileManager;
        public HotelsService(ApplicationDbContext context, ILanguageService languageService, IMapper autoMapper, IFileManagerService fileManager)
        {
            _context = context;
            _languageService = languageService;
            _autoMapper = autoMapper;
            _fileManager = fileManager;
        }

        #endregion

        #region Methods

        public async Task<bool> AddHotel(HotelDTO model)
        {
            try
            {
                List<HotelTranslate> translates = new List<HotelTranslate>();
                Hotel hotel = _autoMapper.Map<Hotel>(model);
                foreach (var t in model.Translates)
                {
                    translates.Add(new HotelTranslate
                    {
                        Name = t.Name,
                        Description = t.Description,
                        LanguageId = t.LanguageId
                    });
                }
                if (model.ImageFile != null)
                {
                    hotel.LogoPath = await _fileManager.UploadFileAsync(model.ImageFile, "hotel", true);
                }
                hotel.Translates = translates;
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteHotel(int id)
        {
            try
            {
                var hotel = await _context.Hotels.FirstOrDefaultAsync(d => d.Id == id);
                hotel.IsDeleted = true;
                _context.Hotels.Update(hotel);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<HotelListDTO>> GetAcitvatedHotels()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<HotelListDTO> result = await _context.Hotels/*.Include(d => d.MedicalCenter).ThenInclude(m => m.Translates).Include(d => d.Department).ThenInclude(d => d.Translates)*/.Where(d => d.IsActive == true).Select(d => new HotelListDTO
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

        public async Task<HotelDTO> GetHotelById(int id)
        {
            try
            {
                var hotel = await _context.Hotels.Include(d => d.Translates).FirstOrDefaultAsync(d => d.Id == id);

                if (hotel == null)
                    return null;

                HotelDTO model = _autoMapper.Map<HotelDTO>(hotel);

                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<HotelListDTO>> GetUnActivatedHotels()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<HotelListDTO> result = await _context.Hotels/*.Include(d => d.MedicalCenter).ThenInclude(m => m.Translates).Include(d => d.Department).ThenInclude(d => d.Translates)*/.Where(d => d.IsActive == false).Select(d => new HotelListDTO
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

        public async Task<bool> UpdateHotel(HotelDTO model)
        {
            try
            {
                List<HotelTranslate> translates = new List<HotelTranslate>();
                Hotel hotel = _autoMapper.Map<Hotel>(model);
                foreach (var t in model.Translates)
                {
                    translates.Add(new HotelTranslate
                    {
                        HotelId = t.HotelId,
                        Name = t.Name,
                        Description = t.Description,
                        LanguageId = t.LanguageId
                    });
                }
                if (model.ImageFile != null)
                {
                    if (model.LogoPath != null)
                        await _fileManager.DeleteFileAsync(model.LogoPath);

                    hotel.LogoPath = await _fileManager.UploadFileAsync(model.ImageFile, "hotel", true);
                }
                hotel.Translates = translates;
                _context.Update(hotel);
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
