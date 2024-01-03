using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.Enums
{
    public enum TypeCar
    {
        [Display(Name = "Седан")]
        Sedan = 0,

        [Display(Name = "Купе")]
        Сompartment = 1,

        [Display(Name = "Хэтчбек")]
        HatchBack = 2,

        [Display(Name = "Универсал")]
        Universal = 3,

        [Display(Name = "Кроссовер")]
        Crossover = 4,

        [Display(Name = "Внедорожник")]
        Suv = 5,

        [Display(Name = "Пикап")]
        Pickup = 6,

        [Display(Name = "Минивэн")]
        Minivan = 7
    }
}
