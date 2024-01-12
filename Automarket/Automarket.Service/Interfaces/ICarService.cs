using Automarket.Domain.Models;
using Automarket.Domain.Responses;
using Automarket.Domain.Interfaces;

namespace Automarket.Service.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetAllCars();
        Task<IBaseResponse<Car>> GetCarById(int id);
        //BaseResponse<Car> GetCarByName(string name);
        //BaseResponse<bool> DeleteCar(Car car);
        //BaseResponse<bool> CreateCar(Car car);
    }
}
