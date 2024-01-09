using SpotiAPI.Repo;
using SpotiAPI.Service.Interfaces;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpotiAPI.Service
{
    public class MovieService:IMovieService
    {
        private readonly IGenericRepository<Movie> _movieRepository;

        public MovieService(IGenericRepository<Movie> movieRepo)
        {

            _movieRepository = movieRepo;
        }

        public void CreateMovie(

          string titleOfMovie,
       
        Director director )
        {
            _movieRepository.Create(new Movie { TitleOfMovie = titleOfMovie, Director = director });
        }

        public string Delete(int id)
        {
            try
            {
                return _movieRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Movie> GetAllMovies() { return _movieRepository.GetAll(); }

        public Movie GetSingleMovie(int id) { return _movieRepository.GetSingle(id); }
        public void UpdateMovie(int id, Movie movie) { _movieRepository.Update(id, movie); }
    }
}

