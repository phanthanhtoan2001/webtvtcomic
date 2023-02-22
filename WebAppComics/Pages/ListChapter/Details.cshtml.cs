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
    public class DetailsModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;

        public DetailsModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
        }
        [BindProperty]
      public Chapter Chapter { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Chapters == null)
            {
                return NotFound();
            }

            var chapter = await _context.Chapters.FirstOrDefaultAsync(m => m.ChapterId == id);
            if (chapter == null)
            {
                return NotFound();
            }
            else 
            {
                Chapter = chapter;
            }
            return Page();
        }
    }
}
