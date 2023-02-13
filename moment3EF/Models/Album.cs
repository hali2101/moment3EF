using System;
using System.ComponentModel.DataAnnotations;

namespace moment3EF.Models
{
	public class Album
	{
        //properties

        public int AlbumId { get; set; }

        //sätter fältet som nödvändigt vid ifyllnad och med felmeddelande
        [Required(ErrorMessage = "Ange ett namn på albumet.")]
        //vilka labels som ska visas till inmatningsfälten
        [Display(Name = "Namn på album")]
        public string? AlbumName { get; set; }

        //sätter fältet som nödvändigt vid ifyllnad och med felmeddelande
        [Required(ErrorMessage = "Ange år när albumet släpptes.")]
        //vilka labels som ska visas till inmatningsfälten
        [Display(Name = "Albumsläpp")]
        public int? YearOfRelease { get; set; }

		public bool InHouse { get; set; } = true;
        //sätter fältet som nödvändigt vid ifyllnad och med felmeddelande
        [Required(ErrorMessage = "Ange artisten.")]
        //vilka labels som ska visas till inmatningsfälten
        [Display(Name = "Artist:")]
        public int ArtistId { get; set; }

		public Artist? Artist { get; set; }
	}
}

