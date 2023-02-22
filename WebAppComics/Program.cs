using Microsoft.EntityFrameworkCore;
using NToastNotify;
using WebAppComics.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//builder.Services.AddRazorPages(options =>
//{
//    options.RootDirectory = "/ListComic";
//    options.Conventions.AuthorizeFolder("/ListComic/Index");
//});
builder.Services.AddDbContext<ComicReadWebsiteContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("ComicReadWebsiteContext") ?? throw new InvalidOperationException("Connection string 'ComicReadWebsiteContext' not found.")));
builder.Services.AddSession( options => { options.IdleTimeout = TimeSpan.FromMinutes(240); });
builder.Services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = true,
    PositionClass = ToastPositions.TopRight,
    PreventDuplicates = true,
    CloseButton = true
});
//builder.Services.AddMvc().AddRazorPagesOptions(options =>


//   options.RootDirectory = "/ListComic"


//);

var app = builder.Build();
var configuration = builder.Configuration;

//builder.Services.AddAuthentication()
//   .AddGoogle(options =>
//   {
//       IConfigurationSection googleAuthNSection =
//       configuration.GetSection("Authentication:Google");
//       options.ClientId = googleAuthNSection["ClientId"];
//       options.ClientSecret = googleAuthNSection["ClientSecret"];
//   });

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
