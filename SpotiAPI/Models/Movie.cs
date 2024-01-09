
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
   public class Movie
    {
        [Key]
        public int Id_Movie { get; set; }
        public string TitleOfMovie { get; set; }
        [ForeignKey("Id_Director ")]
        public Director Director { get; set; }
    }
}
