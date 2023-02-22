using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppComics.Models;

namespace WebAppComics.Pages.ListImage
{
    public class ListModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;

        public ListModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Image> Image { get;set; }

        public async Task OnGetAsync(string? image)
        {
            image = HttpContext.Session.GetString("chuong");

            var images = (from c in _context.Images  where (c.Chapter.Comic.ComicName.Equals(image)) select c).ToList();
            Image = images.ToList();
            if(images .Any() == false)
            {
                ViewData["ch"] = "ma khong bang";
                ViewData["1"] = image;
               
            }
            
        }
    }
}
