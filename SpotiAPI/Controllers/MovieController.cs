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
    public class MovieController : ControllerBase
    {





        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService =movieService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()

        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{id}", Name = "GetSingleMovie")]
        public ActionResult<Movie> GetSingle(int id)
        {
            var movie = _movieService.GetSingleMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie m)
        {
            if (m == null)
            {
                return BadRequest("Invalid request body");
            }
            try
            {
                _movieService.CreateMovie
                   ( m.TitleOfMovie,m.Director




                    );
                return CreatedAtAction("GetSingleMovie ", new { id = m.Id_Movie }, m);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie upmovie)
        {
            var existingMovie = _movieService.GetSingleMovie(id);
            if (existingMovie == null)
            {
                NotFound();
            }
            existingMovie.TitleOfMovie = upmovie.TitleOfMovie;
            existingMovie
               .Director = upmovie.Director;
           
            _movieService.UpdateMovie(id, existingMovie);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _movieService.Delete(id);

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
