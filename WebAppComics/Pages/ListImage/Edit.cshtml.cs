using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppComics.Models;

namespace WebAppComics.Pages.ListImage
{
    public class EditModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;

        public EditModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ImageBonus ImageBonus { get; set; }

        //
        //public Image Image { get; set; } = default!;

        public void OnGet(int? id)
        {
            var image = _context.Images.Find(id);
            if (image != null)
            {
                ImageBonus = new ImageBonus()
                {
                    ImageId = image.ImageId,
                    ImageUrl = image.ImageUrl,
                    ChapterId = image.ChapterId,
                    //ChapterName = image.Chapter.ChapterName,
                };
                   
                  

            }
        }
        public void OnPost()
        {
            if (ImageBonus != null)
            {
                var exist = _context.Images.Find(ImageBonus.ImageId);
                {
                    if (exist != null)
                    {
                        exist.ChapterId = ImageBonus.ChapterId;
                        exist.ImageId = ImageBonus.ImageId; 
                        exist.ImageUrl = ImageBonus.ImageUrl;
                      
                        //char[] delimiterChars = { '@' };
                        //string text = ImageBonus.ImageUrl.ToString();
                        //string[] words = text.Split(delimiterChars);
                        //foreach (var word in words)
                        //{
                        //    Image image = new Image();
                        //    image.ImageUrl = word;
                        //    //image.ChapterId = 
                        //    _context.Images.Add(image);
                        //    _context.SaveChanges();
                        //}
                        ////exist.ComicBanner = ComicBonus.ComicBanner;
                        _context.SaveChanges();
                      ViewData["success"] = " Edit thành công !";
                    }
                }
            }
        }
    }
}
