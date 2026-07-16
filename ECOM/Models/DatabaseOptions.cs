namespace ECOM.Models;

/// <summary>
/// Thông tin kết nối Database
/// </summary>
public class DatabaseOptions
{
    public string Provider { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
}