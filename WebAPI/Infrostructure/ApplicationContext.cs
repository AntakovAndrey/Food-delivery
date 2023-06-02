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
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json").Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			base.OnConfiguring(optionsBuilder);
		}
	}
}
