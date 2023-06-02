using System.ComponentModel.DataAnnotations;

namespace WebAPI.Infrostructure.Entities
{
    class Restaurant
    {
        public int Id {get;set;}
        [Required]
        public string? Name {get;set;}
        [Required]
        public double Rating {get;set;}
        [Required]
        public string? PhotoURL { get;set;}
        [Required]
        public RestaurantCategory? Category { get;set;}
    }
}