using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppComics.Pages.SignIn
{
    public class CodeSubmitModel : PageModel
    {
        //public string otpcheck { get; set; }
        public async Task<IActionResult> OnGetAsync(string otpcheckview1)
        {
            var otpcheck = HttpContext.Session.GetString("OTPSubmit"); 
            if (otpcheck != null)
            {
                if (otpcheck.Equals(otpcheckview1))
                {
                    return RedirectToPage("../SignIn/ResetPassword");
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("OTP");
            return RedirectToPage("../SignIn/Login");
        }
    }
}
