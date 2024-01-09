using SpotiAPI.Repo;
using SpotiAPI.Service.Interfaces;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;

namespace SpotiAPI.Service
{
    public class DirectorService:IDirectorService
    {
        private readonly IGenericRepository<Director> _directorRepository;

        public DirectorService(IGenericRepository<Director> directorRepo)
        {

            _directorRepository = directorRepo;
        }

        public void CreateDirector(

        string nameOfDirector,
        ICollection<Movie> movies )
        {
            _directorRepository.Create(new Director { NameOfDirector = nameOfDirector,Movies=movies}); ;
        }

        public string Delete(int id)
        {
            try
            {
                return _directorRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Director> GetAllDirectors() { return _directorRepository.GetAll(); }

        public Director GetSingleDirector(int id) { return _directorRepository.GetSingle(id); }
        public void UpdateDirector(int id, Director director) { _directorRepository.Update(id, director); }
    }
}

