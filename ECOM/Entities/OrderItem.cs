using System.ComponentModel.DataAnnotations;

namespace ECOM.Entities
{
    /// <summary>
    /// Chi tiết đơn hàng
    /// </summary>
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } // ID chi tiết
        public int OrderId { get; set; } // ID đơn hàng
        public int VariantId { get; set; } // ID biến thể
        public int Quantity { get; set; } // Số lượng
        public decimal UnitPrice { get; set; } // Giá đơn vị
    }
}
