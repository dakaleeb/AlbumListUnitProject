using AlbumListUnitProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlbumListUnitProject.Controllers
{
    public class AlbumController : Controller
    {
        private AlbumContext context { get; set; }

        public AlbumController(AlbumContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.GenreName).ToList();
            ViewBag.Artists = context.Artists.OrderBy(a=>a.ArtistName).ToList();
            return View("Edit", new Album());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.GenreName).ToList();
            ViewBag.Artists = context.Artists.OrderBy(a => a.ArtistName).ToList();
            var album = context.Albums.Find(id);
            return View(album);
        }

        [HttpPost]
        public IActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                if (album.AlbumId == 0)
                    context.Albums.Add(album);
                else
                    context.Albums.Update(album);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (album.AlbumId == 0) ? "Add" : "Edit";
                ViewBag.Genres = context.Genres.OrderBy(g => g.GenreName).ToList();
                ViewBag.Artists = context.Artists.OrderBy(a => a.ArtistName).ToList();
                return View(album);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var album = context.Albums.Find(id);
            return View(album);
        }

        [HttpPost]
        public IActionResult Delete(Album album)
        {
            context.Albums.Remove(album);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
