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
    public class DetailsModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;

        public DetailsModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
        }

        public Comic Comic { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<Chapter> Chapters { get; set; }
        public List<Image> Images { get; set; }


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Comics == null)
            {
                return NotFound();
            }

            var comic = await _context.Comics.FirstOrDefaultAsync(m => m.ComicId == id);
            var chapter = (from ch in _context.Chapters
                           join c in _context.Comics on ch.ComicId equals c.ComicId
                           where (ch.ComicId == id)
                           orderby ch.ChapterName select ch).ToList();
            Chapters = chapter.ToList();
            //var images = (from i in _context.Images
            //              join ch in _context.Chapters on i.ChapterId equals ch.ChapterId
            //              where (i.ChapterId == id)
            //              select i).ToList();
            //Images = images.ToList();

            if (comic == null)
            {
                return NotFound();
            }
            else
            {
                Comic = comic;
              
                return Page();
            }
        }


        //public void OnGetChapterAsync()
        //{
        //    var chapter = (from ch in _context.Chapters
        //                   join c in _context.Comics on ch.ComicId equals c.ComicId where (ch.ComicId == c.ComicId)
        //                   select ch).ToList();
        //    Chapter = chapter;



        //}
    }
}
