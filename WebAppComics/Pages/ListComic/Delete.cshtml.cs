using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppComics.Models;

namespace WebAppComics.Pages.ManageComic
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;

        public DeleteModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Comic Comic { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Comics == null)
            {
                return NotFound();
            }

            var comic = await _context.Comics.FirstOrDefaultAsync(m => m.ComicId == id);

            if (comic == null)
            {
                return NotFound();
            }
            else 
            {
                Comic = comic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Comics == null)
            {
                return NotFound();
            }
            var comic = await _context.Comics.FindAsync(id);

            if (comic != null)
            {
                Comic = comic;
                _context.Comics.Remove(Comic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
