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
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Hotel.Entities.Hotel> GetAllHotels()
        {
            return _hotelService.GetAllHotels();
        }
        /// <summary>
        /// Get Hotels By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Hotel.Entities.Hotel GetHotelById(int id)
        {
            return _hotelService.GetHotelById(id);
        }
        /// <summary>
        /// Create an Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public Hotel.Entities.Hotel PostHotel([FromBody]Hotel.Entities.Hotel hotel)
        {
            return _hotelService.CreateHotel(hotel);
        }
        /// <summary>
        /// Update the Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public Hotel.Entities.Hotel PutHotel([FromBody] Hotel.Entities.Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }
        /// <summary>
        /// Delete the Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeleteHotel(int id)
        {
            _hotelService.DeleteHotel(id);
        }

    }
}
