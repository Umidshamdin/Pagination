using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practic.Models
{
    public class Cookie
    {
        public int Id { get; set; }

        public string Image { get; set; }
        public string Header { get; set; }
        public string Main { get; set; }
        public string Footer { get; set; }

        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }

    }
}
