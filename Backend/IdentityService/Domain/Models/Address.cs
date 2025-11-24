using IdentityService.Domain.Common;

namespace IdentityService.Domain.Models;

public class Address : Entity
{
    public Guid UserId { get; private set; }
    public string Street { get; private set; }
    public string HouseNumber { get; private set; }
    public string? ApartmentNumber { get; private set; }
    public int? Floor { get; private set; }
    public string? Entrance { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }
    public bool IsDefault { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    public virtual User User { get; private set; } = null!;
    
    private Address() { }
    
    public Address(
        Guid userId, 
        string street, 
        string houseNumber, 
        string city, 
        string postalCode, 
        string country, 
        string? apartmentNumber = null,
        int? floor = null,
        string? entrance = null,
        bool isDefault = false)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("User ID cannot be empty", nameof(userId));
        
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be empty", nameof(street));
        
        if (string.IsNullOrWhiteSpace(houseNumber))
            throw new ArgumentException("House number cannot be empty", nameof(houseNumber));
        
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty", nameof(city));
        
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal code cannot be empty", nameof(postalCode));
        
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be empty", nameof(country));
        
        if (floor.HasValue && floor.Value < 0)
            throw new ArgumentException("Floor cannot be negative", nameof(floor));
        
        UserId = userId;
        Street = street.Trim();
        HouseNumber = houseNumber.Trim();
        ApartmentNumber = string.IsNullOrWhiteSpace(apartmentNumber) ? null : apartmentNumber.Trim();
        Floor = floor;
        Entrance = string.IsNullOrWhiteSpace(entrance) ? null : entrance.Trim();
        City = city.Trim();
        PostalCode = postalCode.Trim();
        Country = country.Trim();
        IsDefault = isDefault;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Update(
        string street, 
        string houseNumber, 
        string city, 
        string postalCode, 
        string country,
        string? apartmentNumber = null,
        int? floor = null,
        string? entrance = null)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be empty", nameof(street));
        
        if (string.IsNullOrWhiteSpace(houseNumber))
            throw new ArgumentException("House number cannot be empty", nameof(houseNumber));
        
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty", nameof(city));
        
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal code cannot be empty", nameof(postalCode));
        
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be empty", nameof(country));
        
        if (floor.HasValue && floor.Value < 0)
            throw new ArgumentException("Floor cannot be negative", nameof(floor));
        
        Street = street.Trim();
        HouseNumber = houseNumber.Trim();
        ApartmentNumber = string.IsNullOrWhiteSpace(apartmentNumber) ? null : apartmentNumber.Trim();
        Floor = floor;
        Entrance = string.IsNullOrWhiteSpace(entrance) ? null : entrance.Trim();
        City = city.Trim();
        PostalCode = postalCode.Trim();
        Country = country.Trim();
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SetAsDefault()
    {
        IsDefault = true;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void RemoveDefault()
    {
        IsDefault = false;
        UpdatedAt = DateTime.UtcNow;
    }
}
