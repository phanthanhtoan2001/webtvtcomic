using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NToastNotify;
using WebAppComics.Models;

namespace WebAppComics.Pages.ManageComic
{
    public class EditModel : PageModel
    {
        private readonly IToastNotification _notify;
        private readonly WebAppComics.Models.ComicReadWebsiteContext context;
        [BindProperty]
        public ComicBonus ComicBonus { get; set; }
        public EditModel(WebAppComics.Models.ComicReadWebsiteContext context,IToastNotification notify)
        {
            this.context = context;
            this._notify = notify;
        }
        public void OnGet(Guid id)
        {
            var comic = context.Comics.Find(id);
            if (comic != null)
            {
                ComicBonus = new ComicBonus()
                {
                    ComicId = comic.ComicId,
                    ComicName = comic.ComicName,
                    Describe = comic.Describe,
                    ComicBanner = comic.ComicBanner,
                    DateSummitted = comic.DateSummitted,
                    Rating = comic.Rating,
                    ComicStatus = comic.ComicStatus,
                    AccountId = comic.AccountId,
                };


            }
        }
        public IActionResult OnPost()    
        {
            if (ComicBonus != null)
            {
                var exist = context.Comics.Find(ComicBonus.ComicId);
                {
                    if (exist != null)
                    {
                        exist.ComicName = ComicBonus.ComicName;
                        //exist.ComicBanner = ComicBonus.ComicBanner; 
                        exist.Describe = ComicBonus.Describe;
                        exist.DateSummitted = ComicBonus.DateSummitted;
                        exist.Rating = ComicBonus.Rating;
                        exist.ComicStatus = ComicBonus.ComicStatus;
                        //char[] delimiterChars = { '@',' '};
                        //string text = ComicBonus.ComicBanner.ToString();
                        ////string[] words = text.Split('@') ;
                        //int index = text.IndexOf("undefined");
                        //text = text.Remove(index);
                        ////  string s2 = text.Remove(0)
                        //string[] words = text.Split(delimiterChars);
                        //foreach (var word in words)
                        //{
                        //    Image image = new Image();
                        //    image.ImageUrl = word;
                        //    //image.ChapterId = 

                        //    context.Images.Add(image);
                        //    context.SaveChanges();
                        //}                        

                        // }

                        exist.ComicBanner = ComicBonus.ComicBanner;
                        context.SaveChanges();
                        _notify.AddSuccessToastMessage("Sửa thành công!");
                        return RedirectToAction("Index");   
                    }
                    else
                    {
                        return RedirectToAction("/404");
                    }
                
                }
               
            }else
            {
                return RedirectToPage("/404");
            }
        }





    }
}

