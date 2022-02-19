using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCityKyiv.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
