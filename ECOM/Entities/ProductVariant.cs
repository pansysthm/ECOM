using System.ComponentModel.DataAnnotations;

namespace ECOM.Entities
{
    /// <summary>
    /// Biến thể sản phẩm
    /// </summary>
    public class ProductVariant
    {
        [Key]
        public int Id { get; set; } // ID biến thể
        public int ProductId { get; set; } // ID sản phẩm
        public double Size { get; set; } // Kích thước
        [Required]
        public string Color { get; set; } // Màu sắc
        public int Stock { get; set; } // Tồn kho
    }
}
