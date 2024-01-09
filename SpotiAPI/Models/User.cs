
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
   public class User
    {
        [Key]
        public int Id_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
  
        [ForeignKey ("Id_Setting")]
        public Radio Setting { get; set; }
    }
}
