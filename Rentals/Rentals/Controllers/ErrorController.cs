using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentals.Models;
using Rentals.DTOs;


namespace Rentals.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public string ErrorMessage(FilmDto film)
        {
            string message = "";
            if (film.Name == null)
                message += "The name field is required, ";
            if (film.Year < 1900 || film.Year > 2050)
                message += "Please enter a valid year, ";
            if (film.Genre.ToString() == null)
                message += "Please select a genre.";

            return message;

/*            Dictionary<string, string> errorList = new Dictionary<string, string>();
            if (film.Name == null)
                errorList.Add("Name", "Please enter a film name.");
            if (film.Genre.ToString() == null)
                errorList.Add("Genre", "Please select a valid genre.");
            if (film.Year < 1900 || film.Year > 2050)
                errorList.Add("Year", "Please enter a valid year.");
                */
        }

    }
}