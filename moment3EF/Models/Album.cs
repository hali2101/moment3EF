using System;
namespace moment3EF.Models
{
	public class Album
	{
		//properties

		public int AlbumId { get; set; }

		public string? AlbumName { get; set; }

		public int? YearOfRelease { get; set; }

		public bool InHouse { get; set; } = true;

		public int ArtistId { get; set; }

		public Artist? Artist { get; set; }
	}
}

