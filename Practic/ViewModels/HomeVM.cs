using Practic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practic.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public SliderDetail Detail { get; set; }
        public List<Corusel> Corusels { get; set; }

        public List<Cookie> Cookies { get; set; }
        public List<Category> Categories { get; set; }

        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }






    }
}
