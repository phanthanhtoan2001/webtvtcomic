using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppComics.Models;

namespace WebAppComics.Pages.SignIn
{
    public class ResetPasswordModel : PageModel
    {
        private readonly ComicReadWebsiteContext _context;
        public ResetPasswordModel(ComicReadWebsiteContext context)
        {
            _context = context;
        }
        public Account account { get; set; }
        public async Task<IActionResult> OnPostAsync(string username, string password,string paswordConfirm)
        {

            var account = _context.Accounts.FirstOrDefault(p => p.AccountName.Equals(username));
            if(account != null)
            {
                //check.PassWord = password.ToString();
                //password = paswordConfirm;
                //_context.Accounts.AddAsync(account);
                //_context.SaveChangesAsync();
                //return RedirectToPage("../SignIn/Login");
                //check.PassWord = password.ToString();
                if(password == paswordConfirm)
                {
                    account.PassWord = password;  
                    _context.Accounts.Update(account);  
                    _context.SaveChanges(); 
                }   
                //_context.Accounts.AddAsync(account);
                //_context.SaveChangesAsync();
                return RedirectToPage("../SignIn/Login");
            }
            else
            {
                return Page();
            }
            return RedirectToPage("../SignIn/ResetPassword");
        }
        public void OnGet()
        {
        }
    }
}
