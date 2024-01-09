using SpotiAPI.Repo;
using System.Collections.Generic;
using System.Xml.Linq;
using System;
using Spotify_DataLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using SpotiAPI.Service.Interfaces;

namespace SpotiAPI.Service
{
    public class SongService:ISongService
    {
        private readonly IGenericRepository<Song> _songRepository;

        public SongService(IGenericRepository<Song> songRepo)
        {

            _songRepository = songRepo;
        }

        public void CreateSong(string titleOfSong, Artist artistOfSong, Radio radio, Album albumOfSong)
        {
            var newSong = new Song
            {
                TitleOfSong = titleOfSong,
                ArtistOfSong = artistOfSong,
                Radio = radio,
                AlbumOfSong = albumOfSong
            };

           
            _songRepository.Create(newSong);
        }
        public string Delete(int id)
        {
            try
            {
                return _songRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Song> GetAllSongs() { return _songRepository.GetAll(); }

        public Song GetSingleSong(int id) { return _songRepository.GetSingle(id); }
        public void UpdateSong(int id,Song song) { _songRepository.Update(id, song); }

    }
}
