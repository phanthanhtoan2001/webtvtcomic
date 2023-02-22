using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using WebAppComics.Models;

namespace WebAppComics.Pages.ManageComic
{
    public class CreateModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext context;
        private readonly IToastNotification _notify;

        public CreateModel(WebAppComics.Models.ComicReadWebsiteContext context, IToastNotification notify)
        {
            this.context = context;
            this._notify = notify;
        }
        [BindProperty]
        public ComicBonus ComicBonus { get; set; }


        public IActionResult OnPost()
        {
            var comicbonus = new Comic
            {
                ComicName = ComicBonus.ComicName,
                Describe = ComicBonus.Describe,
                ComicBanner = ComicBonus.ComicBanner,
                DateSummitted = ComicBonus.DateSummitted,
                Rating = ComicBonus.Rating,
                ComicStatus = ComicBonus.ComicStatus,
                AccountId = ComicBonus.AccountId
            };
            context.Comics.Add(comicbonus);
            context.SaveChanges();
            HttpContext.Session.SetString("ComicId", comicbonus.ComicId.ToString());
            HttpContext.Session.SetString("ComicName", comicbonus.ComicName);

            return RedirectToPage("../ListChapter/Create");
        }
    }
}
