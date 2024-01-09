using Spotify_DataLayer.Models;
using System.Collections.Generic;

namespace SpotiAPI.Service.Interfaces
{
    public interface IArtistService
    {
        public void CreateArtist(
      string nameOfArtist,
         ICollection<Album> albums);

        public string Delete(int id);

        public List<Artist> GetAllArtists();
        public Artist GetSingleArtist(int id);
        public void UpdateArtist(int id, Artist artist);
    }
}
