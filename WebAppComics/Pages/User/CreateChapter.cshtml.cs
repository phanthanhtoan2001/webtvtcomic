using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppComics.Models;

namespace WebAppComics.Pages.User
{
    public class CreateChapterModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;

        public CreateChapterModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChapterBonus ChapterBonus { get; set; }
        public IActionResult OnPost()
        {
            var chaper = new Chapter
            {
                ChapterName = ChapterBonus.ChapterName,
                UpdateDay = ChapterBonus.UpdateDay,
                View = ChapterBonus.View,
                ComicId = ChapterBonus.ComicId

            };
            _context.Chapters.Add(chaper);
            _context.SaveChanges();
            HttpContext.Session.SetString("ChapterId", chaper.ChapterId.ToString());
            HttpContext.Session.SetString("ChapterName", chaper.ChapterName);

            return RedirectToPage("../ListImage/Create");
        }
    }
}
