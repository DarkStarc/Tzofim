using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Globalization;
using Tzofim.Models;
using Microsoft.EntityFrameworkCore;
namespace Tzofim.Controllers
{
    public class MainController : Controller
    {
        private readonly DatabaseContext context; 
        public MainController(DatabaseContext _context)
        {
            context = _context;
        }
        public IActionResult SetLanguage(string culture,string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddDays(1) });

            return LocalRedirect(returnUrl);
        }

        public IActionResult Index(int page = 0)
        {
            const int COUNT_NEWS_ON_PAGE = 10;

            string currentLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            var query = context.News.OrderByDescending(p => p.DateTime)

                .Include(p => p.CultureId)
                .Where(p => p.CultureId.Key == currentLanguage)
                .Skip(page * COUNT_NEWS_ON_PAGE)
                .Take(25);

            return View(query.ToList());
        }

        public IActionResult TimeTable()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
