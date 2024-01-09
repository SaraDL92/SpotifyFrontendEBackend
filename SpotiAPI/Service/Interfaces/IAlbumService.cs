using Spotify_DataLayer.Models;
using System.Collections.Generic;

namespace SpotiAPI.Service.Interfaces
{
    public interface IAlbumService
    {
       
 public void CreateAlbum(
      string titleOfAlbum,

       Artist artistOfAlbum,
       ICollection<Radio> songs);

        public string Delete(int id);

        public List<Album> GetAllAlbums();
        public Album GetSingleAlbum(int id);
        public void UpdateAlbum(int id, Album album);
    }
}
