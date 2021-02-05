using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Tzofim.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;

namespace Tzofim.Controllers
{
    public class NewsController : Controller
    {
        private readonly DatabaseContext context;
        private readonly IOptions<RequestLocalizationOptions> locOptions;
        public NewsController(DatabaseContext _context, IOptions<RequestLocalizationOptions> _options)
        {
            context = _context;
            locOptions = _options;
        }

        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNews(News news,string culture) 
        {
            if (ModelState.IsValid && locOptions.Value.SupportedUICultures.Any(p=>p.TwoLetterISOLanguageName == culture))
            {
                context.News.Add(news);

                context.Cultures.Where(p => p.Key == culture).FirstOrDefault().News.Append(news);

                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Main");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveNews(int id, string culture)
        {
            if (id>=0 && !String.IsNullOrWhiteSpace(culture))
            {
                var news = context.News.Include(p => p.CultureId).FirstOrDefault(p => p.NewsId == id && p.CultureId.Key == culture);

                if (news != null)
                {
                    context.Remove(news);
                }

                context.SaveChanges();
            }

            return RedirectToAction("Index", "Main");
        }
    }
}
