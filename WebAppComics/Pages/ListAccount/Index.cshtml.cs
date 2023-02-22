using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppComics.Models;

namespace WebAppComics.Pages.ListAccount
{
    public class IndexModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;

        public IndexModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
        }

        public IList<Image> Image { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Images != null)
            {
                Image = await _context.Images
                .Include(i => i.Chapter).ToListAsync();
            }
        }
    }
}
