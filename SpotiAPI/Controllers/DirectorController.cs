using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Spotify_DataLayer.Models;
using SpotiAPI.Service.Interfaces;

namespace SpotiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {





        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Director>> Get()
        {
            var directors = _directorService.GetAllDirectors();
            return Ok(directors);
        }

        [HttpGet("{id}", Name = "GetSingleDirector")]
        public ActionResult<Director> GetSingle(int id)
        {
            var dir = _directorService.GetSingleDirector(id);
            if (dir == null)
            {
                return NotFound();
            }

            return Ok(dir);
        }

        [HttpPost]
        public ActionResult<Director> Post([FromBody] Director director)
        {
            if (director == null)
            {
                return BadRequest("Invalid request body");
            }
            try
            {
                _directorService.CreateDirector
                    (director.NameOfDirector,
                    director.Movies



                    );
                return CreatedAtAction("GetSingleDirector", new { id = director.Id_Director }, director);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] Director updateDirector)
        {
            var existingDirector = _directorService.GetSingleDirector(id);
            if (existingDirector == null)
            {
                NotFound();
            }
            existingDirector.NameOfDirector = updateDirector.NameOfDirector;
            existingDirector.Movies = updateDirector.Movies;
          
            _directorService.UpdateDirector(id, existingDirector);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _directorService.Delete(id);

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
