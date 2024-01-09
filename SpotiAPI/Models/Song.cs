using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify_DataLayer.Models
{
    public class Song
    {
        [Key]
        public int Id_Song { get; set; }
        public string TitleOfSong { get; set; }
        [ForeignKey("Id_Artist")]
        public Artist ArtistOfSong { get; set; }
        [ForeignKey("Id_Radio")]
        public Radio Radio {  get; set; }
        [ForeignKey("Id_Album")]
        public Album AlbumOfSong { get; set;}
    }
}
