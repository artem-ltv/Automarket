namespace Automarket.Domain.Interfaces
{
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
    }
}
