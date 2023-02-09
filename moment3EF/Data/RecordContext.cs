using System;
using Microsoft.EntityFrameworkCore;
using moment3EF.Models;

namespace moment3EF.Data
{
	public class RecordContext : DbContext
	{
		public RecordContext(DbContextOptions<RecordContext> options) : base(options)
		{

		}

		public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
		public DbSet<Lending> Lendings { get; set; }

        internal void Update()
        {
            throw new NotImplementedException();
        }
    }
}

