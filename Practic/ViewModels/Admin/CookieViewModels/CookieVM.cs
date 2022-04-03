using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practic.ViewModels.Admin.CookieViewModels
{
    public class CookieVM
    {

        public int Id { get; set; }
        //[Required]
        public List<IFormFile> Images { get; set; }
        public string Header { get; set; }
        public string Main { get; set; }
        public string Footer { get; set; }
    }
}

