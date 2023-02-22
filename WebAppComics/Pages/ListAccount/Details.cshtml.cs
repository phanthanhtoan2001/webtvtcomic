using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppComics.Models;

namespace WebAppComics.Pages.ManageAccount
{
    public class DetailsModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;

        public  DetailsModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
        }
    
        public Account Account { get; set; }
     
        public async Task<IActionResult> OnGetAsync(string user)
        {
            user = HttpContext.Session.GetString("User").ToString();
            if (user == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.Where(m => m.AccountId.ToString() == user).FirstOrDefaultAsync();
            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = account;
            }
            return Page();
        }
    }
}
