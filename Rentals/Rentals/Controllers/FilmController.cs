using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentals.Models;
using Rentals.Enums;
using Rentals.DTOs;

namespace Rentals.Controllers
{
    public class FilmController : Controller
    {
        private List<FilmDto> films = FilmManager.GetAllFilms();

        public ActionResult Details(Guid id)
        {
            var film = films.Find(p => p.FilmId == id);
            return View(film);
        }

        // GET: Film
        [HttpPost]
        public ActionResult Index(Guid id)
        {
            var movie = films.FirstOrDefault(p => p.FilmId == id);
            return View(movie);
        }
    
        [HttpPost]
        [Authorize]
        public ActionResult Rent(Guid id)
        {
            var user = new ApplicationUser();
            var film = films.FirstOrDefault(p => p.FilmId == id);

            return View(user.Films);
        }
    }
}