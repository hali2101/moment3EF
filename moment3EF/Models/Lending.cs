using System;
using System.ComponentModel.DataAnnotations;

namespace moment3EF.Models
{
	public class Lending
	{
		//properties
		public int LendingId { get; set; }

		public string? Name { get; set; }


        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public int AlbumId { get; set; }

        public Album? Album { get; set; }

		[DataType(DataType.Date)]
		public DateOnly DateOfLending { get; set; }
    }
}

