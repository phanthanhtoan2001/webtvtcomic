using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using WebAppComics.Models;

namespace WebAppComics.Pages.User.SignIn
{
    public class SignUpModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;
        private readonly IToastNotification _notify;
        public SignUpModel(WebAppComics.Models.ComicReadWebsiteContext context,  IToastNotification notify)
        {
            _context = context;
           this._notify = notify;
        }





        [BindProperty]
        public AccountBonus AccountBonus { get; set; }




        
        public IActionResult OnPost()
        {
            var account = new Account
            {
                AccountName = AccountBonus.AccountName,
                CategoryAccId = AccountBonus.CategoryAccId,
                Email = AccountBonus.Email,
                PassWord = AccountBonus.PassWord,

            };
            _context.Accounts.Add(account); 
            _context.SaveChanges();
            _notify.AddSuccessToastMessage("Tạo tài khoản  thành công!");
            return RedirectToPage("Login");
        }
    }
}
