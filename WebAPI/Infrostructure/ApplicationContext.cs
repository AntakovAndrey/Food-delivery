using Microsoft.EntityFrameworkCore;

namespace WebAPI.Infrostructure
{
	public class ApplicationContext:DbContext
	{
		
		public ApplicationContext() 
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
	}
}
