using Microsoft.EntityFrameworkCore;
using WebAPI.Infrostructure.Entities;

namespace WebAPI.Infrostructure
{
	public class ApplicationContext:DbContext
	{
		public DbSet<Restaurant> Restaurants { get; set; } = null!;
		public DbSet<RestaurantCategory> RestaurantCategories { get; set; } = null!;

		public ApplicationContext() 
		{
			//Database.EnsureDeleted();
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Restaurant>()
			.HasOne(r => r.Category);
			
			base.OnModelCreating(modelBuilder);
		}
	}
}
