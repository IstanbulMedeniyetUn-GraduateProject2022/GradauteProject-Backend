using GraduateProject.Common.DTOs.PlaceToVisit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.PlacesToVisit
{
    public class PlacesToVisitService : IPlacesToVisitService
    {
        public Task<bool> AddPlace(PlaceToVisitDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlace(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlaceToVisitListDTO>> GetAcitvatedPlaces()
        {
            throw new NotImplementedException();
        }

        public Task<PlaceToVisitDTO> GetPlaceById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlaceToVisitListDTO>> GetUnActivatedPlaces()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePlace(PlaceToVisitDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
