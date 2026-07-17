namespace ECOM.Models;

public class BaseResponseDataModel<T>
{
    public string Message { get; set; } = string.Empty;
    public IEnumerable<T> Data { get; set; } = [];
}