using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.Abstract
{
   public interface IHotelService
    {
        Task<List<Hotel.Entities.Hotel>> GetAllHotels();
       Task <Hotel.Entities.Hotel> GetHotelById(int id);
       Task <Hotel.Entities.Hotel> GetHotelByName(string name);
       Task <Hotel.Entities.Hotel> CreateHotel(Hotel.Entities.Hotel hotel);
       Task <Hotel.Entities.Hotel> UpdateHotel(Hotel.Entities.Hotel hotel);
        Task DeleteHotel(int id);
    }
}
