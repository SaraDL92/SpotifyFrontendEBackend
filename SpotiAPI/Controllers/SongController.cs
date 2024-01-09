using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Spotify_DataLayer.Models;
using SpotiAPI.Service.Interfaces;

namespace SpotiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {

       
       

        
            private readonly ISongService _songService;

            public SongController(ISongService songService)
            {
                _songService = songService;

            }

            [HttpGet]
            public ActionResult<IEnumerable<Song>> GetSong()
            {
                var issues = _songService.GetAllSongs();
                return Ok(issues);
            }

            [HttpGet("{id}", Name = "GetSingleSong")]
            public ActionResult<Song> GetSingleSong(int id)
            {
                var song = _songService.GetSingleSong(id);
                if (song == null)
                {
                    return NotFound();
                }

                return Ok(song);
            }

            [HttpPost]
            public ActionResult<Song> Post([FromBody] Song song)
            {
                if (song == null)
                {
                    return BadRequest("Invalid request body");
                }
                try
                {
                    _songService.CreateSong
                        (song.TitleOfSong,
                        song.ArtistOfSong,
                        song.Radio,
                        song.AlbumOfSong
                      
                      
                      
                        );
                    return CreatedAtAction("GetSingleSong", new { id = song.Id_Song }, song);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error:{ex.Message}");
                }

            }
        [HttpPut("{id}")]
        public IActionResult UpdateSong(int id, [FromBody] Song updatedSong)
        {
            var existingSong=_songService.GetSingleSong(id);    
            if(existingSong == null)
            {
                NotFound();
            }
            existingSong.ArtistOfSong = updatedSong.ArtistOfSong;
            existingSong.Radio = updatedSong.Radio;
            existingSong.AlbumOfSong= updatedSong.AlbumOfSong;
            existingSong.TitleOfSong = updatedSong.TitleOfSong;
            _songService.UpdateSong(id, existingSong);
            return NoContent();
        }
        [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var result = _songService.Delete(id);

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
