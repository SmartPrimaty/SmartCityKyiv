using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCityKyiv.Models
{
    public class Location
    {
        [Key]
        public int Id{ get; set; }
        public string? Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Longitude { get; set; }
        [Required]
        public int Latitude { get; set; }
    }
}
