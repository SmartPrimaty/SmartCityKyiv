using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCityKyiv.Models
{
    public class ValidDates: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateFrom = Convert.ToDateTime(value);
            var model = (Models.Event)validationContext.ObjectInstance;
            DateTime dateTo = Convert.ToDateTime(model.DateTo);         
            if (dateFrom.Date < DateTime.Now.Date)
            {
                return new ValidationResult("Event cannot start earlier than now.");
            }
            else if (dateFrom > dateTo && dateTo!=new DateTime())
            {
                return new ValidationResult("Expiration date should be greater than Start date.");
            }
            return ValidationResult.Success;
        }
    }
}
