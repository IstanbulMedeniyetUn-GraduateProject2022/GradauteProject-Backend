using GraduateProject.Common.DTOs.PlaceToVisit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.PlacesToVisit
{
    public interface IPlacesToVisitService
    {
        public Task<List<PlaceToVisitListDTO>> GetAcitvatedPlaces();
        public Task<List<PlaceToVisitListDTO>> GetUnActivatedPlaces();
        public Task<PlaceToVisitDTO> GetPlaceById(int id);
        public Task<bool> AddPlace(PlaceToVisitDTO model);
        public Task<bool> UpdatePlace(PlaceToVisitDTO model);
        public Task<bool> DeletePlace(int id);
        //public Task<List<PlaceToVisitListDTO>> FilterPlaces(int? cityId, int? rate);
    }
}
