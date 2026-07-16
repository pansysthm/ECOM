using System.ComponentModel.DataAnnotations;

namespace ECOM.Entities
{
    /// <summary>
    /// Sản phẩm yêu thích
    /// </summary>
    public class WishlistItem
    {
        [Key]
        public int Id { get; set; } // ID yêu thích
        public int UserId { get; set; } // ID người dùng
        public int ProductId { get; set; } // ID sản phẩm
    }
}
