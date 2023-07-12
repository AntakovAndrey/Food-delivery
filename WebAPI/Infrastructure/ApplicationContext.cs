using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure.Entities;

namespace WebAPI.Infrastructure
{
	public class ApplicationContext:DbContext
	{
		public DbSet<Order> Orders { get; set; } = null!;
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Role> Roles { get; set; } = null!;
		public DbSet<Restaurant> Restaurants { get; set; } = null!;
		public DbSet<RestaurantCategory> RestaurantCategories { get; set; } = null!;
		public DbSet<DishCategory> DishCategories { get; set; } = null!;
		public DbSet<Dish> Dishes { get; set; } = null!;
		public DbSet<Cart> Carts { get; set; } = null!;
		public DbSet<OrderDishes> OrderDishes { get; set; } = null!;
		public DbSet<CartDishes> CartDishes { get; set; } = null!;

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public ApplicationContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=;Initial catalog =FoodDelivery;Integrated Security = true; TrustServerCertificate=true");
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Restaurant>()
			.HasOne(r => r.Category);
			modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany().OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Order>().HasOne(o => o.Deliveryman).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CartDishes>().HasOne(e => e.Dish).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderDishes>().HasOne(e => e.Dish).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cart>().HasOne(e => e.User).WithMany().OnDelete(DeleteBehavior.Restrict);
    
            base.OnModelCreating(modelBuilder);
		}
	}
}