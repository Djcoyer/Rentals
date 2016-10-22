using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentals.Models;
using Rentals.Enums;
using Rentals.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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

        public ActionResult Genre(string genre)
        {
            var filmGenre = films.FindAll(p => p.Genre.ToString().Equals(genre));
            return View(filmGenre);
        }

        [Authorize]
        public ActionResult Rent(Guid id)
        {
            var film = films.FirstOrDefault(p => p.FilmId == id);
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = manager.FindById(User.Identity.GetUserId());
            film.Renter = user.Id;
            film.Rented = true;
            updateDbEntry(film);
            List<FilmDto> userFilms = films.FindAll(p => p.Renter == user.Id);


            return View(userFilms);
        }

        private void updateDbEntry(FilmDto filmDto)
        {
            FilmManager.UpdateDbEntry(filmDto);
        }

        [HttpPost]
        public void ReturnFilm(Guid filmId)
        {
            var film = films.FirstOrDefault(p => p.FilmId == filmId);
            film.Rented = false;
            film.Renter = null;
            updateDbEntry(film);
            RedirectToAction("Index", "Home");
        }
    }
}