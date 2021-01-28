using Hotel.Business.Abstract;
using Hotel.DataAccess.Abstract;
using Hotel.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.Concrete
{
   public class HotelService: IHotelService
    {
        private IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<List<Hotel.Entities.Hotel>> GetAllHotels()
        {
            return await _hotelRepository.GetAllHotels();
        }
        public async Task <Hotel.Entities.Hotel> GetHotelById(int id)
        {
            if (id > 0)
            {
                return await _hotelRepository.GetHotelById(id);
            }
            throw new Exception("id cannot be less than 1");
        }
        public async Task <Hotel.Entities.Hotel> GetHotelByName(string name)
        {
            return await _hotelRepository.GetHotelByName(name);
        }
        public async Task <Hotel.Entities.Hotel> CreateHotel(Hotel.Entities.Hotel hotel)
        {
            return await _hotelRepository.CreateHotel(hotel);
        }
        public async Task <Hotel.Entities.Hotel> UpdateHotel(Hotel.Entities.Hotel hotel)
        {
            return await _hotelRepository.UpdateHotel(hotel);
        }
        public async Task DeleteHotel(int id)
        {
           await _hotelRepository.DeleteHotel(id);
        }
    }
}
