using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DataAccess.Abstract
{
    public interface IHotelRepository
    {
        List<Hotel.Entities.Hotel> GetAllHotels();
        Hotel.Entities.Hotel GetHotelById(int id);
        Hotel.Entities.Hotel GetHotelByName(string name);
        Hotel.Entities.Hotel CreateHotel(Hotel.Entities.Hotel hotel);
        Hotel.Entities.Hotel UpdateHotel(Hotel.Entities.Hotel hotel);
        void DeleteHotel(int id);
    }
}
