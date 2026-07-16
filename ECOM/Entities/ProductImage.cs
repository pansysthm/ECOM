using System.ComponentModel.DataAnnotations;

namespace ECOM.Entities
{
    /// <summary>
    /// Hình ảnh sản phẩm
    /// </summary>
    public class ProductImage
    {
        [Key]
        public int Id { get; set; } // ID hình ảnh
        public int ProductId { get; set; } // ID sản phẩm
        [Required]
        public string Url { get; set; } // Đường dẫn ảnh
        public bool IsPrimary { get; set; } // Là ảnh chính
    }
}
