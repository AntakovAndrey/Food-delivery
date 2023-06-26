using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrastructure.Entities
{
    public class Restaurant
    {
        public int Id {get;set;}
        [Required]
        public string? Name {get;set;} 
        [Required]
        public double Rating {get;set;}

        //    [Required] 
        //    public TimeOnly WorkTimeStart { get; set; }
        //[Required]
        //public TimeOnly WorkTimeFinish { get; set; }
        [Required]
        public string Address { get;set;}

		[Required]
        public string? PhotoURL { get;set;}
        public int CategoryId { get;set;}
		[Required]
		public RestaurantCategory Category { get;set;}
        public IEnumerable<Dish> Dishes { get;set;}
    }
}