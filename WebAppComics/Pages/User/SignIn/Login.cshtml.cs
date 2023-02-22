using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NToastNotify;
using WebAppComics.Models;

namespace WebAppComics.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Account account { get; set; }
        private ComicReadWebsiteContext _context;
        private readonly IToastNotification _notify;
        public string msg;
        public LoginModel(ComicReadWebsiteContext context, IToastNotification notify) 
        {
            _context = context;
            this._notify = notify;
        }
        public void OnGet()
        {
            account = new Account();
        }
        
        public Account Loginuser (string accountName, string passWord, int user =1)
        {
            try
            {
                var account = _context.Accounts.Where(a =>
                              a.AccountName.Equals(accountName) &&
                              a.PassWord.Equals(passWord) &&
                              a.CategoryAccId.Equals(user)).FirstOrDefault();
                return account;

            }
            catch (Exception ex)
            {
                return account; 
            }        
        }
        public Account Loginadmin(string accountName, string passWord, int categoryuser =2, int categoryadmin = 3)
        {
            try
            {
                var account = _context.Accounts.Where(a =>
                            (  a.AccountName.Equals(accountName) &&
                              a.PassWord.Equals(passWord) &&
                              a.CategoryAccId.Equals(categoryuser)) ||
                              (a.AccountName.Equals(accountName) &&
                              a.PassWord.Equals(passWord) &&
                              a.CategoryAccId.Equals(categoryadmin)))
                              .FirstOrDefault();
                return account;

            }
            catch (Exception ex)
            {
                return account;
            }
        }
        public IActionResult OnPost()
        {
            var acc = Loginuser(account.AccountName, account.PassWord);
            var admin = Loginadmin(account.AccountName, account.PassWord);

            if (HttpContext.Session.GetString("AccountName") != null)
            {
                HttpContext.Session.Remove("AccountName");
                return Page();
            }
            if (HttpContext.Session.GetString("AccountNameadmin") != null)
            {
                HttpContext.Session.Remove("AccountNameadmin");
                return Page();
            }

            if (acc != null  && acc.CategoryAccId.Equals(1))
            {
               
                    HttpContext.Session.SetString("AccountName", acc.AccountName);
                    HttpContext.Session.SetString("Accountcauser", acc.CategoryAccId.ToString());
                     HttpContext.Session.SetString("User", acc.AccountId.ToString());
                _notify.AddSuccessToastMessage("Đăng nhập thành công");
                    return RedirectToPage("../Index");
                
            }
            else if((admin != null && admin.CategoryAccId.Equals(2))||(admin != null && admin.CategoryAccId.Equals(3)) ) 
            {
             
               
                    HttpContext.Session.SetString("AccountNameadmin", admin.AccountName);
                    HttpContext.Session.SetString("Accountadmin", admin.CategoryAccId.ToString());
                    HttpContext.Session.SetString("Id", admin.AccountId.ToString());
                    _notify.AddSuccessToastMessage("Đăng nhập thành công");
                    return RedirectToPage("../Index");
                
            }
            else
            {
                _notify.AddWarningToastMessage("Mật khẩu tài khoản không đúng!");
                return Page();
            }
        }


        public async Task logingoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }
        public bool checkgmailacc(string se)
        {
            var checkmail = _context.Accounts.FirstOrDefault(P => P.Email.Equals(se));
            if(checkmail != null)
            {
                return true;
            }
            return false;
        } 
        //public async Task<IActionResult> GoogleResponse()
        //{
        //    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
        //        {
        //            claim.Issuer,
        //            claim.OriginalIssuer,
        //            claim.Type,
        //            claim.Value
        //        });
        //    // https://www.youtube.com/watch?v=YmxtJ5euiSo
        //    string s = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Select(p => p.Value).FirstOrDefault();
        //    string c = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname").Select(p => p.Value).FirstOrDefault();
        //    bool b = checkgmailacc(s);
        //    if (b == true)
        //    {
        //        Account a = new Account();            
        //        a.Email = s;
        //        a.AccountName = c;
        //        a.CategoryAccId = 1;              
        //        _context.Accounts.Add(a);
        //        _context.SaveChanges();
        //        _notify.AddSuccessToastMessage("Đăng nhập thành công");
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return Page();
        //}
    }
}
