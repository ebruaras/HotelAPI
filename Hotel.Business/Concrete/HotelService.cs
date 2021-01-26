using Hotel.Business.Abstract;
using Hotel.DataAccess.Abstract;
using Hotel.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Business.Concrete
{
   public class HotelService: IHotelService
    {
        private IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public List<Hotel.Entities.Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }
        public Hotel.Entities.Hotel GetHotelById(int id)
        {
            if (id > 0)
            {
                return _hotelRepository.GetHotelById(id);
            }
            throw new Exception("id cannot be less than 1");
        }
        public Hotel.Entities.Hotel GetHotelByName(string name)
        {
            return _hotelRepository.GetHotelByName(name);
        }
        public Hotel.Entities.Hotel CreateHotel(Hotel.Entities.Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }
        public Hotel.Entities.Hotel UpdateHotel(Hotel.Entities.Hotel hotel)
        {
            return _hotelRepository.UpdateHotel(hotel);
        }
        public void DeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
        }
    }
}
