
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
   public class Setting

    {
        [Key]
        public int Id_Setting { get; set;}
       public bool LightTheme { get; set; }
        public bool GoldPlan { get; set; }
        public bool FreePlan { get; set; }
        public bool PremiumPlan { get; set; }
        [ForeignKey ("Id_User")]
        public User User { get; set; }
        public string SelectedTimeZoneId { get; set; }
    }
}
