using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using WebAppComics.Models;

namespace WebAppComics.Pages.ListChapter
{
    public class EditModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext context;
        private readonly IToastNotification _notify;
        public EditModel(WebAppComics.Models.ComicReadWebsiteContext context, IToastNotification notify)
        {
            this.context = context;
            this._notify = notify;
        }

        [BindProperty]
        public ChapterBonus ChapterBonus { get; set; }
        public void OnGet(Guid id)
        {
            var chapter = context.Chapters.Find(id);
            if (chapter != null)
            {
                ChapterBonus = new ChapterBonus()
                {
                    ChapterId = chapter.ChapterId,
                    ChapterName = chapter.ChapterName,
                    View = chapter.View,
                   UpdateDay = chapter.UpdateDay,   
                   ComicId = chapter.ComicId,

                };


            }

        }
        public IActionResult OnPost()
        {

            if (ChapterBonus != null)
            {
                var exist = context.Chapters.Find(ChapterBonus.ChapterId);
                {
                    if (exist != null)
                    {
                        try
                        {
                            exist.ChapterName = ChapterBonus.ChapterName;

                            exist.UpdateDay = ChapterBonus.UpdateDay;
                           
                            context.SaveChanges();
                            _notify.AddSuccessToastMessage("Sửa chapter mới thành công!");
                        }
                        catch { return RedirectToPage("./404"); }

                    }

                }
                return RedirectToPage("./Index");

            }
            else
            {
                return RedirectToPage("./404");
            }
        }
    }
}
