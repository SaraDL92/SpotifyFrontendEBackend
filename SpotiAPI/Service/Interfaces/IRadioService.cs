using Spotify_DataLayer.Models;
using System.Collections.Generic;

namespace SpotiAPI.Service.Interfaces
{
    public interface IRadioService
    {
        public void CreateRadio(

       string titleOfRadio,

     ICollection<Song> songs);
        public string Delete(int id);

        public List<Radio> GetAllRadios();
        public Radio GetSingleRadio(int id);
        public void UpdateRadio(int id, Radio radio);
    }
}
