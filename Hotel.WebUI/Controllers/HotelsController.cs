using Hotel.Business.Abstract;
using Hotel.Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public List<Hotel.Entities.Hotel> GetAllHotels()
        {
            return _hotelService.GetAllHotels();
        }
        [HttpGet("{id}")]
        public Hotel.Entities.Hotel GetHotelById(int id)
        {
            return _hotelService.GetHotelById(id);
        }
        [HttpPost]
        public Hotel.Entities.Hotel PostHotel([FromBody]Hotel.Entities.Hotel hotel)
        {
            return _hotelService.CreateHotel(hotel);
        }

        [HttpPut]
        public Hotel.Entities.Hotel PutHotel([FromBody] Hotel.Entities.Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }
        [HttpDelete("{id}")]
        public void DeleteHotel(int id)
        {
            _hotelService.DeleteHotel(id);
        }

    }
}
