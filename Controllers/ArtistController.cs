using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlbumListUnitProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumListUnitProject.Controllers
{
    public class ArtistController : Controller
    {

        private AlbumContext _context { get; set; }
        public ArtistController(AlbumContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Artist());
        }

        [HttpPost]
        public IActionResult Add(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Artists.Add(artist);
                _context.SaveChanges();
                return RedirectToAction("Add", "Album");
            }
            return View(artist);
        }

    }
}
