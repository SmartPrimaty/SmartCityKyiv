using SmartCityKyiv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCityKyiv.ViewModels
{
    public class MainPageViewModel
    {
        public List<Article> Articles { get; set; }

        public List<Event> Events { get; set; }
    }
}
