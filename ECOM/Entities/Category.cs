using System.ComponentModel.DataAnnotations;

namespace ECOM.Entities
{
    /// <summary>
    /// Danh mục sản phẩm
    /// </summary>
    public class Category
    {
        [Key]
        public int Id { get; set; } // ID danh mục
        [Required]
        public string Name { get; set; } // Tên danh mục
    }
}
