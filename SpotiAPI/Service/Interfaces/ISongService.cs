using System.Collections.Generic;
using System.Xml.Linq;
using System;
using Spotify_DataLayer.Models;

namespace SpotiAPI.Service.Interfaces
{
    public interface ISongService
    {
        public void CreateSong(string titleOfSong,

         Artist artistOfSong,

         Radio radio,

          Album albumOfSong);

        public string Delete(int id);

        public List<Song> GetAllSongs();
        public Song GetSingleSong(int id);
        public void UpdateSong(int id, Song song);
    }
}
