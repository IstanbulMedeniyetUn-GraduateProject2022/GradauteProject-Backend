using AutoMapper;
using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.PlaceToVisit;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.FileManager;
using GraduateProject.Common.Services.Languages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.PlacesToVisit
{

    public class PlacesToVisitService : IPlacesToVisitService
    {
        #region Fields and Ctor

        private readonly ILanguageService _languageService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _autoMapper;
        private readonly IFileManagerService _fileManager;
        public PlacesToVisitService(ApplicationDbContext context, ILanguageService languageService, IMapper autoMapper, IFileManagerService fileManager)
        {
            _context = context;
            _languageService = languageService;
            _autoMapper = autoMapper;
            _fileManager = fileManager;
        }

        #endregion

        #region Methods
        public async Task<bool> AddPlace(PlaceToVisitDTO model)
        {
            try
            {
                List<PlaceToVisitTranslate> translates = new List<PlaceToVisitTranslate>();
                PlaceToVisit placeToVisit = _autoMapper.Map<PlaceToVisit>(model);
                foreach (var t in model.Translates)
                {
                    translates.Add(new PlaceToVisitTranslate
                    {
                        Name = t.Name,
                        Description = t.Description,
                        LanguageId = t.LanguageId
                    });
                }

                placeToVisit.Translates = translates;
                _context.Add(placeToVisit);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeletePlace(int id)
        {
            try
            {
                var placeToVisit = await _context.PlaceToVisits.FirstOrDefaultAsync(d => d.Id == id);
                placeToVisit.IsDeleted = true;
                _context.PlaceToVisits.Update(placeToVisit);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<PlaceToVisitListDTO>> GetAcitvatedPlaces()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<PlaceToVisitListDTO> result = await _context.PlaceToVisits.Where(d => d.IsActive == true).Select(d => new PlaceToVisitListDTO
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

        public async Task<PlaceToVisitDTO> GetPlaceById(int id)
        {
            try
            {
                var placeToVisit = await _context.PlaceToVisits.Include(d => d.Translates).FirstOrDefaultAsync(d => d.Id == id);

                if (placeToVisit == null)
                    return null;

                PlaceToVisitDTO model = _autoMapper.Map<PlaceToVisitDTO>(placeToVisit);

                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<PlaceToVisitListDTO>> GetUnActivatedPlaces()
        {
            string langId = _languageService.GetLanguageIdFromRequestAsync();
            try
            {
                List<PlaceToVisitListDTO> result = await _context.PlaceToVisits.Where(d => d.IsActive == false).Select(d => new PlaceToVisitListDTO
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

        public async Task<bool> UpdatePlace(PlaceToVisitDTO model)
        {
            try
            {
                List<PlaceToVisitTranslate> translates = new List<PlaceToVisitTranslate>();
                PlaceToVisit placeToVisit = _autoMapper.Map<PlaceToVisit>(model);
                foreach (var t in model.Translates)
                {
                    translates.Add(new PlaceToVisitTranslate
                    {
                        Id = t.Id,
                        PlaceToVisitId = t.PlaceToVisitId,
                        Name = t.Name,
                        Description = t.Description,
                        LanguageId = t.LanguageId
                    });
                }

                placeToVisit.Translates = translates;
                _context.Update(placeToVisit);
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
