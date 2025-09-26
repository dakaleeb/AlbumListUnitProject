using AlbumListUnitProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AlbumListUnitProject.Controllers
{
    public class HomeController : Controller
    {
        private AlbumContext context { get; set; }

        public HomeController(AlbumContext ctx) => context = ctx;

       public IActionResult Index()
       {
           var albums = context.Albums.Include (a => a.Genre).Include (b => b.Artist).OrderBy(a => a.AlbumName).ToList();
           return View(albums);
       }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
