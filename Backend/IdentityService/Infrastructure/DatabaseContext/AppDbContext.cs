using IdentityService.Domain.Interfaces;
using IdentityService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.DatabaseContext;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Address> Addresses { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);
            
            entity.Property(u => u.Email)
                .HasConversion(
                    e => e.Value,
                    v => Domain.ValueObjects.Email.Create(v))
                .IsRequired()
                .HasMaxLength(320)
                .HasColumnName("Email");
            
            entity.Property(u => u.Password)
                .HasConversion(
                    p => p.Hash,
                    v => Domain.ValueObjects.Password.FromHash(v))
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("PasswordHash");
            
            entity.Property(u => u.EmailVerified)
                .IsRequired()
                .HasDefaultValue(false);
            
            entity.Property(u => u.CreatedAt)
                .IsRequired();
            
            entity.Property(u => u.UpdatedAt)
                .IsRequired();
            
            entity.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("IX_Users_Email");
            
            entity.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasMany(u => u.RefreshTokens)
                .WithOne(rt => rt.User)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            entity.Property(r => r.Description)
                .HasMaxLength(500);
            
            entity.Property(r => r.Permissions)
                .HasConversion(
                    p => string.Join(",", p),
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList())
                .HasColumnName("Permissions");
            
            entity.HasIndex(r => r.Name)
                .IsUnique()
                .HasDatabaseName("IX_Roles_Name");
            
            entity.HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(ur => ur.Id);
            
            entity.Property(ur => ur.AssignedAt)
                .IsRequired();
            
            entity.HasIndex(ur => new { ur.UserId, ur.RoleId })
                .IsUnique()
                .HasDatabaseName("IX_UserRoles_User_Role");
            
            entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(rt => rt.Id);
            
            entity.Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(500);
            
            entity.Property(rt => rt.ExpiresAt)
                .IsRequired();
            
            entity.Property(rt => rt.IsRevoked)
                .IsRequired()
                .HasDefaultValue(false);
            
            entity.Property(rt => rt.CreatedAt)
                .IsRequired();
            
            entity.HasIndex(rt => rt.Token)
                .IsUnique()
                .HasDatabaseName("IX_RefreshTokens_Token");
            
            entity.HasIndex(rt => rt.UserId)
                .HasDatabaseName("IX_RefreshTokens_UserId");
            
            entity.HasIndex(rt => rt.ExpiresAt)
                .HasDatabaseName("IX_RefreshTokens_ExpiresAt");
            
            entity.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(a => a.HouseNumber)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(a => a.ApartmentNumber)
                .HasMaxLength(20);
            entity.Property(a => a.Entrance)
                .HasMaxLength(20);
            entity.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(a => a.IsDefault)
                .IsRequired()
                .HasDefaultValue(false);
            entity.Property(a => a.CreatedAt)
                .IsRequired();
            entity.Property(a => a.UpdatedAt)
                .IsRequired();
            entity.HasIndex(a => a.UserId)
                .HasDatabaseName("IX_Addresses_UserId");
            entity.HasIndex(a => new { a.UserId, a.IsDefault })
                .HasDatabaseName("IX_Addresses_User_IsDefault")
                .HasFilter("[IsDefault] = 1");
            entity.HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
