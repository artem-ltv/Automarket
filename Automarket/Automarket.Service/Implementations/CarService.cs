using Automarket.DAL.Interfaces;
using Automarket.Domain.Models;
using Automarket.Domain.Responses;
using Automarket.Domain.Interfaces;
using Automarket.Service.Interfaces;
using Automarket.Domain.ViewModels.Car;

namespace Automarket.Service.Implementations
{
    public class CarService : ICarService
    { 
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
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
                    Description = $"[GetAllCars]: {ex.Message}",
                    StatusCode = Domain.Enums.StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCarById(int id)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseResponse.StatusCode = Domain.Enums.StatusCode.NotFound;
                    baseResponse.Description = "Элемент не найден";
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
                    Description = $"[GetCarById]: {ex.Message}",
                    StatusCode = Domain.Enums.StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.GetByName(name);
                if (car == null)
                {
                    baseResponse.StatusCode = Domain.Enums.StatusCode.NotFound;
                    baseResponse.Description = "Элемент не найден";
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
                    Description = $"[GetCarByName]: {ex.Message}",
                    StatusCode = Domain.Enums.StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseResponse.StatusCode = Domain.Enums.StatusCode.NotFound;
                    baseResponse.Description = "Элемент не найден";
                    return baseResponse;
                }

                var isDelete = await _carRepository.Delete(car);
                baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
                baseResponse.Data = isDelete;

                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar]: {ex.Message}",
                    StatusCode = Domain.Enums.StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> CreateCar(CarViewModel carViewModel, byte[] image)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                if(carViewModel == null)
                {
                    baseResponse.Description = "Элемент carViewModel = null";
                    baseResponse.StatusCode = Domain.Enums.StatusCode.NotFound;

                    return baseResponse;
                }

                var newCar = new Car()
                {
                    Name = carViewModel.Name,
                    Description = carViewModel.Description,
                    Model = carViewModel.Model,
                    Speed = carViewModel.Speed,
                    Price = carViewModel.Price,
                    CreateDate = carViewModel.CreateDate,
                    TypeCar = carViewModel.TypeCar,
                };

                var isCreated = await _carRepository.Create(newCar);

                baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
                baseResponse.Data = isCreated;

                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateCar]: {ex.Message}",
                    StatusCode = Domain.Enums.StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Edit(int id, CarViewModel model)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.Get(id);
                if(car == null)
                {
                    baseResponse.StatusCode = Domain.Enums.StatusCode.NotFound;
                    baseResponse.Description = "Элемент не найден";

                    return baseResponse;
                }

                car.Name = model.Name;
                car.Description = model.Description;
                car.Model = model.Model;
                car.Speed = model.Speed;
                car.Price = model.Price;
                car.CreateDate = model.CreateDate;
                //car.TypeCar = model.TypeCar;

                await _carRepository.Update(car);

                baseResponse.Data = car;
                baseResponse.StatusCode = Domain.Enums.StatusCode.OK;

                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[EditCar]: {ex.Message}",
                    StatusCode = Domain.Enums.StatusCode.InternalServerError
                };
            }
        }
    }
}
