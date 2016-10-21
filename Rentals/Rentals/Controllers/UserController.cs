using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentals.Models;
using Rentals.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Rentals.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = manager.FindById(User.Identity.GetUserId());
            return View(user);
        }

        public ActionResult UserFilms(List<FilmDto> films)
        {
            return View(films);
        }

        public ActionResult Edit(string userId)
        {
            return View();
        }
    }
}