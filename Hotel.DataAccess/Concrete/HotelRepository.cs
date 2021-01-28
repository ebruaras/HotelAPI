using Hotel.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Concrete
{
    public class HotelRepository: IHotelRepository
    {
        public async Task<List<Hotel.Entities.Hotel>> GetAllHotels()
        {
            using (var context = new HotelDbContext())
            {
                return await context.Hotels.ToListAsync();
            }
        }
        public async Task <Hotel.Entities.Hotel> GetHotelById(int id)
        {
            using (var context = new HotelDbContext())
            {
                return await context.Hotels.FindAsync(id);
            }
        }
        public async Task <Hotel.Entities.Hotel> GetHotelByName(string name)
        {
            using (var context = new HotelDbContext())
            {
                return await context.Hotels.FirstOrDefaultAsync(x=>x.Name.ToLower()==name.ToLower());
            }
        }
        public async Task <Hotel.Entities.Hotel> CreateHotel(Hotel.Entities.Hotel hotel)
        {
            using (var context = new HotelDbContext())
            {
                context.Hotels.Add(hotel);
                await context.SaveChangesAsync();
                return hotel;
            }
        }
        public async Task <Hotel.Entities.Hotel> UpdateHotel(Hotel.Entities.Hotel hotel)
        {
            using (var context = new HotelDbContext())
            {
                context.Update(hotel);
                await context.SaveChangesAsync();
                return hotel;
            }
        }
        public async Task DeleteHotel(int id)
        {
            using (var context = new HotelDbContext())
            {
                var deletedHotel = await GetHotelById(id);
                context.Hotels.Remove(deletedHotel);
               await context.SaveChangesAsync();
            }
        }
    }
}
