
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
    public class Director
    {
        [Key]
        public int Id_Director { get; set; }
        public string NameOfDirector { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
