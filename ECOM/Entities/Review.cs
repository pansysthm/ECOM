using System;
using System.ComponentModel.DataAnnotations;

namespace ECOM.Entities
{
    /// <summary>
    /// Đánh giá sản phẩm
    /// </summary>
    public class Review
    {
        [Key]
        public int Id { get; set; } // ID đánh giá
        public int ProductId { get; set; } // ID sản phẩm
        public int UserId { get; set; } // ID người dùng
        [Range(1, 5)]
        public int Rating { get; set; } // Điểm đánh giá
        public string Comment { get; set; } // Nội dung đánh giá
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Ngày tạo
    }
}
