using System;
namespace moment3EF.Models
{
	public class Artist
	{
		//properties

		
		public int ArtistId { get; set; }

		public string? Name { get; set; }

		public ICollection<Album>? Album { get; set; }
	}
}

