using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practic.Data;
using Practic.Models;
using Practic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practic.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            SliderDetail sliderDetail = await _context.SliderDetails.FirstOrDefaultAsync();
            List<Corusel> corusels = await _context.Corusels.ToListAsync();
            List<Cookie> cookies = await _context.Cookies.ToListAsync();
            List<Category> categories = await _context.Categories.ToListAsync();
            List<Product> products = await _context.Products.ToListAsync();
            List<ProductImage> productImages = await _context.ProductImages.ToListAsync();

            HomeVM homeVM = new HomeVM
            {
               Sliders=sliders,
               Detail=sliderDetail,
               Corusels=corusels,
               Cookies=cookies,
               Categories=categories,
               Products=products,
               ProductImages=productImages
            };
            
            return View(homeVM);
        }
    }
}
