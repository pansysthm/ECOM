using System;
using System.ComponentModel.DataAnnotations;

namespace ECOM.Entities
{
    /// <summary>
    /// Thông tin người dùng
    /// </summary>
    public class User
    {
        [Key]
        public Guid Id { get; set; } // ID người dùng
        [Required]
        public string Email { get; set; } // Email đăng nhập
        [Required]
        public string PasswordHash { get; set; } // Mật khẩu đã mã hóa
        public string FullName { get; set; } // Họ và tên
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Ngày tạo
    }
}
