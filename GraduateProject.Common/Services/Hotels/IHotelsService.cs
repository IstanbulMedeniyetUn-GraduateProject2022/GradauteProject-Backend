using GraduateProject.Common.DTOs.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.Hotels
{
    public interface IHotelsService
    {
        public Task<List<HotelListDTO>> GetAcitvatedHotels();
        public Task<List<HotelListDTO>> GetUnActivatedHotels();
        public Task<HotelDTO> GetHotelById(int id);
        public Task<bool> AddHotel(HotelDTO model);
        public Task<bool> UpdateHotel(HotelDTO model);
        public Task<bool> DeleteHotel(int id);
        //public Task<List<HotelListDTO>> FilterHotels(int? cityId, int? rate);
    }
}
