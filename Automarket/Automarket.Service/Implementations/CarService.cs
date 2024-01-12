using Automarket.DAL.Interfaces;
using Automarket.Domain.Models;
using Automarket.Domain.Responses;
using Automarket.Domain.Interfaces;
using Automarket.Service.Interfaces;

namespace Automarket.Service.Implementations
{
    public class CarService : ICarService
    { 
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetAllCars()
        {
            var baseResponse = new BaseResponse<IEnumerable<Car>>();
            try
            {
                var cars = await _carRepository.GetAll();
                if (cars.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элеметов";
                    baseResponse.StatusCode = Domain.Enums.StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = cars;
                baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars]: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCarById(int id)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.GetById(id);
                if(car == null)
                {
                    baseResponse.Description = "Элемент не найден";
                    baseResponse.StatusCode = Domain.Enums.StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = car;
                baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCars]: {ex.Message}"
                };
            }
        }
    }
}
