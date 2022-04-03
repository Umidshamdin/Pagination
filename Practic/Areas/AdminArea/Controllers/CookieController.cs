using FrontToBackEnd.Utilities.File;
using FrontToBackEnd.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Practic.Data;
using Practic.Models;
using Practic.ViewModels.Admin.CookieViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cookie = Practic.Models.Cookie;

namespace Practic.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CookieController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CookieController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Cookie> cookies = await _context.Cookies.ToListAsync();
            return View(cookies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CookieVM cookieVM)
        {

            if (ModelState["Images"].ValidationState == ModelValidationState.Invalid) return View();

            if (ModelState["Header"].ValidationState == ModelValidationState.Invalid) return View();

            if (ModelState["Main"].ValidationState == ModelValidationState.Invalid) return View();

            if (ModelState["Footer"].ValidationState == ModelValidationState.Invalid) return View();

            foreach (var photo in cookieVM.Images)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Image type is wrong");
                    return View();
                }

                if (!photo.CheckFileSize(800))
                {
                    ModelState.AddModelError("Photo", "Image size is wrong");
                    return View();
                }

            }

            foreach (var photo in cookieVM.Images)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;


                string path = Helper.GetFilePath(_env.WebRootPath, "assets/img", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }






                Cookie poster = new Cookie
                {
                    Image = fileName,
                    Header = cookieVM.Header,
                    Main = cookieVM.Main,
                    Footer = cookieVM.Footer

                };

                await _context.Cookies.AddAsync(poster);

            }








            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
