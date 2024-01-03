using Automarket.Domain.Enums;

namespace Automarket.Domain.Models
{
    public class Car
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public double Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public TypeCar TypeCar { get; set; }
    }
}
