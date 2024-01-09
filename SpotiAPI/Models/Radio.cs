using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
    public class Radio
    {
        [Key]
        public int Id_Radio { get; set; }
        public string TitleOfRadio { get; set; }
       
        public ICollection <Song> Songs { get; set; }
    }
}
