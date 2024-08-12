using System.ComponentModel.DataAnnotations;

namespace MTW.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string InventoryName { get; set; } = string.Empty;

        [Range(1,int.MaxValue, ErrorMessage="Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public double Price { get; set; }
    }
}
