using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentals.Models;
using System.Data.Entity;
using Rentals.DTOs;

namespace Rentals.Controllers
{
    public class ManagerController : Controller
    {
        private List<FilmDto> allFilms = FilmManager.GetAllFilms();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Manager
        public ActionResult Index()
        {
            return View(allFilms);
        }

        public ActionResult Users()
        {
            var userDetails = new List<ApplicationUser>();
            var users = db.Users.ToList();
            foreach (var user in users)
            {
               var newUser = new ApplicationUser()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address=user.Address,
                    UserName=user.UserName
                };

                userDetails.Add(newUser);
            }

            return View(userDetails);
        }

        public ActionResult Create()
        {
            var filmDto = new FilmDto();
            return View(filmDto);

            //if (Session["model"] != null)
            //filmDto = (Film)Session["model"];


        }

        public ActionResult Edit(Guid id)
        {
            var filmDto = allFilms.FirstOrDefault(p => p.FilmId == id);
            return View(filmDto);
        }

        public bool CreateFilm([Bind(Include = "FilmId,Name,Series,NumberofSeries,Year,Details,Genre")]FilmDto filmDto)
        {
            var exists = allFilms.Any(b => b.Name.Equals(filmDto.Name));
            if (!exists)
            {
                try
                {
                    filmDto.Rented = false;
                    filmDto.FilmId = Guid.NewGuid();
                    addDbEntry(filmDto);
                    
                    //db.Films.Add(film);
                    //db.SaveChanges();
                    return true;
                    //return RedirectToAction("Index", "Manager");
                }
                catch (Exception ex)
                {
                    //ViewBag.Message = ex.Message;
                    return false;
                    //Session["message"] = ex.Message;
                    //return RedirectToAction("CreationError", "Error");
                }

            }
            else
            {
                return false;
                
                /*Session["message"] = "Must create a new film.";
                Session["film"] = film;
                return RedirectToAction("CreationError", "Error");
                */
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FilmDto filmDto)
        {
            //if(ModelState.IsValid)
           
                try
                {
                if (filmDto.Rented == true)
                    filmDto.Renter = null;
                    updateDbEntry(filmDto);
                    return RedirectToAction("Index", "Manager");
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                

                //db.Entry(filmDto).State = EntityState.Modified;
                //db.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult FilterFilms(string filterBy)
        {
            var rentedFilms = allFilms.FindAll(p => p.Rented == true);
            if (filterBy == "Rented")
                return PartialView("FilmDetails", rentedFilms);
            else
                return PartialView("FilmDetails", allFilms);
        }

        private void updateDbEntry(FilmDto filmDto)
        {
            FilmManager.UpdateDbEntry(filmDto);
        }

        private void addDbEntry(FilmDto filmDto)
        {
            FilmManager.CreateDbEntry(filmDto);
        }
    }
}