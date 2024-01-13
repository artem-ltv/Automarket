using Automarket.Domain.Models;
using Automarket.Domain.Interfaces;
using Automarket.Domain.ViewModels.Car;

namespace Automarket.Service.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetAllCars();
        Task<IBaseResponse<Car>> GetCarById(int id);
        Task<IBaseResponse<Car>> GetCarByName(string name);
        Task<IBaseResponse<bool>> DeleteCar(int id);
        Task<IBaseResponse<bool>> CreateCar(CarViewModel carViewModel);
    }
}
