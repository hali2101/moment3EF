using System;
using System.ComponentModel.DataAnnotations;

namespace moment3EF.Models
{
	public class Lending
	{
		//properties
		public int LendingId { get; set; }

        //sätter fältet som nödvändigt vid ifyllnad och med felmeddelande
        [Required(ErrorMessage = "Fyll i ditt namn.")]
        //vilka labels som ska visas till inmatningsfälten
        [Display(Name = "Namn")]
        public string? Name { get; set; }

        //sätter fältet som nödvändigt vid ifyllnad och med felmeddelande
        [Required(ErrorMessage = "Fyll i din epost-adress.")]
        //vilka labels som ska visas till inmatningsfälten
        [Display(Name = "E-postadress")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        //sätter fältet som nödvändigt vid ifyllnad och med felmeddelande
        [Required(ErrorMessage = "Fyll i vilket album du vill låna.")]
        //vilka labels som ska visas till inmatningsfälten
        [Display(Name = "Album")]
        public int AlbumId { get; set; }

        public Album? Album { get; set; }

        //sätter fältet som nödvändigt vid ifyllnad och med felmeddelande
        [Required(ErrorMessage = "Fyll i datum när du lånar albumet.")]
        //vilka labels som ska visas till inmatningsfälten
        [Display(Name = "Utlåningsdatum")]
        [DataType(DataType.Date)]
		public DateOnly DateOfLending { get; set; }
    }
}

