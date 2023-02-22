using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using WebAppComics.Models;

namespace WebAppComics.Pages.ListImage
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
        public ImageBonus ImageBonus { get; set; }


        public IActionResult OnPost()
        {
            char[] delimiterChars = { '@', ' ' };
            var text = ImageBonus.ImageUrl;
           
            string[] words = text.Split(delimiterChars);
            foreach (var word in words)
            {
                Image image = new Image();
                if (word != "") 
                { 
                    image.ImageUrl = word;
                    image.ChapterId = ImageBonus.ChapterId;
                     context.Images.Add(image);
                     context.SaveChanges();
                    _notify.AddSuccessToastMessage("Đăng truyện thành công!"  );
                    return RedirectToAction("./ListComic/Index");

                }


            }
           
            return RedirectToAction("./ListComic/Index");




        }

    }


}
