using Spotify_DataLayer.Models;
using System.Collections.Generic;

namespace SpotiAPI.Service.Interfaces
{
    public interface IDirectorService
    {
        public void CreateDirector(

       string nameOfDirector,
       ICollection<Movie> movies);
        public string Delete(int id);

        public List<Director> GetAllDirectors();
        public Director GetSingleDirector(int id);
        public void UpdateDirector(int id, Director director);
    }
}
