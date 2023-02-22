using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppComics.Models;

namespace WebAppComics.Pages.ListChapter
{
    public class IndexModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;

        public IndexModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Chapter> Chapter { get;set; } 

        public async Task OnGetAsync(string? comics)
        {


            comics = HttpContext.Session.GetString("b").ToString();
            var  chapters = (from c in _context.Chapters where (c.Comic.ComicName.Equals(comics)) 
                                                orderby (c.Comic.ComicName) 
                                                select c).ToList();
                Chapter = chapters.ToList();
           
        } 
    }
}
