using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using WebAppComics.Models;

namespace WebAppComics.Pages.ListChapter
{
    public class CreateModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;
        private readonly IToastNotification _notify;
        public CreateModel(WebAppComics.Models.ComicReadWebsiteContext context, IToastNotification notify)
        {
            _context = context;
            this._notify = notify;
        }
        [BindProperty]
        public ChapterBonus ChapterBonus { get; set; }  
        public IActionResult OnPost()
        {
            var chaper = new Chapter
            { 
                ChapterName = ChapterBonus.ChapterName,
                UpdateDay =  ChapterBonus.UpdateDay,
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
