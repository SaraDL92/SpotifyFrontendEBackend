using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Spotify_DataLayer.Models;
using SpotiAPI.Service.Interfaces;

namespace SpotiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {





        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Album>> GetAlbums()
        {
            var albums = _albumService.GetAllAlbums();
            return Ok(albums);
        }

        [HttpGet("{id}", Name = "GetAlbum")]
        public ActionResult<Album> GetSingleAlbum(int id)
        {
            var album = _albumService.GetSingleAlbum(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        [HttpPost]
        public ActionResult<Album> Post([FromBody] Album album)
        {
            if (album == null)
            {
                return BadRequest("Invalid request body");
            }
            try
            {
                _albumService.CreateAlbum
                    (album.TitleOfAlbum,
                   album.ArtistOfAlbum,
                    album.Songs
                    



                    );
                return CreatedAtAction("GetAlbum", new { id = album.Id_Album }, album);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateAlbum(int id, [FromBody] Album updatedAlbum)
        {
            var existingAlbum = _albumService.GetSingleAlbum(id);
            if (existingAlbum  == null)
            {
                NotFound();
            }
            existingAlbum.ArtistOfAlbum = updatedAlbum.ArtistOfAlbum;
            existingAlbum.TitleOfAlbum = updatedAlbum.TitleOfAlbum;
            existingAlbum.Songs = updatedAlbum.Songs;
           
            _albumService.UpdateAlbum(id, existingAlbum);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _albumService.Delete(id);

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
