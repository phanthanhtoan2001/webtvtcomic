using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Text;
using WebAppComics.Classes;
using WebAppComics.Models;
using WebAppComics.Classes;
using Microsoft.Extensions.Configuration;
using System;


                                 

namespace WebAppComics.Pages.ManageComic
{
    public class IndexModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(WebAppComics.Models.ComicReadWebsiteContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;  
        }
        [BindProperty]
        public PaginatedList<Comic> Comic { get; set; }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            var accountname =HttpContext.Session.GetString("AccountNameadmin").ToString();
            string poster = "2";
            string admin = "3";

             if (HttpContext.Session.GetString("Accountadmin")== poster  )
             {
                       IQueryable<Comic> ComicId = from s in _context.Comics 
                                        where (s.Account.CategoryAccId.Equals(2) && s.Account.AccountName.Equals(accountname))
                                        select s;
                       var pageSize = Configuration.GetValue("PageSize", 4);
                       Comic = await PaginatedList<Comic>.CreateAsync(
                        ComicId.AsNoTracking(), pageIndex ?? 1, pageSize);
              
            }
            else if ((HttpContext.Session.GetString("Accountadmin")== admin))
            {
                IQueryable<Comic> ComicId = from s in _context.Comics
                                            select s;
                var pageSize = Configuration.GetValue("PageSize", 4);
                Comic = await PaginatedList<Comic>.CreateAsync(
                 ComicId.AsNoTracking(), pageIndex ?? 1, pageSize);
            }

        }

            // public List<Comic> Comic { get; set; } = default!;

            //public async Task OnGetAsync()
            //{
            //    //var pageNumber = page ?? 1;
            //    //int pageSize = 10;
            //    //Comic = await _context.Comics.ToPagedList(pageNumber, pageSize).ToListAsync();
            //    if (_context.Comics != null)
            //    {
            //        Comic = await _context.Comics
            //        .Include(c => c.Account).ToListAsync();
            //    }
            //}
            //public void OnGet(int PageNum = 1)
            //{

            //    Comic = _context.Comics.OrderBy(m => m.ComicId).ToList<Comic>();
            //    StringBuilder QParam = new StringBuilder();
            //    if (PageNum != 0)
            //    {
            //        QParam.Append($"/Index?PageNum=-");

            //    }

            //    if (Comic.Count > 0)
            //    {
            //        var PagingData = new PagingData
            //        {
            //            CurrentPage = PageNum,
            //            RecordsPerPage = PaperSize,
            //            TotalRecords = Employees.Count(),
            //            UrlParams = QParam.ToString(),
            //            LinksPerPage = 7
            //        };
            //        Employees = Employees.Skip((PageNum - 1) * PageSize)
            //       .Take(PageSize).ToList();

            //    }


            //}
        }
}
