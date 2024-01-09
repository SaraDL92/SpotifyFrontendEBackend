 using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Spotify_DataLayer.Models;
using SpotiAPI.Service.Interfaces;

namespace SpotiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {





        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Artist>> Get()
        {
            var artists = _artistService.GetAllArtists();
            return Ok(artists);
        }

        [HttpGet("{id}", Name = "GetSingle")]
        public ActionResult<Artist> GetSingle(int id)
        {
            var artist = _artistService.GetSingleArtist(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [HttpPost]
        public ActionResult<Artist> Post([FromBody]Artist artist)
        {
            if (artist == null)
            {
                return BadRequest("Invalid request body");
            }
            try
            {
                _artistService.CreateArtist
                    (artist.NameOfArtist,
                  artist.Albums
              




                    );
                return CreatedAtAction("GetSingle", new { id = artist.Id_Artist }, artist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateArtist(int id, [FromBody] Artist updatedArtist)
        {
            var existingArtist = _artistService.GetSingleArtist(id);
            if (existingArtist == null)
            {
                NotFound();
            }
            existingArtist.NameOfArtist = updatedArtist.NameOfArtist;
            existingArtist.Albums = updatedArtist.Albums;
           

            _artistService.UpdateArtist(id, existingArtist);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _artistService.Delete(id);

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