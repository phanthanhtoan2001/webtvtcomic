using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Security.Principal;
using WebAppComics.Models;

namespace WebAppComics.Pages.User
{
    public class cartTextModel : PageModel
    {
        public static List<Comic> comics  = new List<Comic>();
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;
        private readonly IToastNotification notify;

        public cartTextModel(WebAppComics.Models.ComicReadWebsiteContext context,IToastNotification notify)
        {
            _context = context;
            this.notify = notify;
        }
        public IActionResult OnGetBuy(Guid id)
        {

          var check = _context.Comics.FirstOrDefault(m => m.ComicId == id);
            if (check != null)
            {                
                string comicsId;
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(1);
                if (Request.Cookies["comics"] == null)
                {
                    comicsId = "a"+" "+ check.ComicId.ToString();
                }
                else
                {

                    if (Request.Cookies["comics"].Contains(check.ComicId.ToString()) == false)
                    {
                        comicsId = Request.Cookies["comics"] + " " + check.ComicId.ToString();
                    }
                    else
                    {
                        notify.AddErrorToastMessage("Truyện này đã được theo dõi");
                        comicsId = Request.Cookies["comics"];
                        return RedirectToPage("../User/Details", new { id });
                    }
                }
                Response.Cookies.Append("comics", comicsId, cookieOptions);
                notify.AddSuccessToastMessage("Theo dõi truyện thành công!");
                return RedirectToPage("../User/Details", new {id});
            }
            return RedirectToPage("Index");
        }

        //public void deleteCookie()
        //{
        //    if (Request.Cookies["comics"] != null)
        //    {
        //        Response.Cookies.Delete("comics");
        //    }
        //}
        public IActionResult OnGetDelete()
        {
            if (Request.Cookies["comics"] != null)
            {
                Response.Cookies.Delete("comics");
            }
            return RedirectToPage("cartText");
        }
        public void OnGet()
        {
        }
    }
}
