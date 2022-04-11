using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCityKyiv.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле має бути заповненим")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Неправильний формат")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле має бути заповненим")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле має бути заповненим")]
        [Compare(nameof(Password), ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Поле має бути заповненим")]
        public string FullName { get; set; }
    }
}
