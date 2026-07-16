using System;
using System.ComponentModel.DataAnnotations;

namespace ECOM.Entities
{
    /// <summary>
    /// Sản phẩm
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; } // ID sản phẩm
        public int CategoryId { get; set; } // ID danh mục
        [Required]
        public string Name { get; set; } // Tên sản phẩm
        public string Description { get; set; } // Mô tả
        public decimal Price { get; set; } // Giá tiền
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Ngày tạo
    }
}
