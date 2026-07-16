using System;
using System.ComponentModel.DataAnnotations;

namespace ECOM.Entities
{
    /// <summary>
    /// Đơn hàng
    /// </summary>
    public class Order
    {
        [Key]
        public int Id { get; set; } // ID đơn hàng
        public int UserId { get; set; } // ID người dùng
        public decimal Total { get; set; } // Tổng tiền
        public string Status { get; set; } = "Pending"; // Trạng thái
        public string Address { get; set; } // Địa chỉ
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Ngày tạo
    }
}
