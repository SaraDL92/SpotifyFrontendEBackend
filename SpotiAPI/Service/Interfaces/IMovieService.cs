using Spotify_DataLayer.Models;
using System.Collections.Generic;

namespace SpotiAPI.Service.Interfaces
{
    public interface IMovieService
    {
        public void CreateMovie(

          string titleOfMovie,

        Director director);


        public string Delete(int id);

        public List<Movie> GetAllMovies();

        public Movie GetSingleMovie(int id);
        public void UpdateMovie(int id, Movie movie);
    }

}
