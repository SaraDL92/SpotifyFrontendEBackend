using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
    public class Artist
    {
        [Key]
        public int Id_Artist { get; set; }
        public string NameOfArtist { get; set; }
        public ICollection <Album> Albums { get; set; }
        
    }
}
