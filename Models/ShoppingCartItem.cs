using System.ComponentModel.DataAnnotations;

namespace DIKESE.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Seminar Seminar { get; set; }
        public int Amount { get; set; }


        public string? ShoppingCartId { get; set; }
    }
}
