using SpotiAPI.Repo;
using SpotiAPI.Service.Interfaces;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpotiAPI.Service
{
    public class AlbumService:IAlbumService
    {
        private readonly IGenericRepository<Album> _albumRepository;

        public AlbumService(IGenericRepository<Album> albumRepo)
        {

            _albumRepository = albumRepo;
        }

        public void CreateAlbum(  
      string titleOfAlbum ,
        
       Artist artistOfAlbum,
       ICollection<Radio> songs )
        {
            _albumRepository.Create(new Album { TitleOfAlbum = titleOfAlbum, ArtistOfAlbum = artistOfAlbum, Songs=songs });
        }

        public string Delete(int id)
        {
            try
            {
                return _albumRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Album> GetAllAlbums() { return _albumRepository.GetAll(); }

        public Album GetSingleAlbum(int id) { return _albumRepository.GetSingle(id); }
        public void UpdateAlbum(int id, Album album) { _albumRepository.Update(id, album); }
    }
    
}
