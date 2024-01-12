using Automarket.Domain.Enums;
using Automarket.Domain.Interfaces;

namespace Automarket.Domain.Responses
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
