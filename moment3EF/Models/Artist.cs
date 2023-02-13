using System;
using System.ComponentModel.DataAnnotations;

namespace moment3EF.Models
{
	public class Artist
	{
		//properties

		
		public int ArtistId { get; set; }

        //sätter fältet som nödvändigt vid ifyllnad och med felmeddelande
        [Required(ErrorMessage = "Ange ett namn på artisten.")]
        //vilka labels som ska visas till inmatningsfälten
        [Display(Name = "Artisten")]
        public string? Name { get; set; }

		public ICollection<Album>? Album { get; set; }
	}
}

