using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using WebAppComics.Models;

namespace WebAppComics.Pages.User.ListCategory
{
    public class ListImageModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;
        private readonly IToastNotification _notify;
        public ListImageModel(WebAppComics.Models.ComicReadWebsiteContext context, IToastNotification notify)
        {
            _context = context;
            _notify = notify;   
        }
        [BindProperty]
      public  List<Image> Image { get; set; }
        public CommentBonus  CommentBonus { get; set; }
        //public List<Comment> comments { get; set; }

        //public string commentcontent { get; set; }
        public int accountid { get; set; }
        public Guid chapterid { get; set; }
        public void  OnGetAsync(Guid? id)
        {
            var image = (from c in _context.Images orderby c.ImageUrl  where(c.ChapterId.Equals(id)) select c).ToList();
            var list = image.DistinctBy(m => m.ImageUrl);
            Image=list.ToList();   
        }

        public IActionResult OnPost(string? commentcontent,Guid id)
        {
            Guid a = Guid.Parse(HttpContext.Session.GetString("ma1")) ;
            if (HttpContext.Session.GetString("Accountcauser") == "1" || HttpContext.Session.GetString("Accountadmin") == "2" ||
                HttpContext.Session.GetString("Accountadmin") == "3")
            {
                  Comment comment = new Comment();
               
                {           
                    if(HttpContext.Session.GetString("Accountcauser") == "1")
                        {
                        var usercommnent = HttpContext.Session.GetString("User");
                        comment.CommnentContent = commentcontent;
                        comment.AccountId = int.Parse(usercommnent);
                        comment.ChapterId = a;
                        comment.Date = DateTime.Now;
                        _context.Comments.Add(comment);
                        _context.SaveChanges();
                    }
                        else if (HttpContext.Session.GetString("Accountadmin") == "2" || HttpContext.Session.GetString("Accountadmin") == "3")
                        {
                            var postercommnent = HttpContext.Session.GetString("Id");
                             comment.CommnentContent = commentcontent;
                            comment.AccountId = int.Parse(postercommnent);
                            comment.ChapterId = a;
                            comment.Date = DateTime.Now;
                             _context.Comments.Add(comment);
                            _context.SaveChanges();

                    }                                                  
                    //comment.AccountId = CommentBonus.AccountId;
                    //comment.ChapterId = CommentBonus.ChapterId;
                    //comment.AccountId = CommentBonus.AccountId;
                    
                }          
                return RedirectToPage("../User/Image", new {id});

            }
            else 
            { 
            
                _notify.AddErrorToastMessage(" Vui lòng đăng nhập tài khoản!");
            }
            return RedirectToPage("../User/Image", new {id});
        }
    }
}
