
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
   public class Album
    {
        [Key]
        public int Id_Album { get; set; }
        public string TitleOfAlbum { get; set; }
        [ForeignKey("Id_Artist")]
        public Artist ArtistOfAlbum { get; set; }
        public ICollection<Radio> Songs { get; set; }
    }
}
