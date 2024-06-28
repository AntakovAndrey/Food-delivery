using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class AddOrderModel
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
