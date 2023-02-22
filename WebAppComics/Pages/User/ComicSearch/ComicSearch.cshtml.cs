using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using WebAppComics.Models;

namespace WebAppComics.Pages.User.ComicSearch
{
    public class ComicSearchModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;
        private readonly IToastNotification _Notify;
        public List<Comic> comics;
        public string accountname { get; set; }
        public ComicSearchModel(Models.ComicReadWebsiteContext context,IToastNotification notify)
        {
            _context = context;
            _Notify = notify;
        }
        public IList<Comic> comic { get; set; } = default!;
        public async Task OnGetAsync(string term)
        {
            var query = await _context.Comics.ToListAsync();
            if (!String.IsNullOrEmpty(term))
            {
                comic = query.Where(s => s.ComicName.Contains(term)).ToList();
                ViewData["search"] = term;
            }
            else
            {
                comic = await _context.Comics.ToListAsync();
            }           
        }

    }
}
