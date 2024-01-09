using SpotiAPI.Repo;
using SpotiAPI.Service.Interfaces;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;

namespace SpotiAPI.Service
{
    public class ArtistService:IArtistService
    {
        private readonly IGenericRepository<Artist> _artistRepository;

        public ArtistService(IGenericRepository<Artist> artistRepo)
        {

            _artistRepository = artistRepo;
        }

        public void CreateArtist(
      string nameOfArtist,
         ICollection<Album> albums)
        {
            _artistRepository.Create(new Artist {NameOfArtist=nameOfArtist,Albums=albums });
        }

        public string Delete(int id)
        {
            try
            {
                return _artistRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Artist> GetAllArtists() { return _artistRepository.GetAll(); }

        public Artist GetSingleArtist(int id) { return _artistRepository.GetSingle(id); }
        public void UpdateArtist(int id, Artist artist) { _artistRepository.Update(id, artist); }
    }
}

