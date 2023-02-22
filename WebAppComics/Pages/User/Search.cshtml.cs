using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppComics.Models;

namespace WebAppComics.Pages.User
{
    public class SearchModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;

        public SearchModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
        }

        public IList<Comic> Comic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Comics != null)
            {
                Comic = await _context.Comics
                .Include(c => c.Account).ToListAsync();
            }
        }
    }
}
