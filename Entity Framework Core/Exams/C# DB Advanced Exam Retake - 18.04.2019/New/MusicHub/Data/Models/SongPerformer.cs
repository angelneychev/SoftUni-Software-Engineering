using System.ComponentModel.DataAnnotations;
using MusicHub.Data.Models;

namespace MusicHub.Data
{
    public class SongPerformer
    {
        [Required]
        public int SongId { get; set; }
        public Song Song { get; set; }

        [Required]
        public int PerformerId { get; set; }
        public Performer Performer { get; set; }
    }
}

//SongPerformer
//•	SongId – integer, Primary Key
//•	Song – the performer’s song(required)
//•	PerformerId – integer, Primary Key
//•	Performer – the song’s performer(required)
