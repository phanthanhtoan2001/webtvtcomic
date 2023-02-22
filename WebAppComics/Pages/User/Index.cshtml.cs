using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppComics.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace ComicWebsite.Pages.ListImages
{
    public class IndexModel : PageModel
    {
        private readonly WebAppComics.Models.ComicReadWebsiteContext _context;
        //private readonly IConfiguration Configuration;

        public IndexModel(WebAppComics.Models.ComicReadWebsiteContext context)
        {
            _context = context;
           
        }
        [BindProperty]
        public String searchstring { get; set; }    
       
      
      
    }
}
