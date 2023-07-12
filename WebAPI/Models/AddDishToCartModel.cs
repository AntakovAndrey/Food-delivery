using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class AddDishToCartModel
    {
        [Required]
        public int CartId { get; set; }
        [Required]
        public int DishId { get; set; }
    }
}
