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

namespace WebAppComics.Pages.ManageAccount
{
    public class EditModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext context;
      private readonly IToastNotification _notify;
        public EditModel(WebAppComics.Models.ComicReadWebsiteContext context,IToastNotification notify)
        {
            this.context = context;
            this._notify = notify;
        }

        [BindProperty]
        public AccountBonus AccountBonus { get; set; }
      public void OnGet(int id)
        {
            var account = context.Accounts.Find(id);
            if (account != null)
            {
                AccountBonus = new AccountBonus()
                {
                    AccountId = account.AccountId,
                    AccountName = account.AccountName,
                    PassWord = account.PassWord,
                    AccountImage = account.AccountImage,
                    Email = account.Email,  
                    Date = account.Date,
                    Phone = account.Phone,
                    CategoryAccId = account.CategoryAccId,

                };
                

            }
         
        }
        public IActionResult OnPost()
        {
            
            if (AccountBonus != null)
            {
                var exist = context.Accounts.Find(AccountBonus.AccountId);
                {
                    if (exist != null)
                    {
                        try
                        {
                            exist.AccountName = AccountBonus.AccountName;

                            exist.AccountImage = AccountBonus.AccountImage;
                            exist.Email = AccountBonus.Email;
                            exist.Date = AccountBonus.Date;
                            exist.Phone = AccountBonus.Phone;
                            exist.PassWord = AccountBonus.PassWord; 
                            //   exist.CategoryAccId = AccountBonus.CategoryAccId;  
                            context.SaveChanges();
                            _notify.AddSuccessToastMessage("Sửa thông tin thành công!");
                            return RedirectToPage("./Details");
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