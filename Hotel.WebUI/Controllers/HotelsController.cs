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
        [Route("[action]")]
        public IActionResult GetAllHotels()
        {
           var hotels= _hotelService.GetAllHotels();
            return Ok(hotels);
            //response code olarak 200 dönsün ve body kısmına da bu hotels i ekle
        }
        /// <summary>
        /// Get Hotels By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel= _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel); //hotel bulunduysa 200 dön ve body ye ekle
            }
            return NotFound(); //hotel bulunamadıysa 404 dön
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetHotelByName(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel); //200 + hotel
            }
            return NotFound(); //404
        }
        /// <summary>
        /// Create an Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult PostHotel([FromBody]Hotel.Entities.Hotel hotel)
        {
            var createdHotel= _hotelService.CreateHotel(hotel);
            return CreatedAtAction("GetHotelById", new { id = createdHotel.Id }, createdHotel);
           //dönen response un header kısmında oluşturulan otelin hangi url de oldugu da belirtilir
        }
        /// <summary>
        /// Update the Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult PutHotel([FromBody] Hotel.Entities.Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel)); // 200 + guncellenen hotel
            }
            return NotFound(); //404
        }
        /// <summary>
        /// Delete the Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteHotel(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok(); // 200
            }
            return NotFound(); //404
        }

    }
}
