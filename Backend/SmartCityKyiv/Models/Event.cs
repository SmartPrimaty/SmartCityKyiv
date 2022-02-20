using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCityKyiv.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateFrom { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DateTo { get; set; }
        public string Description { get; set; }
    }
}
