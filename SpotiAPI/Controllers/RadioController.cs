using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Spotify_DataLayer.Models;
using SpotiAPI.Service.Interfaces;
using System.IO;

namespace SpotiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadioController : ControllerBase
    {





        private readonly IRadioService _radioService;

        public RadioController(IRadioService radioService)
        {
            _radioService = radioService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Radio>> Get()

        {
            var radios = _radioService.GetAllRadios();
            return Ok(radios);
        }

        [HttpGet("{id}", Name = "GetSingleRadio")]
        public ActionResult<Radio> GetSingle(int id)
        {
            var radio = _radioService.GetSingleRadio(id);
            if (radio == null)
            {
                return NotFound();
            }

            return Ok(radio);
        }

        [HttpPost]
        public ActionResult<Radio> Post([FromBody] Radio radio)
        {
            if (radio == null)
            {
                return BadRequest("Invalid request body");
            }
            try
            {
                _radioService.CreateRadio
                    (radio.TitleOfRadio,

       radio.Songs





                    );
                return CreatedAtAction("GetSingleRadio", new { id = radio.Id_Radio }, radio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateRadio(int id, [FromBody] Radio updatedRadio)
        {
            var existingRadio = _radioService.GetSingleRadio(id);
            if (existingRadio == null)
            {
                NotFound();
            }
            existingRadio.TitleOfRadio = updatedRadio.TitleOfRadio;
            existingRadio.Songs = updatedRadio.Songs;

            _radioService.UpdateRadio(id, existingRadio);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _radioService.Delete(id);

            if (result == "Item deleted")
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

    }
}
