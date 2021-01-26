using Hotel.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.DataAccess.Concrete
{
    public class HotelRepository: IHotelRepository
    {
        public List<Hotel.Entities.Hotel> GetAllHotels()
        {
            using (var context = new HotelDbContext())
            {
                return context.Hotels.ToList();
            }
        }
        public Hotel.Entities.Hotel GetHotelById(int id)
        {
            using (var context = new HotelDbContext())
            {
                return context.Hotels.Find(id);
            }
        }
        public Hotel.Entities.Hotel GetHotelByName(string name)
        {
            using (var context = new HotelDbContext())
            {
                return context.Hotels.FirstOrDefault(x=>x.Name.ToLower()==name.ToLower());
            }
        }
        public Hotel.Entities.Hotel CreateHotel(Hotel.Entities.Hotel hotel)
        {
            using (var context = new HotelDbContext())
            {
                context.Hotels.Add(hotel);
                context.SaveChanges();
                return hotel;
            }
        }
        public Hotel.Entities.Hotel UpdateHotel(Hotel.Entities.Hotel hotel)
        {
            using (var context = new HotelDbContext())
            {
                context.Update(hotel);
                context.SaveChanges();
                return hotel;
            }
        }
        public void DeleteHotel(int id)
        {
            using (var context = new HotelDbContext())
            {
                var deletedHotel = GetHotelById(id);
                context.Hotels.Remove(deletedHotel);
                context.SaveChanges();
            }
        }
    }
}
