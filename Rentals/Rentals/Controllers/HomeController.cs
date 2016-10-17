using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentals.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using Rentals.DTOs;

namespace Rentals.Controllers
{
    public class HomeController : Controller
    {
        private List<FilmDto> films = FilmManager.GetAvailableFilms();
        // GET: Home
        public ActionResult Index()
        {
            return View(films);
        }

        public ActionResult Details(Guid id)
        {
            var film = films.Find(p => p.FilmId == id);
            return View(film);
        }

      

        public ActionResult Series(string series)
        {
            var filmSeries = films.FindAll(p => p.Series == series);
            return View(filmSeries);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Rent(Guid id)
        {
            var movie = films.FirstOrDefault(p => p.FilmId == id);
            return View(movie);

            /*
            var movie = films.FirstOrDefault(p => p.FilmId == film.FilmId);
            movie.Available = false;
            //db.Entry(movie).State = EntityState.Modified;
            sendToDb(movie);
            return RedirectToAction("Index");
    */    
    }

        [HttpPost]
        public ActionResult Sort(string sortBy)
        {
            films.Where(p => p.Available == true).ToList();
            var titles = sortMethod(films, sortBy);
            return PartialView("_FilmDetails", titles);
        }
        private List<FilmDto> sortMethod(List<FilmDto> films, string sortBy)
        {
            List<FilmDto> titles = new List<FilmDto>();

                if (sortBy == "Alphabetical")
                {
                    titles = films.OrderBy(b => b.Name).ToList();
            }
                else if (sortBy == "Genre")
                {
                    titles = films.OrderBy(b => b.Genre).ToList();
            }
                else if (sortBy == "Series")
                {
                    titles = films.OrderBy(b => b.Series).ToList();
            }
                else if (sortBy == "Year")
                {
                    titles = films.OrderBy(b => b.Year).ToList();
            }

            return titles;

        }

        private static void sendToDb(FilmDto filmDto)
        {
            
        }
    }
}